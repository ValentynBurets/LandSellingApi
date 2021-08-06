using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels.Selling
{
    public class PostSellingViewModel
    {
        public int LotId { get; set; }
        public int? ManagerId { get; set; }
        public int? SellingStatusId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? PriceBuyItNow { get; set; }
    }
}
