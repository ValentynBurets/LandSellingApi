using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class SellingStatusType
    {
        public SellingStatusType()
        {
            Sellings = new HashSet<Selling>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Selling> Sellings { get; set; }
    }
}
