using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class LotStatusType
    {
        public LotStatusType()
        {
            Lots = new HashSet<Lot>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Lot> Lots { get; set; }
    }
}
