using Domain.Entity.Base;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Bid: EntityBase
    {
        public Bid()
        {
            Sellings = new HashSet<Selling>();
        }

        public decimal Value { get; set; }
        public Guid BidderId { get; set; }
        public Guid LotId { get; set; }

        public virtual Customer Bidder { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual ICollection<Selling> Sellings { get; set; }
    }
}
