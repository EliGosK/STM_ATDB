using STM.ATDB.MvcWeb.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STM.ATDB.MvcWeb.Models
{
    public class AssignWorkShiftViewModel
    {
        [Display(Name = "ProdDate", ResourceType = typeof(AssignWorkShiftViewModelResource))]
        public System.DateTime ProdDate { get; set; }

        [Required]
        [Display(Name = "EmpCode", ResourceType = typeof(AssignWorkShiftViewModelResource))]
        public string EmpCode { get; set; }

        [Display(Name = "EmpName", ResourceType = typeof(AssignWorkShiftViewModelResource))]
        public string EmpName { get; set; }

        [Required]
        public string ShiftCode { get; set; }

        [Display(Name = "ShiftName", ResourceType = typeof(AssignWorkShiftViewModelResource))]
        public string ShiftName { get; set; }

        [Display(Name = "UpdateBy", ResourceType = typeof(AssignWorkShiftViewModelResource))]
        public string UpdateBy { get; set; }

        [Display(Name = "UpdateDate", ResourceType = typeof(AssignWorkShiftViewModelResource))]
        public System.DateTime UpdateDate { get; set; }

        [Required]
        public System.DateTime ProdDateFrom { get; set; }

        [Required]
        public System.DateTime ProdDateTo { get; set; }
    }
}
