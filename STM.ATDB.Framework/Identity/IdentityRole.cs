using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Framework.Identity
{
    public class IdentityRole : IRole<int>
    {
        /// <summary>
        /// Default constructor for Role 
        /// </summary>
        public IdentityRole()
        {

        }
        /// <summary>
        /// Constructor that takes names as argument 
        /// </summary>
        /// <param name="name"></param>
        public IdentityRole(string name) : this()
        {
            Name = name;
        }

        public IdentityRole(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}
