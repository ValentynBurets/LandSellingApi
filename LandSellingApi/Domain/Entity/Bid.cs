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

        public decimal Value { get; set; }
        public Guid BidderId { get; set; }
        public Guid SellingId { get; set; }
        public bool IsWinner { get ; set; }

        public virtual Customer Bidder { get; set; }
        public virtual Selling Selling { get; set; }
    }
}
