using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Security
{
    public partial class ScreenPermissionListResult
    {
        public bool Expanded { get; set; }
        public List<ScreenPermissionListResult> PermissionList { get; set; }

    }

    public partial class ScreenPermissionListCriteria
    {
        public string UserID { get; set; }
        public string UserRole { get; set; }
    }

    public partial class ScreenPermissionListTreeResult
    {
        public bool Expanded { get; set; }
        public List<ScreenPermissionListTreeResult> PermissionList { get; set; }

    }
}
