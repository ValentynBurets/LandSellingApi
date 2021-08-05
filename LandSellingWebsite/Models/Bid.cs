using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class Bid
    {
        public Bid()
        {
            Sellings = new HashSet<Selling>();
        }

        public int Id { get; set; }
        public decimal Value { get; set; }
        public int BidderId { get; set; }
        public int LotId { get; set; }

        public virtual AppUser Bidder { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual ICollection<Selling> Sellings { get; set; }
    }
}
