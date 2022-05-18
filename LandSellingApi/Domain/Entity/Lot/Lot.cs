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
        }

        public Guid? OwnerId { get; set; }
        public Guid ManagerId { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public State Status { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public Location Location { get; set; }
        public virtual Person Owner { get; set; }
        public virtual Admin Manager { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<PriceCoef> PriceCoefs { get; set; }
    }
}
