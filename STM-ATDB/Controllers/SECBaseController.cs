using STM.ATDB.MvcWeb.App_Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Net;
using System.IO;
using System.Web.Routing;
using STM.ATDB.Model.Security;
using System.Web.Security;
using STM.ATDB.Core;

namespace STM.ATDB.MvcWeb.Controllers
{
    [Authorize]
    
    public class SECBaseController : Controller
    {
        #region Properties
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        #endregion

        protected JsonResult InternalServerError(Exception error)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return Json(new { message = error.Message }, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult InternalServerError(string message)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return Json(new { message = message }, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult BadRequest(string message = "Invalid Request")
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { message = message }, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult InvalidRequest(string message = "Invalid Request")
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { message = message }, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult Ok(string message = "success")
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new { message = message }, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult OkFormat(string format, params object[] args)
        {
            return Ok(String.Format(format, args));
        }

        protected JsonResult NotFound(string message = "Data not found")
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return Json(new { message = message }, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult Created(string message = "created")
        {
            Response.StatusCode = (int)HttpStatusCode.Created;
            return Json(new { message = message }, JsonRequestBehavior.AllowGet);
        }
        protected void AddErrors(params string[] errors)
        {
            // Add all errors that were returned to the page error collection
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected void PurgeTempFile(string path, int lastAccessDays = 1)
        {
            var d = new DirectoryInfo(path);
            if (d.Exists)
            {
                var extensions = new string[] { ".json", "*.txt" };
                foreach (var fileToDeleted in d.EnumerateFiles().Where(f => extensions.Contains(f.Extension.ToLowerInvariant())))
                {
                    if (fileToDeleted.LastAccessTime.AddDays(lastAccessDays) <= DateTime.Now)
                    {
                        fileToDeleted.Delete();
                    }
                }
            }
        }


        protected ActionResult RedirectToUnauthorizedRequest()
        {
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Error", action = "Index", statusCode = (int)HttpStatusCode.Unauthorized }));
        }

        public UserInformation UserDetail
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage();
                    return new UserInformation() { UserID = "SYSTEM" };
                }

                FormsIdentity id = (FormsIdentity)User.Identity;
                FormsAuthenticationTicket ticket = id.Ticket;
                UserInformation userInfo = CommonUtils.JSONToObject<UserInformation>(CommonUtils.Decrypt(ticket.UserData));
                if (userInfo != null)
                {
                    if (String.IsNullOrEmpty(userInfo.UserID))
                    {
                        userInfo.UserID = "SYSTEM";
                    }
                    return userInfo;
                }
                else
                {
                    userInfo = new UserInformation();
                    userInfo.UserID = User.Identity.Name;
                    if (String.IsNullOrEmpty(userInfo.UserID))
                    {
                        userInfo.UserID = "SYSTEM";
                    }
                    return userInfo;
                }

            }
        }

        public DateTime CurrentDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }

        
    }
}