using System;

namespace Business.Contract.Model.LotManagement.Bid
{
    public class CreateBidDTO
    {
        public Guid LotId { get; set; }
        public decimal Value { get; set; }
    }
}
