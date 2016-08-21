using System;
using DL.SportScotland;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SportScotland.Tests
{
    [TestClass]
    public class ImpactRecordRepos
    {
        [TestMethod]
        public void GetImpactRecordTest()
        {
            IImpactRecord iImpact = new ImpactRecordRepository();
            var result = iImpact.GetImpactRecord(1);
            Assert.IsInstanceOfType(result, typeof(ImpactRecord));
        }
    }
}
