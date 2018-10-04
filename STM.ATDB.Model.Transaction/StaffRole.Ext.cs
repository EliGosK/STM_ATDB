using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Transaction
{
    public partial class StaffRole
    {

    }

    public partial class StaffRoleCriteria
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public bool? Status { get; set; }
        public string StatusValue { get; set; }
        public bool? DeleteFlag { get; set; }

        public DateTime? UserSelectedDate { get; set; }
        public string UserID { get; set; }
    }
}
