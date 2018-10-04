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
    public class AssignWorkShiftController : SECBaseController
    {
        private IMasterService MasterService;
        //private ICommonService CommonService;

        public AssignWorkShiftController(IMasterService masterService)
        {
            this.MasterService = masterService;
        }

        [ApplicationAuthorize("MAS040", "VIEW")]
        public ActionResult Index()
        {
            return View(new AssignWorkShiftViewModel());
        }

        [System.Web.Http.HttpGet]
        public ActionResult SearchAssignWorkShift(DataSourceLoadOptions loadOptions, AssignWorkShiftCriteria criteria)
        {
            try
            {
                List<AssignWorkShiftViewModel> result = new List<AssignWorkShiftViewModel>();
                if (!criteria.isFirstLoad)
                {
                    criteria.prodDate = null;
                    result = MasterService.SearchAssignWorkShiftByEmp(criteria).ToModels();
                }

                return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(result, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public ActionResult InsertAssignWorkShift(DataSourceLoadOptions loadOptions, string value)
        {
            try
            {
                var newAssignWorkShift = new AssignWorkShiftViewModel();
                JsonConvert.PopulateObject(value, newAssignWorkShift);

                ValidateModel(newAssignWorkShift);
                if (!ModelState.IsValid)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

                newAssignWorkShift.UpdateBy = UserDetail.UserID;
                InsertWorkShiftByEmpResult result = MasterService.InsertAssignWorkShiftByEmp(newAssignWorkShift.ToEntity());

                return Content(JsonConvert.SerializeObject(GetMsgFromInsertActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateAssignWorkShift(DataSourceLoadOptions loadOptions, string value)
        {
            try
            {
                var updateAssignWorkShift = new AssignWorkShiftViewModel();
                JsonConvert.PopulateObject(value, updateAssignWorkShift);

                ValidateModel(updateAssignWorkShift);
                if (!ModelState.IsValid)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

                updateAssignWorkShift.UpdateBy = UserDetail.UserID;
                UpdateWorkShiftByEmpResult result = MasterService.UpdateAssignWorkShiftByEmp(updateAssignWorkShift.ToEntity());

                return Content(JsonConvert.SerializeObject(GetMsgFromUpdateActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DeleteAssignWorkShift(DataSourceLoadOptions loadOptions, string value)
        {
            try
            {
                var deleteAssignWorkShift = new AssignWorkShiftViewModel();
                JsonConvert.PopulateObject(value, deleteAssignWorkShift);

                deleteAssignWorkShift.UpdateBy = UserDetail.UserID;
                DeleteWorkShiftByEmpResult result = MasterService.DeleteAssignWorkShiftByEmp(deleteAssignWorkShift.ToEntity());

                return Content(JsonConvert.SerializeObject(GetMsgFromDeleteActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public InsertWorkShiftByEmpResult GetMsgFromInsertActionResult(InsertWorkShiftByEmpResult result)
        {
            try
            {
                if (result.ErrorCode == "0")
                    result.ErrorMessage = MessageListResource.I0001;
                else if (result.ErrorCode == "1")
                    result.ErrorMessage = String.Format(MessageListResource.E0008, result.ErrorMessage);
                else if (result.ErrorCode == "9")
                    result.ErrorMessage = String.Format(MessageListResource.E0003, "insert", result.ErrorMessage);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UpdateWorkShiftByEmpResult GetMsgFromUpdateActionResult(UpdateWorkShiftByEmpResult result)
        {
            try
            {
                if (result.ErrorCode == "0")
                    result.ErrorMessage = MessageListResource.I0001;
                else if (result.ErrorCode == "1")
                    result.ErrorMessage = String.Format(MessageListResource.E0005, "Assign Work Shift");
                else if (result.ErrorCode == "9")
                    result.ErrorMessage = String.Format(MessageListResource.E0003, "update", result.ErrorMessage);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DeleteWorkShiftByEmpResult GetMsgFromDeleteActionResult(DeleteWorkShiftByEmpResult result)
        {
            try
            {
                if (result.ErrorCode == "0")
                    result.ErrorMessage = MessageListResource.I0002;
                else if (result.ErrorCode == "1")
                    result.ErrorMessage = String.Format(MessageListResource.E0004, "Assign Work Shift");
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