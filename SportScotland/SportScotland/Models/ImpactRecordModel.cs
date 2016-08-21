using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DL.SportScotland;

namespace SportScotland
{
    /// <summary>
    /// ImpactRecordModel
    /// </summary>
    public class ImpactRecordModel
    {
        /// <summary>
        /// Gets or Sets Impacts
        /// </summary>
        public List<ImpactModel> Impacts { get; set; }
        /// <summary>
        /// Gets or Sets ImpactId
        /// </summary>
        public int ImpactId { get; set; }
        /// <summary>
        /// Gets or Sets Others
        /// </summary>
        public string Others { get; set; }
        /// <summary>
        /// Gets or Sets ImpactRecord
        /// </summary>
        public IndividualImpactRecordModel ImpactRecord { get; set; }
        /// <summary>
        /// Gets or Sets Benificiaries
        /// </summary>
        public List<BenificiaryModel> Benificiaries { get; set; }
        /// <summary>
        /// Gets or Sets BenificiaryId
        /// </summary>
        public int BenificiaryId { get; set; }
        /// <summary>
        /// Gets or Sets AddedBenificiaries
        /// </summary>
        public List<BenificiaryModel> AddedBenificiaries { get; set; }

    }
}