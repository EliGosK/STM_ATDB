using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Transaction
{
    public partial class Dashboard
    {
    }
    public partial class DashboardCriteria
    {
        public string DivCode { get; set; }
        public string DeptCode { get; set; }
        public string SecCode { get; set; }
        public string UserCode { get; set; }

    }
}
