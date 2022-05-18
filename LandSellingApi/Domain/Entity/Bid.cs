using Domain.Entity.Base;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Bid: EntityBase
    {
        public Bid()
        {
        }

        public Guid BidderId { get; set; }
        public Guid LotId { get; set; }
        public decimal Value { get; set; }
        public bool IsWinner { get ; set; }
        public DateTime Date { get; set; }

        public virtual Person Bidder { get; set; }
        public virtual Lot Lot { get; set; }
    }
}
