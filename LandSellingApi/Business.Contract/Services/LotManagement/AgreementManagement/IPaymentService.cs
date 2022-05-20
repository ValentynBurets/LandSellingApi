using Business.Contract.Model.LotManagement.AgreementManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement.AgreementManagement
{
    public interface IPaymentService
    {
        public Task Create(PaymentDTO createPayment, Guid userId);
        public Task<PaymentDTO> GetById(Guid paymentId);
        public Task<IEnumerable<PaymentDTO>> GetAll();
    }
}
