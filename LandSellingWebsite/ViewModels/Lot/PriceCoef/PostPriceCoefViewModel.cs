﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandSellingWebsite.ViewModels.Lot.PriceCoef
{
    public class PostPriceCoefViewModel
    {
        public int? LotId { get; set; }
        public int DaysCount { get; set; }
        public decimal Value { get; set; }
    }
}