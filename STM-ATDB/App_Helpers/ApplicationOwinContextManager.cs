using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Newtonsoft.Json;
using STM.ATDB.Framework.Configuration;
using STM.ATDB.Framework.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace STM.ATDB.MvcWeb.App_Helpers
{
    public static class ApplicationOwinContextManager
    {
        public static AppSettingsContainer Create(IdentityFactoryOptions<AppSettingsContainer> options,
           IOwinContext context)
        {
            var env = ConfigurationManager.AppSettings["EnvironmentName"] ?? "";
            var filePath = HostingEnvironment.MapPath(String.IsNullOrEmpty(env) ? "~/appsettings.json" : String.Format("~/appsettings.{0}.json", env));
            if (File.Exists(filePath))
            {
                var setting = JsonConvert.DeserializeObject<AppSettingsContainer>(File.ReadAllText(filePath));
                return setting;
            }
            return new AppSettingsContainer();
        }

        //public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
        //    IOwinContext context)
        //{
        //    string xmlFile = HostingEnvironment.MapPath("~/content/sql/identity.xml");
        //    //var setting = context.Get<AppSettingsContainer>();
        //    var values = new Dictionary<string, string>();
        //    MMSApplicationContext.Setting.LibraryPrefixes.ForEach((v) => values.Add(v.Key, v.Value));
        //    var database = new KawaDB2Database("AUTH", new XmlSqlCommandStore(xmlFile), values);
        //    var manager = new ApplicationUserManager(new MMSIdentityDB2.UserStore(database));
        //    // We have to create our own user manager in order to override some default behavior:
        //    //
        //    //  - Override default password length requirement (6) with a length of 4
        //    //  - Override user name requirements to allow spaces and dots
        //    manager.UserValidator = new UserValidator<IdentityUser>(manager)
        //    {
        //        AllowOnlyAlphanumericUserNames = false,
        //        RequireUniqueEmail = false
        //    };

        //    // Configure validation logic for passwords
        //    manager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 6,
        //        RequireNonLetterOrDigit = false,
        //        RequireDigit = false,
        //        RequireLowercase = false,
        //        RequireUppercase = false,
        //    };

        //    // For Dev Only
        //    var env = ConfigurationManager.AppSettings["EnvironmentName"] ?? "";
        //    manager.IgnoreCheckPassword = String.Compare(env, "development", true) == 0;
        //    return manager;
        //}

        //public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        //{
        //    string xmlFile = HostingEnvironment.MapPath("~/content/sql/identity.xml");
        //    //var setting = context.Get<AppSettingsContainer>();
        //    var values = new Dictionary<string, string>();
        //    MMSApplicationContext.Setting.LibraryPrefixes.ForEach((v) => values.Add(v.Key, v.Value));
        //    var database = new KawaDB2Database("AUTH", new XmlSqlCommandStore(xmlFile), values);
        //    var manager = new ApplicationRoleManager(new MMSIdentityDB2.RoleStore(database));
        //    return manager;
        //}

        //public static ApplicationUserManager CreateForDev(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        //{
        //    string folder = HostingEnvironment.MapPath("~/content/json/security");
        //    var manager = new ApplicationUserManager(new MMSIdentityJson.UserStore(folder));
        //    manager.IgnoreCheckPassword = true;
        //    return manager;
        //}

        //public static ApplicationRoleManager CreateForDev(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        //{
        //    string folder = HostingEnvironment.MapPath("~/content/json/security");
        //    var manager = new ApplicationRoleManager(new MMSIdentityJson.RoleStore(folder));
        //    return manager;
        //}

    }

    public class ApplicationUserManager : UserManager<IdentityUser>
    {
        public ApplicationUserManager(IUserStore<IdentityUser> store)
            : base(store)
        {

        }

        public bool IgnoreCheckPassword { get; set; }
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole, int>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, int> store)
            : base(store)
        {
        }

        public override Task<IdentityResult> DeleteAsync(IdentityRole role)
        {
            IdentityResult result = IdentityResult.Success;
            try
            {
                result = base.DeleteAsync(role).Result;
            }
            catch (Exception ex)
            {
                result = IdentityResult.Failed(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

            return Task.FromResult<IdentityResult>(result);
        }
    }
}
