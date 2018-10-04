using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Transaction
{
    public class ChartCriteria
    {
        public DateTime ChartDate { get; set; }
        public string ChartDateString { get; set; }
        public string Company { get; set; }
        public string StaffRole { get; set; }
        public string Plant { get; set; }
        public string Location { get; set; }

        public string UserID { get; set; }
    }

    public class TotalEmployeePieChartData
    {
        public string StaffRole { get; set; }
        public int Amount { get; set; }
    }

    public class TotalEmployeeWorkingData
    {
        public string StaffRole { get; set; }
        public int WorkingAmount { get; set; }
        public int TotalAmount { get; set; }
    }

    public class TotalEmployeeReplaceData
    {
        public string StaffRole { get; set; }
        public int TotalAmount { get; set; }
    }

    public class TotalEmployeeWorkingPlant
    {
        public string StaffRole { get; set; }
        public int WorkingAmount { get; set; }
        public string PlantName { get; set; }
    }
}
