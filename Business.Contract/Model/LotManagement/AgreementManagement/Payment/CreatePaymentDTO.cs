using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract.Model.LotManagement.AgreementManagement.Payment
{
    public class CreatePaymentDTO
    {
        public Guid AgreementId { get; set; }
        public double Price { get; set; }
        public string Nonce { get; set; }
    }
}
