
using Domain.Entity.Base;
using System;

namespace Domain.Entity
{
    public class Image: EntityBase
    {
        public Guid LotId { get; set; }
        public byte[] ImageData { get; set; }

        public virtual Lot Lot { get; set; }
    }
}
