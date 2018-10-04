using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Common
{
    public class CommonCriteria
    {
       public bool? IncludeAll { get; set; }
       public bool? IncludeDelete { get; set; }
       public string ValueCode { get; set; }

       public string UserSelectedDateText { get; set; }
       public DateTime? UserSelectedDate { get; set; }
       public string UserID { get; set; }
    }

    public partial class EmpCriteria
    {
        public Boolean? IsUsePEFF { get; set; }
        public DateTime? ProdDateFrom { get; set; }
        public DateTime? ProdDateTo { get; set; }
        public string EmpCode { get; set; }
        public bool IsActiveOnly { get; set; }
    }

    public partial class DepartmentCriteriaCombo
    {
        public bool? IncludeAll { get; set; }
        public DateTime? ProdDate { get; set; }
        public DateTime? ProdDateFrom { get; set; }
        public DateTime? ProdDateTo { get; set; }
        public string DivCodeKey { get; set; }
        public string DeptCodeKey { get; set; }
        public string userCode { get; set; }
        public bool IsActiveOnly { get; set; }
    }

    public partial class DivisionCriteriaCombo
    {
        public bool? IncludeAll { get; set; }
        public DateTime? ProdDate { get; set; }
        public DateTime? ProdDateFrom { get; set; }
        public DateTime? ProdDateTo { get; set; }
        public string DivCodeKey { get; set; }
        public string userCode { get; set; }
        public bool IsActiveOnly { get; set; }
    }

    public partial class SectionCriteriaCombo
    {
        public bool? IncludeAll { get; set; }
        public DateTime? ProdDate { get; set; }
        public DateTime? ProdDateFrom { get; set; }
        public DateTime? ProdDateTo { get; set; }
        public string DeptCodeKey { get; set; }
        public string SecCodeKey { get; set; }
        public string userCode { get; set; }
        public bool IsActiveOnly { get; set; }
    }

    public partial class GroupCriteriaCombo
    {
        public bool? IncludeAll { get; set; }
        public DateTime? prodDate { get; set; }
        public string GroupCode { get; set; }
        public string UserCode { get; set; }
    }
}
