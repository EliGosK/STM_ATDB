using STM.ATDB.MvcWeb.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STM.ATDB.MvcWeb.Models
{
    public class FixOrganizationViewModel
    {
        [Required]
        [Display(Name = "EmpCode", ResourceType = typeof(FixOrganizationViewModelResource))]
        public string EmpCode { get; set; }

        [Display(Name = "EmpName", ResourceType = typeof(FixOrganizationViewModelResource))]
        public string EmpName { get; set; }

        [Required]
        [Display(Name = "EffectiveDateFrom", ResourceType = typeof(FixOrganizationViewModelResource))]
        public System.DateTime EffectiveDateFrom { get; set; }

        [Required]
        [Display(Name = "EffectiveDateTo", ResourceType = typeof(FixOrganizationViewModelResource))]
        public System.DateTime EffectiveDateTo { get; set; }

        public string OrgCode { get; set; }

        [Required]
        public string DivCodeKey { get; set; }

        [Display(Name = "DivName", ResourceType = typeof(FixOrganizationViewModelResource))]
        public string DivName { get; set; }

        [Required]
        public string DeptCodeKey { get; set; }

        [Display(Name = "DeptName", ResourceType = typeof(FixOrganizationViewModelResource))]
        public string DeptName { get; set; }

        [Required]
        public string SecCodeKey { get; set; }

        [Display(Name = "SecName", ResourceType = typeof(FixOrganizationViewModelResource))]
        public string SecName { get; set; }

        [Display(Name = "UpdateBy", ResourceType = typeof(FixOrganizationViewModelResource))]
        public string UpdateBy { get; set; }

        [Display(Name = "UpdateDate", ResourceType = typeof(FixOrganizationViewModelResource))]
        public System.DateTime UpdateDate { get; set; }
    }
}
