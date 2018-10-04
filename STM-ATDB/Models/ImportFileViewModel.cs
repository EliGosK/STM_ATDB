using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.MvcWeb.Models
{
    public class ImportFileViewModel
    {
        [Display(Name = "Import ID")]
        public int ImportedID { get; set; }

        [Display(Name = "File")]
        public string FileName { get; set; }
        [Display(Name = "Total")]
        public int TotalRow { get; set; }
        [Display(Name = "Success")]
        public int SuccessRow { get; set; }
        [Display(Name = "Fail")]
        public int FailRow { get; set; }

    }


    public class ImportFileErrorViewModel
    {
        [Display(Name = "Import ID")]
        public int ImportedID { get; set; }

        [Display(Name = "Row No.")]
        public int RowNo { get; set; }

        [Display(Name = "Employee Code")]
        public string EmployeeCode { get; set; }

        [Display(Name = "Error Detail")]
        public string ErrorMessage { get; set; }

        [Display(Name = "File")]
        public string FileName { get; set; }
    }
}
