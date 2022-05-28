using Domain.Entity.LotManagement;
using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Admin : Person
    {
        public Admin(Guid idLink) : base(idLink)
        {
            LotManagers = new HashSet<LotManager>();
        }
        public decimal Salary { get; set; }

        public virtual ICollection<LotManager> LotManagers { get; set; }
    }
}
