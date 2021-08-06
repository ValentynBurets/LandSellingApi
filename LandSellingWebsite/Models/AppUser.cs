using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class AppUser
    {
        public AppUser()
        {
            Bids = new HashSet<Bid>();
            Lots = new HashSet<Lot>();
            RentCustomers = new HashSet<Rent>();
            RentManagers = new HashSet<Rent>();
            Roles = new HashSet<Role>();
            Sellings = new HashSet<Selling>();
        }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string GetFullName()
        {
            return $"{this.Name}, {this.SurName}";
        }

        //public string GetRoleName()
        //{
        //    return (from x in Roles where x.Id == RoleId select x).First().Name;
        //}

        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<Rent> RentCustomers { get; set; }
        public virtual ICollection<Rent> RentManagers { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Selling> Sellings { get; set; }
    }
}
