using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CHUSHKA.Models
{
    public class ChushkaUser : IdentityUser
    {
        public string FullName { get; set; }


        public string RoleId { get; set; }
        public virtual IdentityRole Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
