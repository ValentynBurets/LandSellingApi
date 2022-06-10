using Domain.Entity.Base;
using System;

namespace Domain.Entity.LotManagement
{
    public class LotManager : EntityBase
    {
        public Guid LotId { get; set; }
        public Guid ManagerId { get; set; }
        public bool Approved { get; set; }
        virtual public Lot Lot { get; set; }
        virtual public Admin Manager { get; set; }
    }
}
