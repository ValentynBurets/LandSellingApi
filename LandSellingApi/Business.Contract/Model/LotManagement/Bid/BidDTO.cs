using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Model.LotManagement
{
    public class BidDTO
    {
        public Guid BidderId { get; set; }
        public Guid LotId { get; set; }
        public decimal Value { get; set; }
        public bool IsWinner { get; set; }
        public DateTime Date { get; set; }

    }
}
