
using Domain.Entity.Base;

namespace Domain.Entity
{
    public class Image: EntityBase
    {
        public int LotId { get; set; }
        public byte[] ImageData { get; set; }

        public virtual Lot Lot { get; set; }
    }
}
