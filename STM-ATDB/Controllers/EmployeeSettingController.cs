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
using System.Xml;
using System.Reflection;
using System.IO;
using STM.ATDB.MvcWeb.Resources;

namespace STM.ATDB.MvcWeb.Controllers
{
    public class EmployeeSettingController : SECBaseController
    {
        private IMasterService MasterService;

        public EmployeeSettingController(IMasterService masterService)
        {
            this.MasterService = masterService;
        }

        [ApplicationAuthorize("MAS010", "VIEW")]
        public ActionResult Index()
        {
            return View(new EmployeeSettingViewModel());
        }

        [System.Web.Http.HttpGet]
        public ActionResult SearchEmployeeSetting(DataSourceLoadOptions loadOptions, EmployeeSettingCriteria criteria)
        {
            try
            {
                List<EmployeeSettingViewModel> result = new List<EmployeeSettingViewModel>();
                if (!criteria.isFirstLoad)
                {
                    criteria.userCode = UserDetail.UserID;
                    result = MasterService.GetEmployeeSetting(criteria).ToModels();
                }

                return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(result, loadOptions)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [System.Web.Http.HttpPost]
        public ActionResult UpdateDisplayStatus(string[] EmpCode, string DisplayStatus)
        {
            try
            {
                DisplayStatus = (DisplayStatus == ConstantValues.AllValue) ? null : DisplayStatus;
                string empCodeXML = ConvertToXml_Store(EmpCode, "EmpCode");
                UpdateDisplayStatusResult result = MasterService.UpdateDisplayStatus(empCodeXML, DisplayStatus, UserDetail.UserID);

                return Content(JsonConvert.SerializeObject(GetMsgFromUpdateDisplayStatusActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Http.HttpPost]
        public ActionResult UpdateUserStatus(string[] EmpCode, string UserStatus)
        {
            try
            {
                UserStatus = (UserStatus == ConstantValues.AllValue) ? null : UserStatus;
                string empCodeXML = ConvertToXml_Store(EmpCode, "EmpCode");
                UpdateUserStatusResult result = MasterService.UpdateUserStatus(empCodeXML, UserStatus, UserDetail.UserID);

                return Content(JsonConvert.SerializeObject(GetMsgFromUpdateUserStatusActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Http.HttpPost]
        public ActionResult ResetPassword(string[] EmpCode)
        {
            try
            {
                string empCodeXML = ConvertToXml_Store(EmpCode, "EmpCode");
                ResetPasswordResult result = MasterService.ResetPassword(empCodeXML, UserDetail.UserID);

                return Content(JsonConvert.SerializeObject(GetMsgFromResetPWDActionResult(result)), ConstantValues.JSON_CONTENT_TYPE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ConvertToXml_Store(string[] lst, string columnName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<Table></Table>");

                if (lst != null)
                {
                    foreach (string obj in lst)
                    {
                        XmlNode node = doc.CreateNode(XmlNodeType.Element, "Row", "");
                        doc.ChildNodes[0].AppendChild(node);

                        XmlNode iNode = doc.CreateNode(XmlNodeType.Element, columnName, "");
                        iNode.InnerText = obj;
                        node.AppendChild(iNode);
                    }
                }

                StringWriter sw = new StringWriter();
                XmlTextWriter tx = new XmlTextWriter(sw);
                doc.WriteTo(tx);

                return sw.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UpdateDisplayStatusResult GetMsgFromUpdateDisplayStatusActionResult(UpdateDisplayStatusResult result)
        {
            try
            {
                if (result.ErrorCode == "0")
                    result.ErrorMessage = MessageListResource.I0001;
                else if (result.ErrorCode == "1")
                    result.ErrorMessage = String.Format(MessageListResource.E0006, result.ErrorMessage);
                else if (result.ErrorCode == "9")
                    result.ErrorMessage = String.Format(MessageListResource.E0003, "update", result.ErrorMessage);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UpdateUserStatusResult GetMsgFromUpdateUserStatusActionResult(UpdateUserStatusResult result)
        {
            try
            {
                if (result.ErrorCode == "0")
                    result.ErrorMessage = MessageListResource.I0001;
                else if (result.ErrorCode == "1")
                    result.ErrorMessage = String.Format(MessageListResource.E0007, result.ErrorMessage);
                else if (result.ErrorCode == "9")
                    result.ErrorMessage = String.Format(MessageListResource.E0003, "update", result.ErrorMessage);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResetPasswordResult GetMsgFromResetPWDActionResult(ResetPasswordResult result)
        {
            try
            {
                if (result.ErrorCode == "0" && String.IsNullOrEmpty(result.ErrorMessage))
                    result.ErrorMessage = MessageListResource.I0004;
                else if (result.ErrorCode == "0")
                    result.ErrorMessage = String.Format(MessageListResource.I0005, result.ErrorMessage);
                else if (result.ErrorCode == "1")
                    result.ErrorMessage = MessageListResource.W0002;
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