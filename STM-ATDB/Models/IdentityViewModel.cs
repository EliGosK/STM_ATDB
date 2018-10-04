using Microsoft.AspNet.Identity;
using STM.ATDB.Framework.Identity;
using STM.ATDB.MvcWeb.App_Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.MvcWeb.Models
{
    public static class IdentityUserExtensions
    {
        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(this IdentityUser user, ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            // Add custom user claims here
            var userIdentity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public enum ApplicationUserStatus
    {
        Active = 1,
        [Display(Name = "In-active")]
        Inactive = 0
    }

    public class ApplicationRoleSearchCriteria
    {
        public string RoleName { get; set; }
        public int[] Status { get; set; }
    }
}
