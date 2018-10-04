using Newtonsoft.Json;
using STM.ATDB.Core;
using STM.ATDB.Framework.Configuration;
using STM.ATDB.Framework.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Hosting;

namespace STM.ATDB.Framework.Infrastructure
{
    public class SECApplicationContext
    {
        private static AppSettingsContainer _setting;
        public static AppSettingsContainer Setting
        {
            get
            {
                if (_setting == null)
                {
                    _setting = new AppSettingsContainer();
                }
                return _setting;
            }
        }

        public static void InitializeAppSetting()
        {
            var env = ConfigurationManager.AppSettings["EnvironmentName"] ?? "";
            var filePath = HostingEnvironment.MapPath(String.IsNullOrEmpty(env) ? "~/appsettings.json" : String.Format("~/appsettings.{0}.json", env));
            InitializeAppSetting(filePath);
        }

        public static void InitializeAppSetting(string configFile)
        {
            if (File.Exists(configFile))
            {
                _setting = JsonConvert.DeserializeObject<AppSettingsContainer>(File.ReadAllText(configFile));
            }
        }

        #region Security
        private static AppSecurityContext _securityContext;
        public static AppSecurityContext SecurityContext
        {
            get
            {
                if (_securityContext == null)
                {
                    _securityContext = new AppSecurityContext();
                }
                return _securityContext;
            }
        }

        public static void InitializeAuthorize(string UserID,IEnumerable<PermissionRecord> permissions)
        {
            SecurityContext.LoadPermission(UserID, permissions);
        }


        public static void ClearSecurityPermissionCache(string UserID)
        {
            SecurityContext.Clear(UserID);
        }

        #endregion
    }
}
