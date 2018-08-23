using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represent a drive log row
    /// </summary>
    public class DriveLogRow
    {
        #region Variables

        public decimal? start_odometer { get; set; }
        public string start_time { get; set; } // yyyy-MM-ddThh:mm:ss
        public string from { get; set; }
        public decimal? end_odometer { get; set; }
        public string end_time { get; set; } // yyyy-MM-ddThh:mm:ss
        public string to { get; set; }
        public string description { get; set; }
        public bool? business_trip { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public DriveLogRow()
        {
            // Set values for instance variables
            this.start_odometer = null;
            this.start_time = null;
            this.from = null;
            this.end_odometer = null;
            this.end_time = null;
            this.to = null;
            this.description = null;
            this.business_trip = null;

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