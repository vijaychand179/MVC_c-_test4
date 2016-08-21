using System;
using System.Collections.Generic;
using DL.SportScotland;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SportScotland.Tests
{
    [TestClass]
    public class BenificiaryRepoTest
    {
        [TestMethod]
        public void GetBenificiariesTest()
        {
            IBenificiary iBeneficiary = new BenificiaryRepository();
            var result = iBeneficiary.GetBenificiaries();
            Assert.IsInstanceOfType(result, typeof(List<Benificiary>));
        }
    }
}
