using Business.Contract.Model.LotManagement.AgreementManagement;
using System;
using System.Threading.Tasks;

namespace Business.Contract.Services.LotManagement.AgreementManagement.Payment
{
    public interface IPaymentHelper
    {
        Task<string> GenerateClientToken(Guid userId);
        Task<bool> ProceedTransaction(TransactionDataModel data);
    }
}
