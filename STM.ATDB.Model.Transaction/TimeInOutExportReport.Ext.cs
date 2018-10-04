using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Transaction
{
    public partial class OutsourceReport
    {

    }

    public partial class OutsourceReportCriteria
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Company { get; set; }
        public string CompanyName { get; set; }
        public string FileFullPath { get; set; }

        public string UserID { get; set; }
        public string FileDownloadFullPath { get; set; }
        public string FileDownloadName { get; set; }
    }

    public partial class TimeInOutReport
    {

    }

    public partial class TimeInOutReportCriteria
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Company { get; set; }
        public string CompanyName { get; set; }
        public string FileFullPath { get; set; }

        public string UserID { get; set; }
        public string FileDownloadFullPath { get; set; }
        public string FileDownloadName { get; set; }
    }
}
