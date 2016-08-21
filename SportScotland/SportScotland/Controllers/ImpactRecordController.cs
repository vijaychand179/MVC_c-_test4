using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DL.SportScotland;

namespace SportScotland.Controllers
{
    /// <summary>
    /// ImpactRecordController
    /// </summary>
    [ExceptionHandler]
    public class ImpactRecordController : Controller
    {
        private IImpact _impactRepos;
        private IBenificiary _beneficiaryRepos;
        private IImpactRecord _impactRecordRepos;
        private IImpctRecordBeneficiary _impctRcdBnf;

        /// <summary>
        /// ImpactRecordController
        /// </summary>
        /// <param name="iImpact">iImpact</param>
        /// <param name="iBeneficiary">iBeneficiary</param>
        /// <param name="iImpactRecord">iImpactRecord</param>
        /// <param name="iImctBfry">iImctBfry</param>
        public ImpactRecordController(IImpact iImpact, IBenificiary iBeneficiary, IImpactRecord iImpactRecord, IImpctRecordBeneficiary iImctBfry)
        {
            _impactRepos = iImpact;
            _beneficiaryRepos = iBeneficiary;
            _impactRecordRepos = iImpactRecord;
            _impctRcdBnf = iImctBfry;
        }

        /// <summary>
        /// To view Impct record view
        /// </summary>
        /// <param name="id">Impact record id</param>
        /// <returns>View</returns>
        public ActionResult LoadImpactRecord(int id = 0)
        {
            return View("ImpactRecord");
        }

        /// <summary>
        /// To get individul impact records
        /// </summary>
        /// <param name="id">Impact record id</param>
        /// <returns></returns>
        public ActionResult GetImpactRecord(int id = 0)
        {
            ImpactRecordModel impactRecordModel = new ImpactRecordModel();
            impactRecordModel.Impacts = GetImpactData();
            impactRecordModel.Benificiaries = GetBenificiaryData();
            //add 'Others' field
            impactRecordModel.Impacts.Add(new ImpactModel
                {
                    ImpactId = 0,
                    ImpactName = "Others"
                });
            //Checks for id. if 0, then shows first record from list in dropdown, else shows requested record
            if (id == 0)
            {
                var record = impactRecordModel.Impacts.FirstOrDefault();
                impactRecordModel.ImpactId = record != null ? record.ImpactId : 0;
            }
            else
            {
                //if reuested record exists then ,show that else show 'others'
                var record = impactRecordModel.Impacts.Where(x => x.ImpactId == id).FirstOrDefault();
                impactRecordModel.ImpactId = record != null ? record.ImpactId : 0;
            }
            impactRecordModel.ImpactRecord = GetIndividualImpactData(impactRecordModel.ImpactId);
            var beneficiary = impactRecordModel.Benificiaries.FirstOrDefault();
            impactRecordModel.BenificiaryId = beneficiary != null ? beneficiary.BenificiaryId : 0;
            impactRecordModel.AddedBenificiaries = GetImpactBenificiaryData(impactRecordModel.ImpactRecord.ImpactRecordId);
            return Json(impactRecordModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// To save individual impact records
        /// </summary>
        /// <param name="impactRecord">Impact record model</param>
        /// <returns>Json data</returns>
        [HttpPost]
        public ActionResult SaveImpactRecord(ImpactRecordModel impactRecord)
        {
            int impactRecordId;
            _impactRecordRepos.SaveImpactRecord(impactRecord.ImpactId, impactRecord.Others, GetImpactRecord(impactRecord.ImpactRecord), out impactRecordId);
            //if we get impact record id then save beneficiary details else send 'fail' status
            if (impactRecordId > 0)
            {
                var beneficiarIds = impactRecord.AddedBenificiaries.Select(x => x.BenificiaryId).ToList();
                _impctRcdBnf.SaveImpactRecordBeneficiaries(beneficiarIds, impactRecordId);
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            return Json("Fail", JsonRequestBehavior.AllowGet);
        }

        #region privatemethods
        /// <summary>
        /// To get list of impacts
        /// </summary>
        /// <returns>Impacts list</returns>
        private List<ImpactModel> GetImpactData()
        {
            var impacts = _impactRepos.GetImpacts();
            return impacts.Select(x => new ImpactModel
            {
                ImpactId = x.ImpactId,
                ImpactName = x.ImpactName
            }).ToList();
        }

        /// <summary>
        /// To get beneficiary list
        /// </summary>
        /// <returns>beneficiary list</returns>
        private List<BenificiaryModel> GetBenificiaryData()
        {
            var benificiary = _beneficiaryRepos.GetBenificiaries();
            return benificiary.Select(x => new BenificiaryModel
            {
                BenificiaryId = x.BenificiaryId,
                BenificiaryDescription = x.BenificiaryDescription
            }).ToList();
        }

        /// <summary>
        /// To get individual impact details
        /// </summary>
        /// <param name="impactId">ImpactId</param>
        /// <returns>individual impact details</returns>
        private IndividualImpactRecordModel GetIndividualImpactData(int impactId)
        {
            IndividualImpactRecordModel individualImpactRecord = new IndividualImpactRecordModel();
            var impactRecord = _impactRecordRepos.GetImpactRecord(impactId);
            if (impactRecord != null)
            {
                individualImpactRecord.ImpactRecordId = impactRecord.ImpactRecordId;
                individualImpactRecord.StartDate = impactRecord.StartDate;
                individualImpactRecord.EndDate = impactRecord.EndDate;
                individualImpactRecord.Notes = impactRecord.Notes;
            }
            return individualImpactRecord;


        }

        /// <summary>
        /// To get the ImpactRecord 
        /// </summary>
        /// <param name="individualImpactRecord">individualImpactRecord</param>
        /// <returns>ImpactRecord</returns>
        private ImpactRecord GetImpactRecord(IndividualImpactRecordModel individualImpactRecord)
        {
            ImpactRecord impactRecord = new ImpactRecord();
            if (individualImpactRecord != null)
            {
                impactRecord.Notes = individualImpactRecord.Notes;
                impactRecord.StartDate = individualImpactRecord.StartDate;
                impactRecord.EndDate = individualImpactRecord.EndDate;
            }
            return impactRecord;
        }

        /// <summary>
        /// To get impact nd beneficiary records
        /// </summary>
        /// <param name="impactRecordId">impactRecordId</param>
        /// <returns>List of beneficiaries</returns>
        private List<BenificiaryModel> GetImpactBenificiaryData(int impactRecordId)
        {
            var impctBenf = _impctRcdBnf.GetImpactRecordBeneficiaries(impactRecordId);
            return impctBenf.Select(x => new BenificiaryModel
            {
                BenificiaryId = x.Benificiary.BenificiaryId,
                BenificiaryDescription = x.Benificiary.BenificiaryDescription
            }).ToList();
        }

        #endregion
    }
}
