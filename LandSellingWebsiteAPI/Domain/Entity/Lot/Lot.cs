using Domain.Entity.Base;
using Domain.Entity.Constants;
using Domain.Entity.Users;
using NetTopologySuite.Geometries;
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
            Rents = new HashSet<Rent>();
            Favorites = new HashSet<Favorite>();
        }

        public Guid? OwnerId { get; set; }
        public Guid ManagerId { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public LotState Status { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public Geometry Location { get; set; }
        public virtual Selling Selling { get; set; }
        public virtual RealEstate RealEstate { get; set; }
        public virtual Customer Owner { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<PriceCoef> PriceCoefs { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
