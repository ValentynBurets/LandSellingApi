using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Customer : User
    {
        public Customer(Guid idLink) : base(idLink)
        {
            Lots = new HashSet<Lot>();
        }
        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
