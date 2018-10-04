using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STM.ATDB.Framework.Configuration
{
    public class AppSettingsContainer : IDisposable
    {
        public string ApplicationName { get; set; }
        public string CompanyName { get; set; }

        public void Dispose()
        {

        }
    }
}
