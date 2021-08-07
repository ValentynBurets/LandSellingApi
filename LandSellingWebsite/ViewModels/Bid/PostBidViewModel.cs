using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels.Bid
{
    public class PostBidViewModel
    {
        public decimal Value { get; set; }
        public int BidderId { get; set; }
        public int LotId { get; set; }
    }
}
