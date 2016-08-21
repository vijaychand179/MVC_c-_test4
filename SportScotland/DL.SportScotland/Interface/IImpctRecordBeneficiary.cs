using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.SportScotland
{
    /// <summary>
    /// IImpctRecordBeneficiary
    /// </summary>
    public interface IImpctRecordBeneficiary
    {
        /// <summary>
        /// To get Impact and beneficiary details
        /// </summary>
        /// <param name="impactRecordId">impactRecordId</param>
        /// <returns>list of ImpactRecordBenificiary</returns>
        List<ImpactRecordBenificiary> GetImpactRecordBeneficiaries(int impactRecordId);
        /// <summary>
        /// To save Impact and beneficiary details
        /// </summary>
        /// <param name="beneficiaryIds">iist of beneficiaryIds</param>
        /// <param name="impactRecordId">impactRecordId</param>
        /// <returns>status</returns>
        bool SaveImpactRecordBeneficiaries(List<int> beneficiaryIds, int impactRecordId);
    }
}
