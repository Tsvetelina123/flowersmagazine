using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flowersmagazine.Data
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
