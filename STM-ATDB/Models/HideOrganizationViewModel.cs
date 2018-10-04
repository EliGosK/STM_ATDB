using STM.ATDB.MvcWeb.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STM.ATDB.MvcWeb.Models
{
    public class HideOrganizationViewModel
    {
        public string OrgCode { get; set; }

        [Required]
        [Display(Name = "HideDateFrom", ResourceType = typeof(HideOrganizationViewModelResource))]
        public System.DateTime HideDateFrom { get; set; }

        [Required]
        [Display(Name = "HideDateTo", ResourceType = typeof(HideOrganizationViewModelResource))]
        public System.DateTime HideDateTo { get; set; }

        [Display(Name = "GroupName", ResourceType = typeof(HideOrganizationViewModelResource))]
        public string GroupName { get; set; }

        [Display(Name = "DivName", ResourceType = typeof(HideOrganizationViewModelResource))]
        public string DivName { get; set; }

        [Display(Name = "DeptName", ResourceType = typeof(HideOrganizationViewModelResource))]
        public string DeptName { get; set; }

        [Display(Name = "SecName", ResourceType = typeof(HideOrganizationViewModelResource))]
        public string SecName { get; set; }

        [Display(Name = "UpdateBy", ResourceType = typeof(HideOrganizationViewModelResource))]
        public string UpdateBy { get; set; }

        [Display(Name = "UpdateDate", ResourceType = typeof(HideOrganizationViewModelResource))]
        public System.DateTime UpdateDate { get; set; }

        [Required]
        public string DivCodeKey { get; set; }

        public string DeptCodeKey { get; set; }

        public string SecCodeKey { get; set; }

    }

}
