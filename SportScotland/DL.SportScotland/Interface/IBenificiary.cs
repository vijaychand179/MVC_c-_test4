using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.SportScotland
{
    /// <summary>
    /// IBenificiary
    /// </summary>
    public interface IBenificiary
    {
        /// <summary>
        /// To get beneficiary list
        /// </summary>
        /// <returns>beneficiary list</returns>
        List<Benificiary> GetBenificiaries();
    }
}
