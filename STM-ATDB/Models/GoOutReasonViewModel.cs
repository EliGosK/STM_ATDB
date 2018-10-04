using STM.ATDB.MvcWeb.Controllers;
using STM.ATDB.MvcWeb.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STM.ATDB.MvcWeb.Models
{
    public class GoOutReasonViewModel
    {
        public int GoOutID { get; set; }

        [Required]
        public string EmpCode { get; set; }

        [Display(Name = "EmpName", ResourceType = typeof(GoOutReasonViewModelResource))]
        public string EmpName { get; set; }

        [Required]
        [Display(Name = "ProdDate", ResourceType = typeof(GoOutReasonViewModelResource))]
        public System.DateTime ProdDate { get; set; }

        [Required]
        [Display(Name = "Reason", ResourceType = typeof(GoOutReasonViewModelResource))]
        public string Reason { get; set; }

        [Required]
        public System.DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "StartTime", ResourceType = typeof(GoOutReasonViewModelResource))]
        public System.DateTime StartTime { get; set; }

        [Required]
        public System.DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "EndTime", ResourceType = typeof(GoOutReasonViewModelResource))]
        public System.DateTime EndTime { get; set; }

        [Display(Name = "UpdateBy", ResourceType = typeof(GoOutReasonViewModelResource))]
        public string UpdateBy { get; set; }

        [Display(Name = "UpdateDate", ResourceType = typeof(GoOutReasonViewModelResource))]
        public System.DateTime UpdateDate { get; set; }

    }    
}
