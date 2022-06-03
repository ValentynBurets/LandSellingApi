using Domain.Entity.Base;
using System;

namespace Domain.Entity.LotManagement.AgreementManagement
{
    public class AgreementManager : EntityBase
    {
        public Guid AgreementId { get; set; }
        public Guid ManagerId { get; set; }
        virtual public Agreement Agreement { get; set; }
        virtual public Admin Manager { get; set; }
    }
}
