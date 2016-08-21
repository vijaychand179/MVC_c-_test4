using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DL.SportScotland;

namespace SportScotland.Controllers
{
    /// <summary>
    /// ImpactController
    /// </summary>
    [ExceptionHandler]
    public class ImpactController : Controller
    {
        private IImpact _impactRepos;

        /// <summary>
        /// ImpactController
        /// </summary>
        /// <param name="iImpact">iImpact</param>
        public ImpactController(IImpact iImpact)
        {
            _impactRepos = iImpact;
        }

        /// <summary>
        /// To get all Impacts
        /// </summary>
        /// <returns>View</returns>
        public ActionResult GetAllImpacts()
        {
            List<Impact> impactDetais = _impactRepos.GetImpacts();
            return View("Impacts", impactDetais);
        }

        /// <summary>
        /// To get Impact in add Impact screen
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>View</returns>
        public ActionResult AddImpact(int id = 0)
        {
            Impact impact = new Impact();
            if (id != 0)
            {
                impact = _impactRepos.GetImpactById(id);
            }
            return View("AddImpact", impact);
        }

        /// <summary>
        /// To add/edit impact
        /// </summary>
        /// <param name="impact">Impact details</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult SaveImpact(Impact impact)
        {
            var result = false;
            //Checks if it is new record or existing record
            if (impact.ImpactId == 0)//0 = new record
            {
                result = _impactRepos.AddImpact(impact);//add
            }
            else
            {
                result = _impactRepos.EditImpact(impact);//edit
            }
            return RedirectToAction("GetAllImpacts");
        }

    }
}
