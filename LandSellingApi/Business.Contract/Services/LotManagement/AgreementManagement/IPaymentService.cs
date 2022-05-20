using Business.Contract.Model.LotManagement.AgreementManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement.AgreementManagement
{
    public interface IPaymentService
    {
        public Task Create(PaymentDTO createPayment);
        public Task<PaymentDTO> Get(Guid paymentId);
        public Task<IEnumerable<PaymentDTO>> GetAll();
    }
}
