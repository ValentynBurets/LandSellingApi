﻿using LandSellingWebsite.Models;
using LandSellingWebsite.ViewModels.User;
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

        //public virtual UserViewModel Bidder { get; set; }
        //public virtual LotViewModel Lot { get; set; }
    }
}