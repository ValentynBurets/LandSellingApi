using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Model.LotManagement.AgreementManagement
{
    public class PaymentDTO
    {
        public Guid UserId { get; set; }
        public Guid AgreementId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
    }
}
