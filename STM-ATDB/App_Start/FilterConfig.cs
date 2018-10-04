using Microsoft.Practices.Unity.Mvc;
using STM.ATDB.MvcWeb.App_Helpers;
using STM.ATDB.MvcWeb.App_Start;
using STM.ATDB.Services;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Microsoft.Practices.Unity;

namespace STM.ATDB {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {

            var container = UnityConfig.GetConfiguredContainer();
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            filters.Add(new HandleErrorAttribute());
            filters.Add(new AppSecurityContextAttribute(container.Resolve<ISecurityService>()));
        }
    }
}
