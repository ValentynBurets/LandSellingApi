using Domain.Entity.Constants;
using System;

namespace Business.Contract.Model.LotManagement
{
    public class UpdateLotDTO
    {
        public Guid OwnerId { get; set; }
        public string Status { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal? MinBidPrice { get; set; }
        public bool IsRent { get; set; }
        public bool IsAuction { get; set; }
        public LocationDTO Location { get; set; }
    }
}