using Domain.Entity.Base;
using Domain.Entity.Users;
using System;

namespace Domain.Entity
{
    public partial class Rent: EntityBase
    {
        public Guid LotId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ManagerId { get; set; }
        public Guid PriceCoefId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual PriceCoef PriceCoef { get; set; }
    }
}
