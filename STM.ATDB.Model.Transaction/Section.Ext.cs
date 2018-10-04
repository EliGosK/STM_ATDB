using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Transaction
{
    public partial class Section
    {
        public string PlantName { get; set; }
    }


    public partial class SectionCriteria
    {
        public DateTime? ProdDate { get; set; }
        public string DeptCode { get; set; }
        public string UserCode { get; set; }
    }
}
