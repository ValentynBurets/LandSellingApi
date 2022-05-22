using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Model.LotManagement.AgreementManagement.Agreement
{
    public class CreateAgreementDTO
    {
        public Guid LotId { get; set; }
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
