using STM.ATDB.MvcWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;
using CSI.Web.Mvc;
using Vereyon.Web;

namespace STM.ATDB {

    public class MvcApplication : HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FluentValidationModelValidatorProvider.Configure();
            MappingConfig.Register();
            DevExtremeBundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.DefaultBinder = new ExtendedModelBinder();

            // Uncomment to use pre-17.2 routing for .Mvc() and .WebApi() data sources
            DevExtreme.AspNet.Mvc.Compatibility.DataSource.UseLegacyRouting = true;
            // Uncomment to use pre-17.2 behavior for the "required" validation check
            DevExtreme.AspNet.Mvc.Compatibility.Validation.IgnoreRequiredForBoolean = false;

            FlashMessage.Transport = new FlashMessageSessionTransport();
        }

        protected void Application_PostAuthorizeRequest()
        {
            HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
        }
    }
}
