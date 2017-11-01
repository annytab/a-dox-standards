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
        public decimal total_weight_kg { get; set; }
        public decimal penalty_interest { get; set; }
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
        public decimal subtotal { get; set; }
        public decimal discount { get; set; }
        public decimal vat_total { get; set; }
        public decimal rounding { get; set; }
        public decimal total { get; set; }
        public decimal paid_amount { get; set; }
        public decimal balance_due { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public AnnytabDoxTrade()
        {
            // Set values for instance variables
            this.id = "";
            this.document_type = "";
            this.payment_reference = "";
            this.issue_date = "2000-01-01";
            this.due_date = "2000-01-01";
            this.delivery_date = "2000-01-01";
            this.seller_references = new Dictionary<string, string>();
            this.buyer_references = new Dictionary<string, string>();
            this.terms_of_delivery = "";
            this.terms_of_payment = "";
            this.mode_of_delivery = "";
            this.total_weight_kg = 0M;
            this.penalty_interest = 0M;
            this.currency_code = "";
            this.vat_country_code = "";
            this.vat_state_code = "";
            this.comment = "";
            this.seller_information = new PartyInformation();
            this.buyer_information = new PartyInformation();
            this.delivery_information = new PartyInformation();
            this.payment_options = new List<PaymentOption>();
            this.product_rows = new List<ProductRow>();
            this.vat_specification = new List<VatSpecification>();
            this.subtotal = 0M;
            this.discount = 0M;
            this.vat_total = 0M;
            this.rounding = 0M;
            this.total = 0M;
            this.paid_amount = 0M;
            this.balance_due = 0M;

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