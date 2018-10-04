using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Security;
using STM.ATDB.Framework.Identity;
using STM.ATDB.MvcWeb.Models;
using STM.ATDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using STM.ATDB.MvcWeb.App_Helpers;
using STM.ATDB.Core;
using STM.ATDB.Model.Security;
using System.Web.Security;
using System.Net;
using STM.ATDB.Core.ComponentModel;
using Newtonsoft.Json;
using Vereyon.Web;
using DevExtreme.AspNet.Data;
using MvcSiteMapProvider.Web.Html;
using MvcSiteMapProvider.Web.Html.Models;
using System.Xml.Linq;
using System.Xml;
using STM.ATDB.Framework.Infrastructure;
using System.Diagnostics;
using STM.ATDB.MvcWeb.Resources;

namespace STM.ATDB.MvcWeb.Controllers
{
    public class AccountController : SECBaseController
    {
        private ISecurityService SecurityService;

        public AccountController(ISecurityService securityService)
        {
            this.SecurityService = securityService;
        }

        // GET: Account
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(UserDetail);
        }

        private void SetViewBagSystemInformation()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            ViewBag.Vesion = fvi.FileVersion;
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(assembly.Location);
            ViewBag.LastModify = fileInfo.LastWriteTime.ToString(ConstantValues.TimeStampFormat);
        }

        

       
        public ActionResult Detail()
        {
            return View(UserDetail);
        }

        [HttpGet]
        public ActionResult GetScreenPermissionTree(string UserID,string UserType)
        {
            UserID = (string.IsNullOrEmpty(UserID) ? null : UserID);
            List<PermissionViewModel> lPermission = new List<PermissionViewModel>();

            if (UserID != null)
            {
                List<ScreenPermissionListTreeResult> lResult = new List<ScreenPermissionListTreeResult>();
                if(UserType.Equals("User"))
                    lResult = SecurityService.GetScreenPermissionListTree(new ScreenPermissionListCriteria() { UserID = UserID, UserRole = null });
                else
                    lResult = SecurityService.GetScreenPermissionListTree(new ScreenPermissionListCriteria() { UserID = null, UserRole = UserID });

                List<string> ItemCode = lResult.Select(d => d.ScreenCode).Distinct().ToList();
                foreach (string code in ItemCode)
                {
                    List<ScreenPermissionListTreeResult> lItem = lResult.Where(d => d.ScreenCode == code).OrderBy(d => d.PermissionSeq).ToList();
                    PermissionViewModel pwm = lItem.First().ToModel();
                    pwm.Items = new List<PermissionViewModel>();
                    foreach (ScreenPermissionListTreeResult item in lItem)
                    {
                        PermissionViewModel itemModel = item.ToModel();
                        itemModel.Code = item.PermissionCode;
                        itemModel.Text = item.PermissionName;
                        pwm.Items.Add(itemModel);
                    }

                    pwm.IsHavePermission = (pwm.Items.Count == pwm.Items.Where(d => d.IsHavePermission).Count());
                    lPermission.Add(pwm);
                }



                foreach (var parent in lPermission)
                {
                    parent.Items.ForEach(d => d.ParentText = parent.Text);
                    parent.Items.ForEach(d => d.ParentCode = parent.Code);
                }

                //var lNode = SiteMap.Provider.RootNode.GetAllNodes();
            }
            return Content(JsonConvert.SerializeObject(lPermission), ConstantValues.JSON_CONTENT_TYPE);
        }

        [HttpGet]
        public ActionResult GetUserList(string UserID,string UserType)
        {
            UserID = (string.IsNullOrEmpty(UserID) ? null : UserID);
            List<PermissionViewModel> lPermission = new List<PermissionViewModel>();

            List<ScreenPermissionListResult> lResult = SecurityService.GetScreenPermissionList(new ScreenPermissionListCriteria() { UserID = UserID });
            List<string> ItemCode = lResult.Select(d => d.ScreenCode).Distinct().ToList();
            foreach (string code in ItemCode)
            {
                List<ScreenPermissionListResult> lItem = lResult.Where(d => d.ScreenCode == code).OrderBy(d => d.PermissionSeq).ToList();
                PermissionViewModel pwm = lItem.First().ToModel();
                pwm.Items = new List<PermissionViewModel>();
                foreach (ScreenPermissionListResult item in lItem)
                {
                    PermissionViewModel itemModel = item.ToModel();
                    itemModel.Code = item.PermissionCode;
                    itemModel.Text = item.PermissionName;
                    pwm.Items.Add(itemModel);
                }

                pwm.IsHavePermission = (pwm.Items.Count == pwm.Items.Where(d => d.IsHavePermission).Count());
                lPermission.Add(pwm);
            }

            foreach (var parent in lPermission)
            {
                parent.Items.ForEach(d => d.ParentText = parent.Text);
                parent.Items.ForEach(d => d.ParentCode = parent.Code);
            }

            //var lNode = SiteMap.Provider.RootNode.GetAllNodes();

            return Content(JsonConvert.SerializeObject(lPermission), ConstantValues.JSON_CONTENT_TYPE);
        }

        
        [HttpGet]
        public ActionResult GetUserAndRoleList(string UserID,string UserType)
        {
            UserType = (string.IsNullOrEmpty(UserType) ? null : UserType);
            List<UserAndRoleListResult> lUser = new List<UserAndRoleListResult>();

            if(UserType!=null && !UserType.Equals("null"))
                this.SecurityService.GetUserAndRoleList(new UserCriteria() { UserID=UserID,Type=UserType }).ForEach(d => lUser.Add(d));

            return Content(JsonConvert.SerializeObject(lUser), ConstantValues.JSON_CONTENT_TYPE);
        }

        [ApplicationAuthorize("AMS020", "VIEW")]
        public ActionResult PermissionSetting()
        {
            List<UserMaintenanceViewModel> lUser = new List<UserMaintenanceViewModel>();
            //return View(lUser);
            return View();
        }


        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")] // For clear AntiForgeryToken of previous user logon
        public ActionResult Login(string returnUrl)
        {
            SetViewBagSystemInformation();
            ViewBag.ReturnUrl = returnUrl;
            EnsureLoggedOut();
            return View();
        }

        // POST: /account/login
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            // Ensure we have a valid viewModel to work with
            if (!ModelState.IsValid)
                return View(viewModel);

            FormsAuthentication.Initialize();
            // Verify if a user exists with the provided identity information     
            var user = viewModel.ToEntity();
            user.PasswordHash = CommonUtils.Encrypt(user.Password);
            user = SecurityService.CheckUserLogin(user);
            //// If a user was found
            if (user != null)
            {
                string JSONData = CommonUtils.Encrypt(CommonUtils.ConvertToJSON<UserInformation>(user.ToUserInformation()));
                string timeOut = System.Web.Configuration.WebConfigurationManager.AppSettings["AuthenticationTicketTimeout"];
                int iTimeOut=3;
                if (!string.IsNullOrWhiteSpace(timeOut)) iTimeOut = int.Parse(timeOut); 
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.UserID, DateTime.Now, DateTime.Now.AddDays(1), true, JSONData, FormsAuthentication.FormsCookiePath);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.UserCode, DateTime.Now, DateTime.Now.AddMinutes(iTimeOut), true, JSONData, FormsAuthentication.FormsCookiePath);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                Response.Cookies.Add(cookie);
                // If the user came from a specific page, redirect back to it

                //return RedirectToLocal(returnUrl);
                return RedirectToLocal();
            }
            

            // No existing user was found that matched the given criteria
            ModelState.AddModelError("LogOnError", MessageListResource.E0001);

            // If we got this far, something failed, redisplay form
            ViewBag.LogOnErrorMessage = MessageListResource.E0001;
            SetViewBagSystemInformation();
            return View(viewModel);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        private ActionResult RedirectToLocal(string returnUrl = "")
        {
            if (!returnUrl.IsNullOrWhiteSpace() && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }


        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
            {
                Logout();
            }
        }

        public ActionResult ChangePassword()
        {
            return View(new ChangePasswordViewModel());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(string dataText)
        {
            ChangePasswordViewModel viewModel = CommonUtils.JSONToObject<ChangePasswordViewModel>(dataText);
            MessageViewModel msg = new MessageViewModel();
            msg.MessageType = ApplicationMessageType.Error;
            msg.IsError = 1;
            try
            {
                
                User user = new User() { UserCode = UserDetail.UserID, Password = viewModel.CurrentPassword, PasswordHash = CommonUtils.Encrypt(viewModel.CurrentPassword) };
                user = SecurityService.CheckUserLogin(user);
                if (user != null)
                {
                    user.PasswordHash = CommonUtils.Encrypt(viewModel.NewPassword);
                    ObjectResult result = SecurityService.ChangePassword(user);
                    if(result.IsSucceed)
                    {
                        msg.Message = MessageListResource.I0003;
                        msg.MessageType = ApplicationMessageType.Success;
                        msg.IsError = 0;
                    }
                    else
                    {
                        msg.Message = result.GetErrorMessage();
                    }
                }
                else
                {
                    msg.Message = MessageListResource.E0002;
                }
            }
            catch(Exception ex)
            {
                msg.Message = ex.Message;
            }
            return Content(JsonConvert.SerializeObject(msg), ConstantValues.JSON_CONTENT_TYPE);
            
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SavePermission(string dataText, string UserType)
        {
            PermissionSaveViewModel viewModel = CommonUtils.JSONToObject<PermissionSaveViewModel>(dataText);
            MessageViewModel msg = new MessageViewModel();
            msg.MessageType = ApplicationMessageType.Error;
            msg.IsError = 1;
            try
            {
                List<ScreenPermissionListTreeResult> lPermission = new List<ScreenPermissionListTreeResult>();
                foreach(var item in viewModel.PermissionList)
                {
                    ScreenPermissionListTreeResult entity = item.ToEntity2();
                    entity.PermissionList = new List<ScreenPermissionListTreeResult>();
                   foreach (var permission in item.Items)
                    {
                        entity.PermissionList.Add(permission.ToEntity2());
                    }
                    lPermission.Add(entity);
                }

                
                SecurityService.SavePermission(viewModel.UserID, UserType, lPermission,UserDetail.UserID);
                SECApplicationContext.ClearSecurityPermissionCache(viewModel.UserID);
                msg.Message = MessageListResource.I0007;
                msg.MessageType = ApplicationMessageType.Success;
                msg.IsError = 0;
            }
            catch (Exception ex)
            {
                msg.Message = ex.Message;
            }
            return Content(JsonConvert.SerializeObject(msg), ConstantValues.JSON_CONTENT_TYPE);

        }


    }
}