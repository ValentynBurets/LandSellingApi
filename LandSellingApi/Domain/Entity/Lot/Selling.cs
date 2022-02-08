using Domain.Entity.Base;
using Domain.Entity.Users;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Selling: EntityBase
    {
        public Guid LotId { get; set; }
        public Guid? ManagerId { get; set; }
        public Guid? BidWinnerId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal? SellingPrice { get; set; }

        public virtual Bid BidWinner { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
