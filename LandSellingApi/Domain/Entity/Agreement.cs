using Domain.Entity.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Agreement
    {
        public Guid LotId { get; set; }
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public State Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Lot Lot { get; set; }
        public User Customer { get; set; }
    }
}
