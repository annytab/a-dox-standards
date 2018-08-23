using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represent a travel expense row
    /// </summary>
    public class TravelExpenseRow
    {
        #region Variables

        public string code { get; set; }
        public string description { get; set; }
        public decimal? quantity { get; set; }
        public string unit_code { get; set; }
        public decimal? unit_price { get; set; }
        public decimal? vat_amount { get; set; }
        public string comment { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public TravelExpenseRow()
        {
            // Set values for instance variables
            this.code = null;
            this.description = null;
            this.quantity = null;
            this.unit_code = null;
            this.unit_price = null;
            this.vat_amount = null;
            this.comment = null;

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