using System.Collections.Generic;
using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represent a travel expense claim
    /// </summary>
    public class AnnytabDoxTravelExpenseClaim
    {
        #region Variables

        public string personnel_id { get; set; }
        public string name { get; set; }
        public string cost_center { get; set; }
        public string currency_code { get; set; }
        public string trip_purpose { get; set; }
        public string destination { get; set; }
        public string departure_date { get; set; } // yyyy-MM-ddThh:mm:ss
        public string return_date { get; set; } // yyyy-MM-ddThh:mm:ss
        public IList<TravelExpenseRow> expense_rows { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public AnnytabDoxTravelExpenseClaim()
        {
            // Set values for instance variables
            this.personnel_id = null;
            this.name = null;
            this.cost_center = null;
            this.currency_code = null;
            this.trip_purpose = null;
            this.destination = null;
            this.departure_date = null;
            this.return_date = null;
            this.expense_rows = null;

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