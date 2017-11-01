using System.Collections.Generic;
using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represent a contract document
    /// </summary>
    public class AnnytabDoxContract
    {
        #region Variables

        public string id { get; set; }
        public string issue_date { get; set; }
        public IList<PartyInformation> parties { get; set; }
        public IList<ContractPoint> articles { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public AnnytabDoxContract()
        {
            // Set values for instance variables
            this.id = "";
            this.issue_date = "2000-01-01";
            this.parties = new List<PartyInformation>();
            this.articles = new List<ContractPoint>();

        } // End of the constructor

        #endregion

        #region Get methods

        /// <summary>
        /// Convert the object to a json string
        /// </summary>
        /// <returns>A json formatted string</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);

        } // End of the ToString method

        #endregion

    } // End of the class

} // End of the namespace