using Domain.Entity.Base;
using Domain.Entity.Constants;
using Domain.Entity.Users;
using Microsoft.Spatial;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Lot: EntityBase
    {
        public Lot()
        {
            Bids = new HashSet<Bid>();
            Images = new HashSet<Image>();
            PriceCoefs = new HashSet<PriceCoef>();
            Rents = new HashSet<Rent>();
            Sellings = new HashSet<Selling>();
            Favorites = new HashSet<Favorite>();
        }

        public Guid? OwnerId { get; set; }
        public Guid ManagerId { get; set; }
        public DateTime PublicationDate { get; set; }
        public float? Square { get; set; }
        public string Description { get; set; }
        public LotState Status { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public Geometry Location { get; set; }
        
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual House House { get; set; }
        public virtual Customer Owner { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<PriceCoef> PriceCoefs { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
        public virtual ICollection<Selling> Sellings { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
