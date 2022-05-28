using Domain.Entity.Base;
using Domain.Entity.Constants;
using Domain.Entity.LotManagement;
using Domain.Entity.LotManagement.AgreementManagement;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Agreement : EntityBase
    {
        public Agreement()
        {
            Payments = new HashSet<Payment>();
            AgreementManagers = new HashSet<AgreementManager>();
        }
        public Guid LotId { get; set; }
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public State Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Lot Lot { get; set; }
        public virtual User Customer { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<AgreementManager> AgreementManagers { get; set; }
    }
}
