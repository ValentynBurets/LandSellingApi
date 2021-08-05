using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class DurationType
    {
        public DurationType()
        {
            PriceCoefs = new HashSet<PriceCoef>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PriceCoef> PriceCoefs { get; set; }
    }
}
