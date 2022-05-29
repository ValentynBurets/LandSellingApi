﻿using Domain.Entity.Constants;

namespace Business.Contract.Model.LotManagement.Lot
{
    public class GetLotOptions
    {
        public LotType LotType { get; set; }
        public SortType SortType { get; set; }
        public State State { get; set; }
    }
}
