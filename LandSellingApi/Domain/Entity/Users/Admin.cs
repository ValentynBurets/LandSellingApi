using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Admin : Person
    {
        public Admin(Guid idLink) : base(idLink)
        {
            Lots = new HashSet<Lot>();
        }
        public decimal Salary { get; set; }

        public virtual ICollection<Lot> Lots { get; set; }
    }
}
