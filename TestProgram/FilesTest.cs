using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Annytab.Dox.Standards.V1;

namespace TestProgram
{
    [TestClass]
    public class FilesTest
    {
        #region Variables

        private IConfigurationRoot configuration { get; set; }
        private ILogger logger { get; set; }
        private EmailOptions options { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new test instance
        /// </summary>
        public FilesTest()
        {
            // Add configuration settings
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.AddJsonFile($"appsettings.Development.json", optional: true);
            this.configuration = builder.Build();

            // Create a service collection
            IServiceCollection services = new ServiceCollection();

            // Add logging and options as services
            services.AddLogging(logging => {
                logging.AddConfiguration(configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
            });
            services.AddOptions();

            // Get options
            this.options = configuration.GetSection("EmailOptions").Get<EmailOptions>();

            // Build a service provider
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            // Configure file logging
            ILoggerFactory loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddFile("C:\\DATA\\home\\AnnytabDoxStandards\\Logs\\log-{Date}.txt");

            // Get references
            this.logger = loggerFactory.CreateLogger<FilesTest>();

        } // End of the constructor

        #endregion

        [TestMethod]
        public void SaveToDisk()
        {
            // Create a file path
            string path = "C:\\DATA\\home\\AnnytabDoxStandards\\" + Guid.NewGuid().ToString() + ".dox.zip";

            // Create documents
            IDictionary<string, byte[]> files = new Dictionary<string, byte[]>();
            files.Add("meta.json", Documents.CreateAnnytabDoxMeta());
            files.Add("file.json", Documents.CreateAnnytabDoxInvoice());

            // Create and use a new file stream
            using(FileStream zip = new FileStream(path, FileMode.Create))
            {
                // Create and use a new zip archive
                using (ZipArchive archive = new ZipArchive(zip, ZipArchiveMode.Create, true))
                {
                    // Add files to archive
                    foreach (KeyValuePair<string, byte[]> file in files)
                    {
                        // Add the file to the zip
                        ZipArchiveEntry entry = archive.CreateEntry(file.Key, CompressionLevel.Fastest);
                        using (Stream stream = entry.Open())
                        {
                            stream.Write(file.Value, 0, file.Value.Length);
                        }
                    }
                }
            }

        } // End of the SaveToDisk method

        [TestMethod]
        public void ReadFromDisk()
        {
            // Create a file path
            string directory = "C:\\DATA\\home\\AnnytabDoxStandards";

            // Variables
            AnnytabDoxMeta meta = null;
            byte[] file_array = null;

            // Get all files
            string[] files = System.IO.Directory.GetFiles(directory + "\\Open");

            // Loop files
            foreach (string path in files)
            {
                // Create and use an archive
                using (ZipArchive archive = ZipFile.OpenRead(path))
                {
                    // Loop files in zip
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        // Check if a file is meta or file
                        if (entry.FullName.StartsWith("meta", StringComparison.OrdinalIgnoreCase))
                        {
                            using (MemoryStream stream = new MemoryStream())
                            {
                                entry.Open().CopyTo(stream);
                                byte[] array = stream.ToArray();
                                meta = JsonConvert.DeserializeObject<AnnytabDoxMeta>(Encoding.UTF8.GetString(array, 0, array.Length));
                            }
                        }
                        else
                        {
                            using (MemoryStream stream = new MemoryStream())
                            {
                                entry.Open().CopyTo(stream);
                                file_array = stream.ToArray();
                            }
                        }
                    }

                    // Log standard name
                    this.logger.LogInformation($"Fetching: {meta.standard_name} from open folder.", null);

                    // Get file contents depending on standard name
                    if (meta.standard_name.Equals("Annytab Dox Trade v1", StringComparison.OrdinalIgnoreCase))
                    {
                        AnnytabDoxTrade doc = JsonConvert.DeserializeObject<AnnytabDoxTrade>(Encoding.UTF8.GetString(file_array, 0, file_array.Length));
                    }
                    else if (meta.standard_name.Equals("Annytab Dox Contract v1", StringComparison.OrdinalIgnoreCase))
                    {
                        AnnytabDoxContract doc = JsonConvert.DeserializeObject<AnnytabDoxContract>(Encoding.UTF8.GetString(file_array, 0, file_array.Length));
                    }
                    else if (meta.standard_name.Equals("Annytab Dox Drive Log v1", StringComparison.OrdinalIgnoreCase))
                    {
                        AnnytabDoxDriveLog doc = JsonConvert.DeserializeObject<AnnytabDoxDriveLog>(Encoding.UTF8.GetString(file_array, 0, file_array.Length));
                    }
                    else if (meta.standard_name.Equals("Annytab Dox Travel Expense Claim v1", StringComparison.OrdinalIgnoreCase))
                    {
                        AnnytabDoxTravelExpenseClaim doc = JsonConvert.DeserializeObject<AnnytabDoxTravelExpenseClaim>(Encoding.UTF8.GetString(file_array, 0, file_array.Length));
                    }
                }

                // Move file from open to closed
                System.IO.Directory.Move(path, directory + "\\Closed\\" + Path.GetFileName(path));
            }

        } // End of the ReadFromDisk method

        [TestMethod]
        public async Task SendEmail()
        {
            // Create documents
            IDictionary<string, byte[]> files = new Dictionary<string, byte[]>();
            files.Add("meta.json", Documents.CreateAnnytabDoxMeta());
            files.Add("file.json", Documents.CreateAnnytabDoxInvoice());

            // Create and use a new memory stream
            using (MemoryStream zip = new MemoryStream())
            {
                // Create and use a new zip archive
                using (ZipArchive archive = new ZipArchive(zip, ZipArchiveMode.Create, true))
                {
                    // Add files to archive
                    foreach (KeyValuePair<string, byte[]> file in files)
                    {
                        // Add the file to zip
                        ZipArchiveEntry entry = archive.CreateEntry(file.Key, CompressionLevel.Fastest);
                        using (Stream stream = entry.Open())
                        {
                            stream.Write(file.Value, 0, file.Value.Length);
                        }
                    }
                }

                // Move the pointer to the start of the stream
                zip.Seek(0, SeekOrigin.Begin);

                // Create an smtp client
                SmtpClient smtp = new SmtpClient(this.options.Host, this.options.Port.GetValueOrDefault());
                smtp.Credentials = new NetworkCredential(this.options.Email, this.options.Password);
                smtp.EnableSsl = true;

                // Try to send the email message
                try
                {
                    // Create a mail message
                    MailMessage message = new MailMessage(this.options.Email, this.options.Pickup);

                    // Create the mail message
                    message.Subject = "Sending file";
                    message.Body = "File is attached.";
                    message.IsBodyHtml = true;

                    // Add an attachment
                    if (zip != null)
                    {
                        Attachment attach = new Attachment(zip, new System.Net.Mime.ContentType("application/zip"));
                        attach.ContentDisposition.FileName = Guid.NewGuid().ToString() + ".dox.zip";
                        message.Attachments.Add(attach);
                    }

                    // Send the mail message
                    await smtp.SendMailAsync(message);
                }
                catch (Exception ex)
                {
                    // Log the exception
                    this.logger.LogError(ex, $"Send email to: {this.options.Pickup}", null);
                }
            }

        } // End of the SendEmail method

        [TestMethod]
        public void PickupEmails()
        {
            // Reference to a directory
            string directory = "C:\\DATA\\home\\AnnytabDoxStandards\\Open\\";

            // Create and use an imap client
            using (var client = new MailKit.Net.Imap.ImapClient())
            {
                // Add credentials
                client.Connect(this.options.Host, 993, true);
                client.Authenticate(this.options.Pickup, this.options.Password);

                // Get inbox folder
                MailKit.IMailFolder inbox = client.Inbox;
                inbox.Open(MailKit.FolderAccess.ReadWrite);

                // Write information about the inbox
                Console.WriteLine("Total messages: {0}", inbox.Count);
                Console.WriteLine("Recent messages: {0}", inbox.Recent);

                // Create a query
                MailKit.Search.SearchQuery query = MailKit.Search.SearchQuery.NotDeleted.And(MailKit.Search.SearchQuery.NotSeen);

                // Loop messages
                foreach(MailKit.UniqueId uid in inbox.Search(query))
                {
                    // Get the message
                    var message = inbox.GetMessage(uid);

                    // Print subject
                    Console.WriteLine("Subject: {0}", message.Subject);

                    // Get attachments
                    foreach (var attachment in message.Attachments)
                    {
                        // Get information about the attachment
                        var file_name = attachment.ContentDisposition?.FileName;
                        file_name = string.IsNullOrEmpty(file_name) ? Guid.NewGuid().ToString() + ".noname" : Guid.NewGuid().ToString() + Tools.GetExtensions(file_name);
                        var content_type = attachment.ContentType;

                        // Only accept files that ends with dox.zip
                        if(file_name.EndsWith(".dox.zip") == true)
                        {
                            // Save the attachment to disk
                            using (FileStream stream = new FileStream(directory + file_name, FileMode.Create))
                            {
                                if (attachment is MimeKit.MessagePart)
                                {
                                    var part = (MimeKit.MessagePart)attachment;
                                    part.Message.WriteTo(stream);
                                }
                                else
                                {
                                    var part = (MimeKit.MimePart)attachment;
                                    part.Content.DecodeTo(stream);
                                }
                            }
                        }               
                    }

                    // Flag email as seen
                    inbox.AddFlags(uid, MailKit.MessageFlags.Seen, true);
                    //inbox.AddFlags(uid, MailKit.MessageFlags.Deleted, true);
                }

                // Disconnect client
                client.Disconnect(true);
            }

        } // End of the PickupEmails method

    } // End of the class

} // End of the namespace