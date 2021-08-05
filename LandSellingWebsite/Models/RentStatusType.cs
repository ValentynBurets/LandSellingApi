using System;
using System.Collections.Generic;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class RentStatusType
    {
        public RentStatusType()
        {
            Rents = new HashSet<Rent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }
    }
}
