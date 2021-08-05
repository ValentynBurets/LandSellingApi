using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
