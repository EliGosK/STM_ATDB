using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.ATDB.MvcWeb.Models
{
    public class DailyAttendanceDashboardViewModel
    {
        //[Required]
        [Required(ErrorMessage = "Division is required")]
        [Display(Name = "Division")]
        public string Division { get; set; }

        //[Required]
        [Display(Name = "Department")]
        public string Department { get; set; }

        //[Required]
        [Display(Name = "Section")]
        public string Section { get; set; }


        //public string DivisionCode { get; set; }
        //public string DepartmentCode { get; set; }
        //public string SectionCode { get; set; }

    }
}