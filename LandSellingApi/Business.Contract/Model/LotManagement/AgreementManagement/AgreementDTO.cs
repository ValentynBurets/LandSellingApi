using Domain.Entity.Constants;
using System;

namespace Business.Contract.Model.LotManagement.AgreementManagement
{
    public class AgreementDTO
    {
        public Guid LotId { get; set; }
        public Guid CustomerId { get; set; }
        public State Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
