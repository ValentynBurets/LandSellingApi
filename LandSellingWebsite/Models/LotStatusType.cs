using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class LotStatusType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LotId { get; set; }

        public virtual Lot Lot { get; set; }
    }
}
