using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represent information about a party
    /// </summary>
    public class PartyInformation
    {
        #region Variables

        public string person_id { get; set; }
        public string person_name { get; set; }
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string address_line_3 { get; set; }
        public string postcode { get; set; }
        public string city_name { get; set; }
        public string country_name { get; set; }
        public string country_code { get; set; }
        public string state_code { get; set; }
        public string contact_name { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string vat_number { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public PartyInformation()
        {
            // Set values for instance variables
            this.person_id = null;
            this.person_name = null;
            this.address_line_1 = null;
            this.address_line_2 = null;
            this.address_line_3 = null;
            this.postcode = null;
            this.city_name = null;
            this.country_name = null;
            this.country_code = null;
            this.state_code = null;
            this.contact_name = null;
            this.phone_number = null;
            this.email = null;
            this.vat_number = null;

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