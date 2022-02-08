
using Domain.Entity.Base;
using System;

namespace Domain.Entity
{
    public partial class Favorite: EntityBase
    {
        public Guid CustomerId { get; set; }
        public Guid LotId { get; set; }

        public virtual Lot Lot { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
