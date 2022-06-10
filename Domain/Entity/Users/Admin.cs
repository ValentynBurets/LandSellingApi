using Domain.Entity.LotManagement;
using Domain.Entity.LotManagement.AgreementManagement;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Admin : Person
    {
        public Admin(Guid idLink) : base(idLink)
        {
            LotManagers = new HashSet<LotManager>();
            AgreementManagers = new HashSet<AgreementManager>();
        }
        public decimal Salary { get; set; }

        public virtual ICollection<LotManager> LotManagers { get; set; }
        public virtual ICollection<AgreementManager> AgreementManagers { get; set; }
    }
}
