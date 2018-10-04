using STM.ATDB.MvcWeb.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.MvcWeb.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidateViewModelResource), ErrorMessageResourceName = "RequireUserName")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessageResourceType = typeof(ValidateViewModelResource), ErrorMessageResourceName = "RequirePassword")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        //[Required(ErrorMessageResourceType = typeof(ValidateViewModelResource), ErrorMessageResourceName = "RequireUserType")]
        [Display(Name = "User Type")]
        public string UserType { get; set; }

        public bool RememberMe { get; set; }
    }
}
