using LandSellingWebsite.Models;
using LandSellingWebsite.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels
{
    public class SellingViewModel
    {
        public int Id { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? PriceBuyItNow { get; set; }

        public virtual BidViewModel BidWinner { get; set; }
        public virtual LotViewModel Lot { get; set; }
        public virtual UserViewModel Customer { get; set; }
        public virtual UserViewModel Manager { get; set; }
        public string SellingStatus { get; set; }
    }
}
