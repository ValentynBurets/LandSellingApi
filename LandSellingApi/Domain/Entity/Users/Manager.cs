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
        }
        public decimal Salary {  get; set; }
        public float YearsOfExperience { get; set; }

        public virtual ICollection<Lot> Lots { get; set; }
    }
}
