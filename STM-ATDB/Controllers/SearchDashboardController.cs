using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using STM.ATDB.Model.Transaction;
using STM.ATDB.MvcWeb.App_Helpers;
using STM.ATDB.MvcWeb.Models;
using STM.ATDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace STM.ATDB.MvcWeb.Controllers
{
    public class SearchDashboardController : SECBaseController
    {
        // GET: SearchDashboard
        public ActionResult Index()
        {
            return View();
        }

        private ICommonService CommonService;
        private IMasterService MasterService;
        private ITransactionService TransactionService;
        public SearchDashboardController(ICommonService commonService, IMasterService masterService, ITransactionService transactionService)
        {
            this.CommonService = commonService;
            this.MasterService = masterService;
            this.TransactionService = transactionService;
        }

        public ActionResult GetDivisionComboData(DataSourceLoadOptions loadOptions)
        {
            DivisionCriteria cri = new DivisionCriteria();
            cri.ProdDate = this.CommonService.GetProductionDate();
            cri.UserCode = UserDetail.UserID;

            //test
            //cri.UserCode = "3570";

            var divisions = this.TransactionService.GetDivisionCombo(cri);

            //divisions.Insert(0, new GetDivisionCombo_Result() { DivCode = null, DivCodeDisplay = "--Select--",DivName= "--Select--" });

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(divisions, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        [HttpGet]
        public ActionResult GetDepartmentComboData(DataSourceLoadOptions loadOptions,string strDivCode)
        {
            DepartmentCriteria cri = new DepartmentCriteria();
            cri.ProdDate = this.CommonService.GetProductionDate();
            cri.DivCode = string.IsNullOrWhiteSpace(strDivCode)? null :strDivCode;
            cri.UserCode = UserDetail.UserID;

            //test
            //cri.UserCode = "3570";

            var department = this.TransactionService.GetDepartmentCombo(cri);

            //department.Insert(0, new GetDepartmentCombo_Result() { DeptCode = null, DeptName = "--Select--" });

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(department, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        [HttpGet]
        public ActionResult GetSectionComboData(DataSourceLoadOptions loadOptions,string strDeptCode)
        {
            SectionCriteria cri = new SectionCriteria();
            cri.ProdDate = this.CommonService.GetProductionDate();
            cri.DeptCode = string.IsNullOrWhiteSpace(strDeptCode) ? null : strDeptCode;
            cri.UserCode = UserDetail.UserID;

            //test
            //cri.UserCode = "3570";

            var Sections = this.TransactionService.GetSectionCombo(cri);

            //Sections.Insert(0, new GetSectionCombo_Result() { SecCode = null, SecCodeDisplay = "--Select--"});

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(Sections, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        }

        class testModel
        {
           public string id { get; set; }
        }

        [HttpPost]
        public ActionResult CallDisplayFrist(string values ,string DivCode,string DeptCode,string SecCode)
        {
            DailyAttendanceDashboardViewModel viewModel = new DailyAttendanceDashboardViewModel();
            if (!string.IsNullOrWhiteSpace(DivCode))
            {
                viewModel.Division = DivCode;
                viewModel.Department = string.IsNullOrWhiteSpace(DeptCode) ? null : DeptCode;
                viewModel.Section = string.IsNullOrWhiteSpace(SecCode) ? null : SecCode;

                TempData["ADS010ViewModel"] = viewModel;
                //TempData["AlertMessage"] = "test";
                //ViewBag.TestMsg = "test";
                //return new HttpStatusCodeResult(HttpStatusCode.OK);
                testModel tem = new testModel();
                string strDateTimeNow = String.Format("{0:ddMMyyyyHHmmsss}", DateTime.Now);
                string idGen = strDateTimeNow;
                tem.id = Convert.ToBase64String(Encoding.UTF8.GetBytes(idGen));
                return Json(tem,JsonRequestBehavior.AllowGet);
            }
            else
                return null;
        }

    }
}