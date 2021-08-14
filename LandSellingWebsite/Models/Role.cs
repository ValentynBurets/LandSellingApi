using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class Role
    {
        public Role()
        {
            AppUsers = new HashSet<AppUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppUser> AppUsers { get; set; }
    }
}
