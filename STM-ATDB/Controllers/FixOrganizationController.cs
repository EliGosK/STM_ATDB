using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Security;
using STM.ATDB.Framework.Identity;
using STM.ATDB.MvcWeb.Models;
using STM.ATDB.Services;
using System.Web.Mvc;
using STM.ATDB.MvcWeb.App_Helpers;
using Newtonsoft.Json;
using DevExtreme.AspNet.Data;
using System.Web.Http;
using DevExtreme.AspNet.Mvc;
using STM.ATDB.Model.Transaction;
using System.Collections.Generic;
using System.Net;
using System;
using STM.ATDB.MvcWeb.Resources;

namespace STM.ATDB.MvcWeb.Controllers
{
    public class FixOrganizationController : SECBaseController
    {
        private IMasterService MasterService;
        //private ICommonService CommonService;

        public FixOrganizationController(IMasterService masterService)
        {
            this.MasterService = masterService;
        }

        [ApplicationAuthorize("MAS030", "VIEW")]
        public ActionResult Index()
        {
            return View(new FixOrganizationViewModel());
        }

        [System.Web.Http.HttpGet]
        public ActionResult SearchFixOrganization(DataSourceLoadOptions loadOptions, FixOrganizationCriteria criteria)
        {
            try
            {
                List<FixOrganizationViewModel> result = new List<FixOrganizationViewModel>();
                if (!criteria.isFirstLoad)
                {
                    result = MasterService.SearchFixOrganization(criteria).ToModels();
                }

                return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(result, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertFixOrganization(DataSourceLoadOptions loadOptions, string value)
        {
            try
            {
                var newFixOrganization = new FixOrganizationViewModel();
                JsonConvert.PopulateObject(value, newFixOrganization);

                ValidateModel(newFixOrganization);
                if (!ModelState.IsValid)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

                newFixOrganization.UpdateBy = UserDetail.UserID;
                SaveFixOrgByEmpResult result = MasterService.SaveFixOrganization(newFixOrganization.ToEntity(), ConstantValues.ADD);

                return Content(JsonConvert.SerializeObject(GetMsgFromInsertUpdateActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateFixOrganization(DataSourceLoadOptions loadOptions, string value)
        {
            try
            {
                var newFixOrganization = new FixOrganizationViewModel();
                JsonConvert.PopulateObject(value, newFixOrganization);

                ValidateModel(newFixOrganization);
                if (!ModelState.IsValid)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

                newFixOrganization.UpdateBy = UserDetail.UserID;
                SaveFixOrgByEmpResult result = MasterService.SaveFixOrganization(newFixOrganization.ToEntity(), ConstantValues.EDIT);

                return Content(JsonConvert.SerializeObject(GetMsgFromInsertUpdateActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public ActionResult DeleteFixOrganization(DataSourceLoadOptions loadOptions, string value)
        {
            try
            {
                var deleteFixOrganization = new FixOrganizationViewModel();
                JsonConvert.PopulateObject(value, deleteFixOrganization);

                deleteFixOrganization.UpdateBy = UserDetail.UserID;
                DeleteFixOrgByEmpResult result = MasterService.DeleteFixOrganization(deleteFixOrganization.ToEntity());

                return Content(JsonConvert.SerializeObject(GetMsgFromDeleteActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SaveFixOrgByEmpResult GetMsgFromInsertUpdateActionResult(SaveFixOrgByEmpResult result)
        {
            try
            {
                if (result.ErrorCode == "0")
                    result.ErrorMessage = MessageListResource.I0001;
                else if (result.ErrorCode == "1")
                    result.ErrorMessage = String.Format(MessageListResource.W0005, "Fix Organization", "Effective Date");
                else if (result.ErrorCode == "2")
                    result.ErrorMessage = String.Format(MessageListResource.E0005, "Fix Organization");
                else if (result.ErrorCode == "9")
                    result.ErrorMessage = String.Format(MessageListResource.E0003, "save", result.ErrorMessage);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DeleteFixOrgByEmpResult GetMsgFromDeleteActionResult(DeleteFixOrgByEmpResult result)
        {
            try
            {
                if (result.ErrorCode == "0")
                    result.ErrorMessage = MessageListResource.I0002;
                else if (result.ErrorCode == "1")
                    result.ErrorMessage = String.Format(MessageListResource.E0004, "Fix Organization");
                else if (result.ErrorCode == "9")
                    result.ErrorMessage = String.Format(MessageListResource.E0003, "delete", result.ErrorMessage);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}