using STM.ATDB.MvcWeb.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STM.ATDB.MvcWeb.Models
{
    public class EmployeeSettingViewModel
    {
        [Display(Name = "EmpCode", ResourceType = typeof(EmployeeSettingViewModelResource))]
        public string EmpCode { get; set; }

        [Display(Name = "EmpName", ResourceType = typeof(EmployeeSettingViewModelResource))]
        public string EmpName { get; set; }

        public string EmpStatus { get; set; }

        [Required]
        [Display(Name = "DisplayStatus", ResourceType = typeof(EmployeeSettingViewModelResource))]
        public string DisplayStatus { get; set; }

        [Required]
        [Display(Name = "UserStatus", ResourceType = typeof(EmployeeSettingViewModelResource))]
        public string UserStatus { get; set; }

        [Display(Name = "TransferDate", ResourceType = typeof(EmployeeSettingViewModelResource))]
        public System.DateTime TransferDate { get; set; }

        [Display(Name = "DivName", ResourceType = typeof(EmployeeSettingViewModelResource))]
        public string DivName { get; set; }

        [Display(Name = "DeptName", ResourceType = typeof(EmployeeSettingViewModelResource))]
        public string DeptName { get; set; }

        [Display(Name = "SecName", ResourceType = typeof(EmployeeSettingViewModelResource))]
        public string SecName { get; set; }

        [Display(Name = "ResignDate", ResourceType = typeof(EmployeeSettingViewModelResource))]
        public System.DateTime ResignDate { get; set; }

        [Display(Name = "Updateby", ResourceType = typeof(EmployeeSettingViewModelResource))]
        public string updateby { get; set; }

        [Display(Name = "Updatedate", ResourceType = typeof(EmployeeSettingViewModelResource))]
        public System.DateTime updatedate { get; set; }
    }
}
