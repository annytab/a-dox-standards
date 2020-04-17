using System.Collections.Generic;
using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represent meta information
    /// </summary>
    public class AnnytabDoxMeta
    {
        #region Variables

        public string date_of_sending { get; set; }
        public string file_encoding { get; set; }
        public string filename { get; set; }
        public string standard_name { get; set; }
        public string language_code { get; set; }
        public IList<Signature> signatures { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public AnnytabDoxMeta()
        {
            // Set values for instance variables
            this.date_of_sending = null;
            this.file_encoding = null;
            this.filename = null;
            this.standard_name = null;
            this.language_code = null;
            this.signatures = null;
            
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