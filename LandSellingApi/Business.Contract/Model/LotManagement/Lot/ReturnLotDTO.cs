using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Model.LotManagement.Lot
{
    public class ReturnLotDTO
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid ManagerId { get; set; }
        public string Status { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public DateTime PublicationDate { get; set; }   
        public decimal BuyPrice { get; set; }
        public decimal? MinBidPrice { get; set; }
        public bool IsRent { get; set; }
        public bool IsAuction { get; set; }
        public LocationDTO Location { get; set; }
    }
}
