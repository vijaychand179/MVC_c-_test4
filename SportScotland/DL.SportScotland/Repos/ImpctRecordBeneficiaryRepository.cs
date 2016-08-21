using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.SportScotland
{
    /// <summary>
    /// ImpctRecordBeneficiaryRepository
    /// </summary>
    public class ImpctRecordBeneficiaryRepository : IImpctRecordBeneficiary
    {
        private SportScotlandDevEntities _entities = new SportScotlandDevEntities();

        /// <summary>
        /// To get Impact and beneficiary details
        /// </summary>
        /// <param name="impactRecordId">impactRecordId</param>
        /// <returns>ist of ImpactRecordBenificiary</returns>
        public List<ImpactRecordBenificiary> GetImpactRecordBeneficiaries(int impactRecordId)
        {
            var impactRcdBnf = _entities.ImpactRecordBenificiaries.Where(x => x.ImpactRecord.ImpactRecordId == impactRecordId).ToList();
            return impactRcdBnf;
        }

        /// <summary>
        /// To save Impact and beneficiary details
        /// </summary>
        /// <param name="beneficiaryIds">iist of beneficiaryIds</param>
        /// <param name="impactRecordId">impactRecordId</param>
        /// <returns>status</returns>
        public bool SaveImpactRecordBeneficiaries(List<int> beneficiaryIds, int impactRecordId)
        {
            var records = _entities.ImpactRecordBenificiaries.Where(x => x.ImpactRecordId == impactRecordId).ToList();
            //remove existing records
            foreach(var record in records)
            {
                _entities.ImpactRecordBenificiaries.Remove(record);
            }
            //create new records
            foreach (var beneficiaryId in beneficiaryIds)
            {
                ImpactRecordBenificiary impBnf = new ImpactRecordBenificiary();
                impBnf.ImpactRecordId = impactRecordId;
                impBnf.BenificiaryId = beneficiaryId;
                _entities.ImpactRecordBenificiaries.Add(impBnf);
            }
            int result = _entities.SaveChanges();
            return result > 0 ? true : false;
        }
    }
}
