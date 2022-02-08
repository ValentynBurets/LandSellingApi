
using System;
using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class House: EntityBase
    {
        public Guid? LotId { get; set; }
        public byte? Rooms { get; set; }
        public byte? Storeys { get; set; }
        public byte? Person { get; set; }
        public bool? Parking { get; set; }
        public bool? Furniture { get; set; }
        public virtual Lot Lot { get; set; }
    }
}
