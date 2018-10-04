using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.MvcWeb.Models
{
    public class DashboardViewModel
    {
        [Required]
        [Display(Name = "Date")]
        public DateTime ChartDate { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Display(Name = "Role")]
        public string StafRole { get; set; }

        [Display(Name = "Plant")]
        public string Plant { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
