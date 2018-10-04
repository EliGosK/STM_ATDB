using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.MvcWeb.Models
{
    public class ChangePasswordViewModel
    {
        [Required]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }
        [Required]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirm New Password do not match.")]
        public string ConfirmNewPassword { get; set; }
    }
}
