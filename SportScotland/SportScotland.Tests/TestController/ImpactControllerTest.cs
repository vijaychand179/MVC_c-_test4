using System;
using System.Web.Mvc;
using DL.SportScotland;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportScotland.Controllers;

namespace SportScotland.Tests
{
    [TestClass]
    public class ImpactControllerTest
    {
        private Mock<IImpact> _value = new Mock<IImpact>();

        /// <summary>
        /// GetAllImpactsTest
        /// </summary>
        [TestMethod]
        public void GetAllImpactsTest()
        {
            ImpactController impCtrl = new ImpactController(_value.Object);
            var result = impCtrl.GetAllImpacts() as ViewResult;
            Assert.AreEqual("Impacts", result.ViewName, true);
        }

        /// <summary>
        /// GetAllImpactsForAddTest
        /// </summary>
        [TestMethod]
        public void AddNewImpactScreenTest()
        {
            //for add
            int id = 0;
            ImpactController impCtrl = new ImpactController(_value.Object);
            var result = impCtrl.AddImpact(id) as ViewResult;
            Assert.AreEqual("AddImpact", result.ViewName, true);
        }

        /// <summary>
        /// GetAllImpactsForEditTest
        /// </summary>
        [TestMethod]
        public void EditImpactScreenTest()
        {
            //for edit
            int id = 2;
            ImpactController impCtrl = new ImpactController(_value.Object);
            var result = impCtrl.AddImpact(id) as ViewResult;
            Assert.AreEqual("AddImpact", result.ViewName, true);
        }

        /// <summary>
        /// To test save impact
        /// </summary>
        [TestMethod]
        public void SaveImpactTest()
        {
            //for add
            Impact impact = new Impact();
            impact.ImpactName = "ImpactTest2";
            ImpactController impCtrl = new ImpactController(_value.Object);
            var result = impCtrl.SaveImpact(impact) as RedirectToRouteResult;
            var actionName = result.RouteValues["action"] != null ? result.RouteValues["action"].ToString() : string.Empty;
            Assert.AreEqual("GetAllImpacts", actionName, true);
        }
    }
}
