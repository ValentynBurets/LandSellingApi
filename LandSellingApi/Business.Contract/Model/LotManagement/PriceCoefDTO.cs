using System;

namespace Business.Contract.Model.LotManagement
{
    public class PriceCoefDTO
    {
        public Guid LotId { get; set; }
        public int MonthCount { get; set; }
        public decimal Value { get; set; }
    }
}
