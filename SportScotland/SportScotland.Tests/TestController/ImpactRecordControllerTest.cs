using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportScotland.Controllers;
using Moq;
using DL.SportScotland;
using System.Web.Mvc;

namespace SportScotland.Tests
{
    /// <summary>
    /// ImpactRecordControllerTest
    /// </summary>
    [TestClass]
    public class ImpactRecordControllerTest
    {
        private Mock<IImpact> _iImpact = new Mock<IImpact>();
        private Mock<IImpactRecord> _iImpactRecord = new Mock<IImpactRecord>();
        private Mock<IImpctRecordBeneficiary> _iImpactRcdBfry = new Mock<IImpctRecordBeneficiary>();
        private Mock<IBenificiary> _iBeneficiary = new Mock<IBenificiary>();

        [TestMethod]
        public void LoadImpactRecordTest()
        {
            ImpactRecordController impRcdCtrl = new ImpactRecordController(_iImpact.Object, _iBeneficiary.Object, _iImpactRecord.Object, _iImpactRcdBfry.Object);
            var result = impRcdCtrl.LoadImpactRecord() as ViewResult;
            Assert.AreEqual("ImpactRecord", result.ViewName, true);
        }

        [TestMethod]
        public void GetImpactRecordTest()
        {
            ImpactRecordController impRcdCtrl = new ImpactRecordController(_iImpact.Object, _iBeneficiary.Object, _iImpactRecord.Object, _iImpactRcdBfry.Object);
            _iImpact.Setup(r => r.GetImpacts()).Returns(new List<Impact>());
            _iBeneficiary.Setup(r => r.GetBenificiaries()).Returns(new List<Benificiary>());
            _iImpactRecord.Setup(r => r.GetImpactRecord(0)).Returns(new ImpactRecord());
            _iImpactRcdBfry.Setup(r => r.GetImpactRecordBeneficiaries(0)).Returns(new List<ImpactRecordBenificiary>());
            var result = impRcdCtrl.GetImpactRecord() as JsonResult;
            Assert.IsInstanceOfType(result.Data, typeof(ImpactRecordModel));
        }
    }
}
