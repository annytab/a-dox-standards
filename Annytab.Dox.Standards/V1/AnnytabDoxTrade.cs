using System.Collections.Generic;
using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represent a ecommerce document
    /// </summary>
    public class AnnytabDoxTrade
    {
        #region Variables

        public string id { get; set; }
        public string document_type { get; set; }
        public string payment_reference { get; set; }
        public string issue_date { get; set; }
        public string due_date { get; set; }
        public string delivery_date { get; set; }
        public IDictionary<string, string> seller_references { get; set; }
        public IDictionary<string, string> buyer_references { get; set; }
        public string terms_of_delivery { get; set; }
        public string terms_of_payment { get; set; }
        public string mode_of_delivery { get; set; }
        public decimal? total_weight_kg { get; set; }
        public decimal? penalty_interest { get; set; }
        public string currency_code { get; set; }
        public string vat_country_code { get; set; }
        public string vat_state_code { get; set; }
        public string comment { get; set; }
        public PartyInformation seller_information { get; set; }
        public PartyInformation buyer_information { get; set; }
        public PartyInformation delivery_information { get; set; }
        public IList<PaymentOption> payment_options { get; set; }
        public IList<ProductRow> product_rows { get; set; }
        public IList<VatSpecification> vat_specification { get; set; }
        public decimal? subtotal { get; set; }
        public decimal? discount { get; set; }
        public decimal? vat_total { get; set; }
        public decimal? rounding { get; set; }
        public decimal? total { get; set; }
        public decimal? paid_amount { get; set; }
        public decimal? balance_due { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public AnnytabDoxTrade()
        {
            // Set values for instance variables
            this.id = null;
            this.document_type = null;
            this.payment_reference = null;
            this.issue_date = null;
            this.due_date = null;
            this.delivery_date = null;
            this.seller_references = null;
            this.buyer_references = null;
            this.terms_of_delivery = null;
            this.terms_of_payment = null;
            this.mode_of_delivery = null;
            this.total_weight_kg = null;
            this.penalty_interest = null;
            this.currency_code = null;
            this.vat_country_code = null;
            this.vat_state_code = null;
            this.comment = null;
            this.seller_information = null;
            this.buyer_information = null;
            this.delivery_information = null;
            this.payment_options = null;
            this.product_rows = null;
            this.vat_specification = null;
            this.subtotal = null;
            this.discount = null;
            this.vat_total = null;
            this.rounding = null;
            this.total = null;
            this.paid_amount = null;
            this.balance_due = null;

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