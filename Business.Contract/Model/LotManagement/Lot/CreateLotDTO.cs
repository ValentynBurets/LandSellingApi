using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Model.LotManagement.Lot
{
    public class CreateLotDTO
    { 
        public string Header { get; set; }
        public string Description { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal? MinBidPrice { get; set; }
        public decimal? MinBidStep { get; set; }
        public int? AuctionDuration { get; set; }
        public bool IsRent { get; set; }
        public bool IsAuction { get; set; }
        public LocationDTO Location { get; set; }
    }
}
