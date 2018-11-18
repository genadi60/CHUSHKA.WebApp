using System.Collections.Generic;
using CHUSHKA.Models;
using Microsoft.AspNetCore.Identity;

namespace CHUSHKA.Web.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public virtual IdentityRole Role { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
