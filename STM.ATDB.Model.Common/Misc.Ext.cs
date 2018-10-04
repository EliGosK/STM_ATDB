using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Common
{
    public partial class Misc
    {
        //public bool ValueBoolean
        //{
        //    get
        //    {
        //        return this.ValueCode == "1" ? true : false;
               
        //    }

        //}

    }

    public partial class MiscCriteria
    {
        public bool? IncludeAll { get; set; }
        public string FieldName { get; set; }
        public Boolean IsActive { get; set; }
       
    }
}
