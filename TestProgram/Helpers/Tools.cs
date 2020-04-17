using System;

namespace TestProgram
{
    /// <summary>
    /// This class includes handy methods
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Get the extensions of a filename as a string
        /// </summary>
        /// <param name="filename">A filename with extensions</param>
        /// <returns>A string with extensions, dot (.) is included</returns>
        public static string GetExtensions(string filename)
        {
            // Create the extension to return
            string extensions = "";

            Int32 index = filename.IndexOf(".");

            if (index > -1)
            {
                extensions = filename.Substring(index);
            }

            // Return extensions
            return extensions;

        } // End of the GetExtensions method

    } // End of the class

} // End of the namespace