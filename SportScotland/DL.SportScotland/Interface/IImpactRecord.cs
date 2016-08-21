using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.SportScotland
{
    /// <summary>
    /// IImpactRecord
    /// </summary>
    public interface IImpactRecord
    {
        /// <summary>
        /// To get Impact details by Id
        /// </summary>
        /// <param name="impactId">impactId</param>
        /// <returns>ImpactRecord</returns>
        ImpactRecord GetImpactRecord(int impactId);
        /// <summary>
        /// To save impact record
        /// </summary>
        /// <param name="impactId">impactId</param>
        /// <param name="others">others(new impact)</param>
        /// <param name="impactRecord">impactRecord</param>
        /// <param name="impactRecordId">impactRecordId</param>
        /// <returns>Status</returns>
        bool SaveImpactRecord(int impactId, string others, ImpactRecord impactRecord, out int impactRecordId);
    }
}
