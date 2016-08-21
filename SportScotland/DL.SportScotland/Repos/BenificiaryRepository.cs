using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.SportScotland
{
    /// <summary>
    /// BenificiaryRepository
    /// </summary>
    public class BenificiaryRepository : IBenificiary
    {
        private SportScotlandDevEntities _entities = new SportScotlandDevEntities();

        /// <summary>
        /// To get all beneficiaries
        /// </summary>
        /// <returns>list of beneficiaries</returns>
        public List<Benificiary> GetBenificiaries()
        {
            var benficiarDetails = _entities.Benificiaries.ToList();
            return benficiarDetails;
        }
    }
}
