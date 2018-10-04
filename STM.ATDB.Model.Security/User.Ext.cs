using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Security
{
    public partial class User
    {
        public string PasswordHash { get; set; }
        public List<string> PlantCodeList { get; set; }
        public List<string> CompanyCodeList { get; set; }
    }

    public partial class UserInformation
    {
        public string UserID { get; set; }
        public string UserTypeCode { get; set; }
        public string TitleCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public List<string> PlantCodeList { get; set; }
        public List<string> CompanyCodeList { get; set; }
    }

    public class UserCriteria
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public string Type { get; set; }
        public string StatusCri { get; set; }
    }
}
