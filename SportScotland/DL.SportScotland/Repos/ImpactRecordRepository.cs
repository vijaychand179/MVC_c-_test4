using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.SportScotland
{
    public class ImpactRecordRepository : IImpactRecord
    {
        private SportScotlandDevEntities _entities = new SportScotlandDevEntities();

        /// <summary>
        /// To get impact record by id
        /// </summary>
        /// <param name="impactId">impactId</param>
        /// <returns>ImpactRecord</returns>
        public ImpactRecord GetImpactRecord(int impactId)
        {
            var impactRecordDetails = _entities.ImpactRecords.Where(x => x.ImpactId == impactId).FirstOrDefault();
            return impactRecordDetails;
        }

        /// <summary>
        /// To save impact record
        /// </summary>
        /// <param name="impactId">impactId</param>
        /// <param name="others">others(new impact)</param>
        /// <param name="impactRecord">impactRecord</param>
        /// <param name="impactRecordId">impactRecordId</param>
        /// <returns>status</returns>
        public bool SaveImpactRecord(int impactId, string others, ImpactRecord impactRecord, out int impactRecordId)
        {            
            int result = 0;
            //Check for new Impact. If so, create new impact and get the id
            if (impactId == 0)
            {
                Impact newImpact = new Impact();
                newImpact.ImpactName = others;
                _entities.Impacts.Add(newImpact);
                _entities.SaveChanges();
                impactId = newImpact.ImpactId;
            }
            impactRecord.ImpactId = impactId;
            //Get imapact record for ImpactId
            var impactRecordData = GetImpactRecord(impactId);
            //If record is null then add else update
            if (impactRecordData == null)
            {
                _entities.ImpactRecords.Add(impactRecord);
                result = _entities.SaveChanges();
                impactRecordId = impactRecord.ImpactRecordId;//get the added record id for impact individual
            }
            else
            {
                impactRecordData.EndDate = impactRecord.EndDate;
                impactRecordData.StartDate = impactRecord.StartDate;
                impactRecordData.Notes = impactRecord.Notes;
                result = _entities.SaveChanges();
                impactRecordId = impactRecordData.ImpactRecordId;//get the updated record id for impact individual
            }
            return result > 0 ? true : false;
        }
    }
}
