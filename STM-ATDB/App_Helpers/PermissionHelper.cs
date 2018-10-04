using MvcSiteMapProvider.Web.Html.Models;
using STM.ATDB.Core;
using STM.ATDB.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace STM.ATDB.MvcWeb.App_Helpers
{
    public static class PermissionHelper
    {
        public static bool HasPermission(this ControllerBase controller, string screen, string permission)
        {
            return SECApplicationContext.SecurityContext.IsUserAuthorize(controller.ControllerContext.HttpContext.User.Identity.Name, screen, permission);
        }

        public static bool HasPermission(this HttpContextBase httpContext, string screen, string permission)
        {
            return SECApplicationContext.SecurityContext.IsUserAuthorize(httpContext.User.Identity.Name, screen, permission);
        }

        public static bool CheckSubMenuPermission(this ControllerBase controller, SiteMapNodeModelList nodeList)
        {
            foreach (SiteMapNodeModel node in nodeList)
            {
                if (node.Attributes.Where(d => d.Key == "objectId").Count() > 0)
                {
                    if (SECApplicationContext.SecurityContext.IsUserAuthorize(controller.ControllerContext.HttpContext.User.Identity.Name, node.Attributes["objectId"].ToString(), PermissionName.View.Value))
                    {
                        return true;
                    }
                }

            }
            return false;
        }
    }
}
