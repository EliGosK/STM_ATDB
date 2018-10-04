using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Transaction
{
    public partial class GoOutReasonCriteria
    {
        public bool isFirstLoad { get; set; }
        public int? ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string EmpSurname { get; set; }
        public string UserCode { get; set; }
    }
}
