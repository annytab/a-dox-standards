using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represent a signature
    /// </summary>
    public class Signature
    {
        #region Variables

        public string validation_type { get; set; }
        public string algorithm { get; set; }
        public string padding { get; set; }
        public string data { get; set; }
        public string value { get; set; }
        public string certificate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public Signature()
        {
            // Set values for instance variables
            this.validation_type = null;
            this.algorithm = null;
            this.padding = null;
            this.data = null;
            this.value = null;
            this.certificate = null;

        } // End of the constructor

        #endregion

        #region Get methods

        /// <summary>
        /// Convert the object to a json string
        /// </summary>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);

        } // End of the ToString method

        #endregion

    } // End of the class

} // End of the namespace