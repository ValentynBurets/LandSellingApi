using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Model.LotManagement
{
    public class ReturnSimpleLotDTO
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal BuyPrice { get; set; }
        public bool IsRent { get; set; }
        public bool IsAuction { get; set; }
        public LocationDTO Location { get; set; }
    }
}
