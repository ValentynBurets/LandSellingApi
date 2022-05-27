using Domain.Entity.Base;
using Domain.Entity.Constants;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Lot: EntityBase
    {
        public Lot()
        {
            Images = new HashSet<Image>();
            PriceCoefs = new HashSet<PriceCoef>();
            Bids = new HashSet<Bid>();
        }

        public Guid? OwnerId { get; set; }
        public Guid ManagerId { get; set; }

        public Guid LocationId { get; set; }
        public State Status { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal? MinBidPrice { get; set; }
        public bool IsRent { get; set; }
        public bool IsAuction { get; set; }
        public virtual Location Location { get; set; }
        public virtual User Owner { get; set; }
        public virtual Admin Manager { get; set; }
        public virtual Agreement Agreement { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<PriceCoef> PriceCoefs { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
    }
}
