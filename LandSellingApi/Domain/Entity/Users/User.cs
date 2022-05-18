using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class User : Person
    {
        public User(Guid idLink) : base(idLink)
        {
            Lots = new HashSet<Lot>();
            Bids = new HashSet<Bid>();
        }
        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
    }
}
