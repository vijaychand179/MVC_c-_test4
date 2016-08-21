using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.SportScotland
{
    /// <summary>
    /// IImpact
    /// </summary>
    public interface IImpact
    {
        /// <summary>
        /// To get all impacts
        /// </summary>
        /// <returns>Impacts list</returns>
        List<Impact> GetImpacts();
        /// <summary>
        /// To get impact based on id
        /// </summary>
        /// <param name="id">impactId</param>
        /// <returns>Impact</returns>
        Impact GetImpactById(int id);
        /// <summary>
        /// To add impact
        /// </summary>
        /// <param name="impact">Impact</param>
        /// <returns>status</returns>
        bool AddImpact(Impact impact);
        /// <summary>
        /// To edit impact
        /// </summary>
        /// <param name="impact">Impact</param>
        /// <returns>status</returns>
        bool EditImpact(Impact impact);
    }
}
