
using Domain.Entity.Base;
using System;

namespace Domain.Entity
{
    public partial class PriceCoef: EntityBase
    {
        public Guid LotId { get; set; }
        public int DaysCount { get; set; }
        public decimal Value { get; set; }

        public virtual Lot Lot { get; set; }
    }
}
