using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Transaction
{
    public partial class FixOrganizationCriteria
    {
        public bool isFirstLoad { get; set; }
        public DateTime ProdDateFrom { get; set; }
        public DateTime ProdDateTo { get; set; }
        public string SearchEmpCode { get; set; }
        public string SearchEmpName { get; set; }
        public string EmpCode { get; set; }
        public DateTime EffectiveDateFrom { get; set; }
    }
}
