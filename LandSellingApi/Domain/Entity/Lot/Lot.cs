using Domain.Entity.Constants;
using Microsoft.Spatial;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Lot
    {
        public Lot()
        {
            Bids = new HashSet<Bid>();
            Favorites = new HashSet<Favorite>();
            Houses = new HashSet<House>();
            Images = new HashSet<Image>();
            Lands = new HashSet<Land>();
            PriceCoefs = new HashSet<PriceCoef>();
            Rents = new HashSet<Rent>();
        }

        public Guid Id { get; set; }
        public Guid? OwnerId { get; set; }
        public DateTime PublicationDate { get; set; }
        public float? Square { get; set; }
        public string Description { get; set; }
        public LotState Status { get; set; }
        public Guid ManagerId {  get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public Geometry Location { get; set; }
        public virtual Customer Owner { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<House> Houses { get; set; }
        public virtual ICollection<Land> Lands { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<PriceCoef> PriceCoefs { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
        public virtual ICollection<Selling> Sellings { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
