using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represents a vat specification
    /// </summary>
    public class VatSpecification
    {
        #region Variables

        public decimal tax_rate { get; set; }
        public decimal taxable_amount { get; set; }
        public decimal tax_amount { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public VatSpecification()
        {
            // Set values for instance variables
            this.tax_rate = 0M;
            this.taxable_amount = 0M;
            this.tax_amount = 0M;

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