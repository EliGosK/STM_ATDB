using STM.ATDB.MvcWeb.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STM.ATDB.MvcWeb.Models
{
    public class OutsourceCompanyViewModel
    {
        [Key]
        [Required(ErrorMessageResourceType = typeof(ValidateViewModelResource), ErrorMessageResourceName = "RequireCompanyCode")]
        [StringLength(10)]
        [Display(Name = "Company Code")]
        public string CompanyCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidateViewModelResource), ErrorMessageResourceName = "RequireCompanyName")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Status")]
        public bool? Status { get; set; }

        [Display(Name = "Create By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Create Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Update By")]
        public string UpdatedBy { get; set; }

        [Display(Name = "Update Date")]
        public DateTime? UpdatedDate { get; set; }

        public bool? DeleteFlag { get; set; }
    }
}