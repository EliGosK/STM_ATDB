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
using STM.ATDB.MvcWeb.Properties;

using System.ComponentModel.DataAnnotations;
using STM.ATDB.MvcWeb.Resources;
using System.Resources;

namespace STM.ATDB.MvcWeb.Controllers
{
    public class GoOutReasonController : SECBaseController
    {
        private ITransactionService TransactionService;
        //private ICommonService CommonService;

        public GoOutReasonController(ITransactionService transactionService)
        {
            this.TransactionService = transactionService;
        }

        [ApplicationAuthorize("ADS020", "VIEW")]
        public ActionResult Index()
        {
            return View(new GoOutReasonViewModel());
        }

        [System.Web.Http.HttpGet]
        public ActionResult SearchGoOutReason(DataSourceLoadOptions loadOptions, GoOutReasonCriteria criteria)
        {
            try
            {
                List<GoOutReasonViewModel> result = new List<GoOutReasonViewModel>();
                if (!criteria.isFirstLoad)
                {
                    criteria.UserCode = UserDetail.UserID;
                    result = TransactionService.SearchGoOutReason(criteria).ToModels();
                }
                
                return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(result, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertGoOutReason(string key, string values)
        {
            try
            {
                var newGoOutReason = new GoOutReasonViewModel();
                JsonConvert.PopulateObject(values, newGoOutReason);

                //Combine Date and Time Label
                DateTime tmpStartTime = new DateTime(newGoOutReason.StartDate.Year, newGoOutReason.StartDate.Month, newGoOutReason.StartDate.Day
                                            , newGoOutReason.StartTime.Hour, newGoOutReason.StartTime.Minute, newGoOutReason.StartTime.Second);
                DateTime tmpEndTime = new DateTime(newGoOutReason.EndDate.Year, newGoOutReason.EndDate.Month, newGoOutReason.EndDate.Day
                                            , newGoOutReason.EndTime.Hour, newGoOutReason.EndTime.Minute, newGoOutReason.EndTime.Second);

                newGoOutReason.StartTime = tmpStartTime;
                newGoOutReason.EndTime = tmpEndTime;

                ValidateModel(newGoOutReason);
                if (!ModelState.IsValid)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

                SaveGoOutReasonResult result = new SaveGoOutReasonResult();
                if (newGoOutReason.StartTime > newGoOutReason.EndTime)
                {
                    result.ErrorType = ConstantValues.TypeWarning;
                    result.ErrorMessage = String.Format(MessageListResource.W0001, "Date");
                    return Content(JsonConvert.SerializeObject(result), ConstantValues.JSON_CONTENT_TYPE);
                }

                newGoOutReason.UpdateBy = UserDetail.UserID;
                result = TransactionService.SaveGoOutReason(newGoOutReason.ToEntity(), ConstantValues.ADD);

                return Content(JsonConvert.SerializeObject(GetMsgFromInsertUpdateActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public ActionResult UpdateGoOutReason(string key, string values)
        {
            try
            {
                var updateGoOutReason = new GoOutReasonViewModel();
                JsonConvert.PopulateObject(values, updateGoOutReason);

                //Combine Date and Time Label
                DateTime tmpStartTime = new DateTime(updateGoOutReason.StartDate.Year, updateGoOutReason.StartDate.Month, updateGoOutReason.StartDate.Day
                                            , updateGoOutReason.StartTime.Hour, updateGoOutReason.StartTime.Minute, updateGoOutReason.StartTime.Second);
                DateTime tmpEndTime = new DateTime(updateGoOutReason.EndDate.Year, updateGoOutReason.EndDate.Month, updateGoOutReason.EndDate.Day
                                            , updateGoOutReason.EndTime.Hour, updateGoOutReason.EndTime.Minute, updateGoOutReason.EndTime.Second);

                updateGoOutReason.StartTime = tmpStartTime;
                updateGoOutReason.EndTime = tmpEndTime;

                ValidateModel(updateGoOutReason);
                if (!ModelState.IsValid)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.ToString());

                SaveGoOutReasonResult result = new SaveGoOutReasonResult();
                if (updateGoOutReason.StartTime > updateGoOutReason.EndTime)
                {
                    result.ErrorType = ConstantValues.TypeWarning;
                    result.ErrorMessage = String.Format(MessageListResource.W0001, "Date");
                    return Content(JsonConvert.SerializeObject(result), ConstantValues.JSON_CONTENT_TYPE);
                }

                updateGoOutReason.UpdateBy = UserDetail.UserID;
                result = TransactionService.SaveGoOutReason(updateGoOutReason.ToEntity(), ConstantValues.EDIT);

                return Content(JsonConvert.SerializeObject(GetMsgFromInsertUpdateActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public ActionResult DeleteGoOutReason(DataSourceLoadOptions loadOptions, string values)
        {
            try
            {
                var deleteGoOutReason = new GoOutReasonViewModel();
                JsonConvert.PopulateObject(values, deleteGoOutReason);

                DeleteGoOutReasonResult result = this.TransactionService.DeleteGoOutReason(deleteGoOutReason.GoOutID, UserDetail.UserID);

                return Content(JsonConvert.SerializeObject(GetMsgFromDeleteActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SaveGoOutReasonResult GetMsgFromInsertUpdateActionResult (SaveGoOutReasonResult result)
        {
            try
            {
                if (result.ErrorCode == "0")
                    result.ErrorMessage = MessageListResource.I0001;
                else if (result.ErrorCode == "1")
                    result.ErrorMessage = String.Format(MessageListResource.W0003, result.ErrorMessage);
                else if (result.ErrorCode == "2")
                    result.ErrorMessage = String.Format(MessageListResource.W0004, result.ErrorMessage);
                else if (result.ErrorCode == "3")
                    result.ErrorMessage = String.Format(MessageListResource.W0005, "Go Out Reason", "Time");
                else if (result.ErrorCode == "4")
                    result.ErrorMessage = String.Format(MessageListResource.E0005, "Go Out Reason");
                else if (result.ErrorCode == "9")
                    result.ErrorMessage = String.Format(MessageListResource.E0003, "save", result.ErrorMessage);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DeleteGoOutReasonResult GetMsgFromDeleteActionResult(DeleteGoOutReasonResult result)
        {
            try
            {
                if (result.ErrorCode == "0")
                    result.ErrorMessage = MessageListResource.I0002;
                else if (result.ErrorCode == "1")
                    result.ErrorMessage = String.Format(MessageListResource.E0004, "Go Out Reason");
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