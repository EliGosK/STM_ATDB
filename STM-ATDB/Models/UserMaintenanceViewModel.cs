using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STM.ATDB.MvcWeb.Models
{
    public class UserMaintenanceViewModel
    {
        [Required]
        [StringLength(20)]
        [Display(Name = "User ID")]
        public string UserID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "User Type")]
        public string UserTypeCode { get; set; }

        [Required]
        public string TitleCode { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(20)]
        [Display(Name = "Telephone")]
        public string Tel { get; set; }

        [StringLength(30)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
        public string CompanyCodeList { get; set; }
        public string PlantCodeList { get; set; }
        public string CompanyNameList { get; set; }
        public string PlantNameList { get; set; }
        //public string PlantCompanyCode{ get; set; }
        //public string PlantCompanyName { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        [Display(Name = "Name-Surname")]
        public string FullName { get; set; }

        public string UserPermissionTextSearch
        {
            get
            {
                return string.Format("{0} {1} {2}", this.UserID, this.Name, this.Surname);
            }
        }

        public string UserPermissionDisplay
        {
            get
            {
                if(string.IsNullOrEmpty(string.Concat(this.Name, this.Surname).Trim()))
                {
                    return string.Empty;
                }
                else
                {
                    return string.Format(" : {0} {1}", this.Name, this.Surname);
                }
               
            }
        }
    }
}