using Domain.Entity.Base;
using Domain.Entity.Users;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Selling: EntityBase
    {
        public Selling()
        {
            Bids = new List<Bid>();
        }
        public Guid LotId { get; set; }
        public Guid? ManagerId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal? SellingPrice { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
    }
}
