using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Transaction
{
    public partial class Division
    {
        public string PlantName { get; set; }
    }


    public partial class DivisionCriteria
    {
        public DateTime? ProdDate { get; set; }
        public string UserCode { get; set; }
    }
}
