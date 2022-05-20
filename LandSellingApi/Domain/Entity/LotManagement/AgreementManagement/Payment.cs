using Domain.Entity.Base;
using System;

namespace Domain.Entity
{
    public class Payment : EntityBase
    {
        public Guid UserId {  get; set; }
        public Guid AgreementId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public string Description { get; set; } 

        public virtual User User { get; set; }
        public virtual Agreement Agreement { get; set; }
    }
}
