using STM.ATDB.Core;
using STM.ATDB.Framework.Infrastructure;
using STM.ATDB.Model.Security;
using STM.ATDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace STM.ATDB.MvcWeb.App_Helpers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AppSecurityContextAttribute : ActionFilterAttribute
    {
        protected ISecurityService SecurityService { get; set; }

        public AppSecurityContextAttribute(ISecurityService securityService)
        {
            this.SecurityService = securityService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest()) { return; }
            string UserID = filterContext.RequestContext.HttpContext.User.Identity.Name;
            if (SECApplicationContext.SecurityContext.IsExpired(UserID))
            {
                List<ScreenPermissionListResult> lScreenPermission = SecurityService.GetPermissions(UserID);
                List<PermissionRecord> permissions = new List<PermissionRecord>();
                //foreach (var permission in lScreenPermission.Where(d => d.IsChecked ?? false))
                foreach (var permission in lScreenPermission)
                {
                    //permissions.Add(new PermissionRecord() { ObjectId = permission.ScreenCode, PermissionCode = permission.PermissionCode, IsChecked = (permission.IsChecked ?? false) });
                    permissions.Add(new PermissionRecord() { ObjectId = permission.ScreenCode, PermissionCode = permission.PermissionCode });
                }
                SECApplicationContext.InitializeAuthorize(UserID, permissions);
            }
        }

    }
}
