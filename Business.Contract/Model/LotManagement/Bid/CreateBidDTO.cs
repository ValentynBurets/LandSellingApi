using System;

namespace Business.Contract.Model.LotManagement
{
    public class CreateBidDTO
    {
        public Guid LotId { get; set; }
        public decimal Value { get; set; }
    }
}
