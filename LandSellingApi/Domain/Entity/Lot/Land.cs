
using Domain.Entity.Base;
using System;

namespace Domain.Entity
{
    public partial class Land: EntityBase
    {
        public Guid? LotId { get; set; }

        public virtual Lot Lot { get; set; }
    }
}

