using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Framework.Identity
{
    public class IdentityUser : IUser
    {
        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public IdentityUser(string userName)
            : this()
        {
            UserName = userName;
        }


        public string Id { get; set; }
        public string UserName { get; set; }
        public IList<string> Roles { get; set; }

        public string UserID { get; set; }
        public string Password { get; set; }
        public string UserTypeCode { get; set; }
        public string TitleCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
