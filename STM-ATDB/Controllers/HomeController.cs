using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using STM.ATDB.Core;
using STM.ATDB.Model.Transaction;
using STM.ATDB.MvcWeb.App_Helpers;
using STM.ATDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.ATDB.MvcWeb.Controllers
{
    [Authorize]
    public class HomeController : SECBaseController
    {
        private ITransactionService TransactionService;

        public HomeController(ITransactionService transactionService)
        {
            this.TransactionService = transactionService;
        }

        public ActionResult Index() {
            //return View();
            return RedirectToAction("Index", "SearchDashboard");
        }


        //[HttpGet]
        //public ActionResult GetTotalEmployeeChart(DataSourceLoadOptions loadOptions, ChartCriteria criteria)
        //{
        //    criteria.ChartDate = CommonUtils.JSONToObject<DateTime>(criteria.ChartDateString);

        //    criteria.Company = (criteria.Company == ConstantValues.AllValue ? null : criteria.Company);
        //    criteria.StaffRole = (criteria.StaffRole == ConstantValues.AllValue ? null : criteria.StaffRole);
        //    criteria.Plant = (criteria.Plant == ConstantValues.AllValue ? null : criteria.Plant);
        //    criteria.Location = (criteria.Location == ConstantValues.AllValue ? null : criteria.Location);

        //    criteria.UserID = UserDetail.UserID;

        //    List<TotalEmployeePieChartData> lResult = new List<TotalEmployeePieChartData>();
        //    foreach (var item in TransactionService.GetTotalEmployeeChartData(criteria))
        //    {
        //        lResult.Add(AutoMapper.Mapper.Map<TotalEmployeePieChartData>(item));
        //    }

        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(lResult, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}

        //[HttpGet]
        //public ActionResult GetTotalEmployeeWorkingChart(DataSourceLoadOptions loadOptions, ChartCriteria criteria)
        //{
        //    criteria.ChartDate = CommonUtils.JSONToObject<DateTime>(criteria.ChartDateString);
        //    criteria.Company = (criteria.Company == ConstantValues.AllValue ? null : criteria.Company);
        //    criteria.StaffRole = (criteria.StaffRole == ConstantValues.AllValue ? null : criteria.StaffRole);
        //    criteria.Plant = (criteria.Plant == ConstantValues.AllValue ? null : criteria.Plant);
        //    criteria.Location = (criteria.Location == ConstantValues.AllValue ? null : criteria.Location);

        //    criteria.UserID = UserDetail.UserID;

        //    List<TotalEmployeeWorkingData> lResult = new List<TotalEmployeeWorkingData>();
        //    foreach (var item in TransactionService.GetTotalEmployeeWorkingChartData(criteria))
        //    {
        //        lResult.Add(AutoMapper.Mapper.Map<TotalEmployeeWorkingData>(item));
        //    }
        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(lResult, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}

        //[HttpGet]
        //public ActionResult GetTotalEmployeeReplaceChart(DataSourceLoadOptions loadOptions, ChartCriteria criteria)
        //{
        //    criteria.ChartDate = CommonUtils.JSONToObject<DateTime>(criteria.ChartDateString);
        //    criteria.Company = (criteria.Company == ConstantValues.AllValue ? null : criteria.Company);
        //    criteria.StaffRole = (criteria.StaffRole == ConstantValues.AllValue ? null : criteria.StaffRole);
        //    criteria.Plant = (criteria.Plant == ConstantValues.AllValue ? null : criteria.Plant);
        //    criteria.Location = (criteria.Location == ConstantValues.AllValue ? null : criteria.Location);

        //    criteria.UserID = UserDetail.UserID;

        //    List<TotalEmployeeReplaceData> lResult = new List<TotalEmployeeReplaceData>();
        //    foreach (var item in TransactionService.GetTotalEmployeeReplaceChartData(criteria))
        //    {
        //        lResult.Add(AutoMapper.Mapper.Map<TotalEmployeeReplaceData>(item));
        //    }

        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(lResult, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}

        //[HttpGet]
        //public ActionResult GetTotalEmployeeWorkingPlantChart(DataSourceLoadOptions loadOptions, ChartCriteria criteria)
        //{
        //    criteria.ChartDate = CommonUtils.JSONToObject<DateTime>(criteria.ChartDateString);
        //    criteria.Company = (criteria.Company == ConstantValues.AllValue ? null : criteria.Company);
        //    criteria.StaffRole = (criteria.StaffRole == ConstantValues.AllValue ? null : criteria.StaffRole);
        //    criteria.Plant = (criteria.Plant == ConstantValues.AllValue ? null : criteria.Plant);
        //    criteria.Location = (criteria.Location == ConstantValues.AllValue ? null : criteria.Location);

        //    criteria.UserID = UserDetail.UserID;

        //    List<TotalEmployeeWorkingPlant> lResult = new List<TotalEmployeeWorkingPlant>();
        //    foreach (var item in TransactionService.GetTotalEmployeeWorkingPlantChartData(criteria))
        //    {
        //        lResult.Add(AutoMapper.Mapper.Map<TotalEmployeeWorkingPlant>(item));
        //    }


        //    return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(lResult, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
        //}
    }
}