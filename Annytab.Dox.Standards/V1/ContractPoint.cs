﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Annytab.Dox.Standards.V1
{
    /// <summary>
    /// This class represent a contract point
    /// </summary>
    public class ContractPoint
    {
        #region Variables

        public string id { get; set; }
        public string text_html { get; set; }
        public IList<ContractPoint> sections { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new post with default properties
        /// </summary>
        public ContractPoint()
        {
            // Set values for instance variables
            this.id = "";
            this.text_html = "";
            this.sections = new List<ContractPoint>();

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