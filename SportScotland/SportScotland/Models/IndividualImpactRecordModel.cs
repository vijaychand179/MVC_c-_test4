using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportScotland
{
    /// <summary>
    /// IndividualImpactRecordModel
    /// </summary>
    public class IndividualImpactRecordModel
    {
        /// <summary>
        /// Gets or Sets ImpactRecordId
        /// </summary>
        public int ImpactRecordId { get; set; }
        /// <summary>
        /// Gets or Sets Notes
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Gets or Sets StartDate
        /// </summary>
        public Nullable<int> StartDate { get; set; }
        /// <summary>
        /// Gets or Sets EndDate
        /// </summary>
        public Nullable<int> EndDate { get; set; }
    }
}