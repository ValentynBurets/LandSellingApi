using Domain.Entity.Constants;
using System;

namespace Business.Contract.Model.LotManagement.AgreementManagement
{
    public class AgreementDTO
    {
        public Guid Id { get; set; }
        public Guid LotId { get; set; }
        public Guid CustomerId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
