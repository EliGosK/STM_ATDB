using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Transaction
{
    public partial class HideOrganizationCriteria
    {
        public bool isFirstLoad { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string DivCode { get; set; }
        public string DeptCode { get; set; }
        public string SecCode { get; set; }
        public string orgCode { get; set; }
        public DateTime HideDateFrom { get; set; }
    }
}
