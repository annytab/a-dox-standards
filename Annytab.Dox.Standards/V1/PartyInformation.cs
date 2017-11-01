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
            this.person_id = "";
            this.person_name = "";
            this.address_line_1 = "";
            this.address_line_2 = "";
            this.address_line_3 = "";
            this.postcode = "";
            this.city_name = "";
            this.country_name = "";
            this.country_code = "";
            this.state_code = "";
            this.contact_name = "";
            this.phone_number = "";
            this.email = "";
            this.vat_number = "";

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