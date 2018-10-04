using STM.ATDB.Framework.Infrastructure;
using STM.ATDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using STM.ATDB.Model.Security;
using STM.ATDB.Core;
using System.Web.Routing;
using System.Net;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Practices.Unity;

namespace STM.ATDB.MvcWeb.App_Helpers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class ApplicationAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        [Dependency]
        public ISecurityService SecurityService { get; set; }

        public ApplicationAuthorizeAttribute(string objectId, string permissionName)
        {
            this.ObjectId = objectId;
            this.PermissionName = permissionName;
        }

        public string ObjectId { get; private set; }
        public string PermissionName { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext == null)
                throw new ArgumentNullException("filterContext");


            if (!this.HasPermission(filterContext))
                this.HandleUnauthorizedRequest(filterContext);
        }

        public virtual bool HasPermission(AuthorizationContext filterContext)
        {
            string UserID = filterContext.RequestContext.HttpContext.User.Identity.Name;
            if (SECApplicationContext.SecurityContext.IsExpired(UserID))
            {
                List<ScreenPermissionListResult> lScreenPermission = SecurityService.GetPermissions(UserID);
                List<PermissionRecord> permissions = new List<PermissionRecord>();
                //foreach (var permission in lScreenPermission.Where(d=> d.IsChecked ?? false))
                foreach (var permission in lScreenPermission)
                {
                    //permissions.Add(new PermissionRecord() { ObjectId = permission.ScreenCode, PermissionCode = permission.PermissionCode, IsChecked = (permission.IsChecked ?? false) });
                    permissions.Add(new PermissionRecord() { ObjectId = permission.ScreenCode, PermissionCode = permission.PermissionCode });
                }
                SECApplicationContext.InitializeAuthorize(UserID, permissions);
            }
            return SECApplicationContext.SecurityContext.IsUserAuthorize(UserID, this.ObjectId, this.PermissionName); ;
        }

        private void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", statusCode = (int)HttpStatusCode.Unauthorized }));
            }
        }
    }
}
