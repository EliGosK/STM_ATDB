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
    public class HideOrganizationController : SECBaseController
    {
        private IMasterService MasterService;

        public HideOrganizationController(IMasterService masterService)
        {
            this.MasterService = masterService;
        }

        [ApplicationAuthorize("MAS020", "VIEW")]
        public ActionResult Index()
        {
            return View(new HideOrganizationViewModel());
        }

        [System.Web.Http.HttpGet]
        public ActionResult SearchHideOrganization(DataSourceLoadOptions loadOptions, HideOrganizationCriteria criteria)
        {
            try
            {
                List<HideOrganizationViewModel> result = new List<HideOrganizationViewModel>();
                if (!criteria.isFirstLoad)
                {
                    result = MasterService.SearchHideOrganization(criteria).ToModels();
                }

                return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(result, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertHideOrganization(DataSourceLoadOptions loadOptions, string value)
        {
            try
            {
                var newHideOrganization = new HideOrganizationViewModel();
                JsonConvert.PopulateObject(value, newHideOrganization);

                ValidateModel(newHideOrganization);
                if (!ModelState.IsValid)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

                newHideOrganization.UpdateBy = UserDetail.UserID;
                SaveHideOrgResult result = MasterService.SaveHideorganization(newHideOrganization.ToEntity(), ConstantValues.ADD);

                return Content(JsonConvert.SerializeObject(GetMsgFromInsertUpdateActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateHideOrganization(DataSourceLoadOptions loadOptions, string value)
        {
            try
            {
                var editHideOrganization = new HideOrganizationViewModel();
                JsonConvert.PopulateObject(value, editHideOrganization);

                ValidateModel(editHideOrganization);
                if (!ModelState.IsValid)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

                editHideOrganization.UpdateBy = UserDetail.UserID;
                SaveHideOrgResult result = MasterService.SaveHideorganization(editHideOrganization.ToEntity(), ConstantValues.EDIT);

                return Content(JsonConvert.SerializeObject(GetMsgFromInsertUpdateActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DeleteHideOrganization(DataSourceLoadOptions loadOptions, string value)
        {
            try
            {
                var deleteHideOrganization = new HideOrganizationViewModel();
                JsonConvert.PopulateObject(value, deleteHideOrganization);

                deleteHideOrganization.UpdateBy = UserDetail.UserID;
                DeleteHideOrgResult result = MasterService.DeleteHideOrganization(deleteHideOrganization.ToEntity());

                return Content(JsonConvert.SerializeObject(GetMsgFromDeleteActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SaveHideOrgResult GetMsgFromInsertUpdateActionResult(SaveHideOrgResult result)
        {
            try
            {
                if (result.ErrorCode == "0")
                    result.ErrorMessage = MessageListResource.I0001;
                else if (result.ErrorCode == "1")
                    result.ErrorMessage = String.Format(MessageListResource.W0005, "Hide Organization", "Hide Date");
                else if (result.ErrorCode == "2")
                    result.ErrorMessage = String.Format(MessageListResource.E0005, "Hide Organization");
                else if (result.ErrorCode == "9")
                    result.ErrorMessage = String.Format(MessageListResource.E0003, "save", result.ErrorMessage);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DeleteHideOrgResult GetMsgFromDeleteActionResult(DeleteHideOrgResult result)
        {
            try
            {
                if (result.ErrorCode == "0")
                    result.ErrorMessage = MessageListResource.I0002;
                else if (result.ErrorCode == "1")
                    result.ErrorMessage = String.Format(MessageListResource.E0004, "Hide Organization");
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