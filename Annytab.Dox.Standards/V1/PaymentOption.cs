using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represent a payment option
    /// </summary>
    public class PaymentOption
    {
        #region Variables

        public string name { get; set; }
        public string account_reference { get; set; }
        public string bank_identifier_code { get; set; }
        public string bank_name { get; set; }
        public string bank_country_code { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public PaymentOption()
        {
            // Set values for instance variables
            this.name = null;
            this.account_reference = null;
            this.bank_identifier_code = null;
            this.bank_name = null;
            this.bank_country_code = null;

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