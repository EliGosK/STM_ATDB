using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Transaction
{
    public partial class AssignWorkShiftCriteria
    {
        public bool isFirstLoad { get; set; }
        public DateTime prodDateFrom { get; set; }
        public DateTime prodDateTo { get; set; }
        public DateTime? prodDate { get; set; }
        public string srhEmpCode { get; set; }
        public string srhEmpName { get; set; }
        public string shiftCode { get; set; }
        public string empCode { get; set; }
    }

    public partial class AssignWorkShiftByEmp
    {
        public DateTime ProdDateFrom { get; set; }
        public DateTime ProdDateTo { get; set; }
    }
}
