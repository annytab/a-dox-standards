using System.Collections.Generic;
using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represent a product row
    /// </summary>
    public class ProductRow
    {
        #region Variables

        public string product_code { get; set; }
        public string manufacturer_code { get; set; }
        public string gtin { get; set; }
        public string product_name { get; set; }
        public decimal vat_rate { get; set; }
        public decimal quantity { get; set; }
        public string unit_code { get; set; }
        public decimal unit_price { get; set; }
        public IList<ProductRow> subrows { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public ProductRow()
        {
            // Set values for instance variables
            this.product_code = "";
            this.manufacturer_code = "";
            this.gtin = "";
            this.product_name = "";
            this.vat_rate = 0;
            this.quantity = 0;
            this.unit_code = "";
            this.unit_price = 0;
            this.subrows = new List<ProductRow>();

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