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
            Agreements = new HashSet<Agreement>();
            Payments = new HashSet<Payment>();
        }
        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<Agreement> Agreements { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
