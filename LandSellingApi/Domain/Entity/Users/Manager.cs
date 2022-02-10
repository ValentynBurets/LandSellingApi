using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Users
{
    public class Manager : User
    {
        public Manager(Guid idLink) : base(idLink)
        {
            Lots = new List<Lot>();
            Sellings = new List<Selling>();
            Rents = new List<Rent>();
        }
        public decimal Salary {  get; set; }
        public float YearsOfExperience { get; set; }

        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<Selling> Sellings { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
