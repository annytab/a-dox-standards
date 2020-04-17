using System;

namespace TestProgram
{
    /// <summary>
    /// This class represent email options
    /// </summary>
    public class EmailOptions
    {
        #region Variables

        public string Host { get; set; }
        public Int32? Port { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Pickup { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post
        /// </summary>
        public EmailOptions()
        {
            // Set values for instance variables
            this.Host = null;
            this.Port = 0;
            this.Email = null;
            this.Password = null;
            this.Pickup = null;

        } // End of the constructor

        #endregion

    } // End of the class

} // End of the namespace