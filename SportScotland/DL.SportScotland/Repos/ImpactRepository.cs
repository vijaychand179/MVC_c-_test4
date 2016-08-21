using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.SportScotland
{
    /// <summary>
    /// ImpactRepository
    /// </summary>
    public class ImpactRepository : IImpact
    {
        private SportScotlandDevEntities _entities = new SportScotlandDevEntities();

        /// <summary>
        /// To get all impacts
        /// </summary>
        /// <returns>Impacts list</returns>
        public List<Impact> GetImpacts()
        {
            var impactDetails = _entities.Impacts.ToList();
            return impactDetails;
        }

        /// <summary>
        /// To get impact based on id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Impact</returns>
        public Impact GetImpactById(int id)
        {
            var impactDetails = _entities.Impacts.Where(x=>x.ImpactId == id).FirstOrDefault();
            return impactDetails;
        }

        /// <summary>
        /// To add impact
        /// </summary>
        /// <param name="impact">impact</param>
        /// <returns>status</returns>
        public bool AddImpact(Impact impact)
        {
            _entities.Impacts.Add(impact);
            int result = _entities.SaveChanges();
            return result > 0 ? true : false;
        }

        /// <summary>
        /// To edit impact
        /// </summary>
        /// <param name="impact">impact</param>
        /// <returns>status</returns>
        public bool EditImpact(Impact impact)
        {
            var impactDetail = _entities.Impacts.Where(x => x.ImpactId == impact.ImpactId).FirstOrDefault();
            impactDetail.ImpactName = impact.ImpactName;
            int result = _entities.SaveChanges();
            return result > 0 ? true : false;
        }
    }
}
