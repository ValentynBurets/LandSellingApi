
using System;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class RealEstate: EntityBase
    {
        public Guid LotId { get; set; }
        public virtual Lot Lot { get; set; }
        public float? Square { get; set; }

    }
}
