using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
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
            Sellings = new HashSet<Selling>();
        }

        public int Id { get; set; }
        public int? AddressId { get; set; }
        public int? OwnerId { get; set; }
        public DateTime PublicationDate { get; set; }
        public float? Square { get; set; }
        public string Description { get; set; }
        public int? LotStatusId { get; set; }

        public virtual Address Address { get; set; }
        public virtual LotStatusType LotStatus { get; set; }
        public virtual AppUser Owner { get; set; }
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
