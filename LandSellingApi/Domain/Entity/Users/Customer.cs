using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Customer : User
    {
        public Customer(Guid idLink) : base(idLink)
        {
            Lots = new HashSet<Lot>();
            Bids = new HashSet<Bid>();
            Favorites = new HashSet<Favorite>();
            Sellings = new HashSet<Selling>();
            Rents = new HashSet<Rent>(); 
        }
        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<Selling> Sellings { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
