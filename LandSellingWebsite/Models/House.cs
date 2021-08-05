using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class House
    {
        public int Id { get; set; }
        public int? LotId { get; set; }
        public byte? Rooms { get; set; }
        public byte? Floor { get; set; }
        public byte? Person { get; set; }
        public bool? Parking { get; set; }
        public bool? Furniture { get; set; }

        public virtual Lot Lot { get; set; }
    }
}
