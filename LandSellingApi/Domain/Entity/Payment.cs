using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Payment
    {
        public Guid UserId {  get; set; }
        public Guid AgreenmentId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public string Description { get; set; } 

        public User User { get; set; }
        public Agreement Agreement { get; set; }
    }
}
