using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Transaction
{
    public partial class EmployeeSettingCriteria
    {
        public bool isFirstLoad { get; set; }
        public string searchEmpCode { get; set; }
        public string searchEmpName { get; set; }
        public string divCodeKey { get; set; }
        public string deptCodeKey { get; set; }
        public string secCodeKey { get; set; }
        public string empStatus { get; set; }
        public string userStatus { get; set; }
        public string displayStatus { get; set; }
        public bool viewActiveOrg { get; set; }
        public string userCode { get; set; }
    }
}
