using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class PriceCoef
    {
        public int Id { get; set; }
        public int? LotId { get; set; }
        public int DaysCount { get; set; }
        public decimal Value { get; set; }

        public virtual Lot Lot { get; set; }
    }
}
