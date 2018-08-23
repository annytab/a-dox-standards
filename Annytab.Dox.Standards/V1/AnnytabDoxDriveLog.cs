using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represent a drive log
    /// </summary>
    public class AnnytabDoxDriveLog
    {
        #region Variables

        public string personnel_id { get; set; }
        public string name { get; set; }
        public string cost_center { get; set; }
        public string registration_number { get; set; }
        public string unit_code { get; set; }
        public string start_date { get; set; } // yyyy-MM-ddThh:mm:ss
        public string end_date { get; set; } // yyyy-MM-ddThh:mm:ss
        public decimal? opening_odometer { get; set; }
        public IList<DriveLogRow> log_rows { get; set; }
        public decimal? ending_odometer { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public AnnytabDoxDriveLog()
        {
            // Set values for instance variables
            this.personnel_id = null;
            this.name = null;
            this.cost_center = null;
            this.registration_number = null;
            this.unit_code = null;
            this.start_date = null;
            this.end_date = null;
            this.opening_odometer = null;
            this.log_rows = null;
            this.ending_odometer = null;

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