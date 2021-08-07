using LandSellingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels
{
    public class BidViewModel
    {

        public int Id { get; set; }
        public decimal Value { get; set; }
        public int BidderId { get; set; }
        public int LotId { get; set; }

        public virtual AppUser Bidder { get; set; }
        public virtual Lot Lot { get; set; }
    }
}