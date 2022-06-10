using Business.Contract.Model.LotManagement.AgreementManagement;
using Business.Contract.Model.LotManagement.AgreementManagement.Payment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement.AgreementManagement
{
    public interface IPaymentService
    {
        Task Create(CreatePaymentDTO createPayment, Guid userId);
        Task<PaymentDTO> GetById(Guid paymentId);
        Task<IEnumerable<PaymentDTO>> GetAll();
        Task<string> GetToken(Guid userId);
        Task<IEnumerable<PaymentDTO>> GetByAgreementId(Guid agreementId);
    }
}
