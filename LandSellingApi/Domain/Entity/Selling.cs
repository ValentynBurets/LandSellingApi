using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Selling
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public int? ManagerId { get; set; }
        public int? BidWinnerId { get; set; }
        public int? SellingStatusId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? PriceBuyItNow { get; set; }

        public virtual Bid BidWinner { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual Customer Manager { get; set; }
    }
}
