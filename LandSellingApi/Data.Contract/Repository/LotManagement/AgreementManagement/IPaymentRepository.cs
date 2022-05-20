using Data.Identity.Repository.Base;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contract.Repository.LotManagement.AgreementManagement
{
    public interface IPaymentRepository : IEntityRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetByUserId(Guid userId);
        Task<IEnumerable<Payment>> GetByAgreementId(Guid agreementId);
        Task<IEnumerable<Payment>> GetByDate(DateTime date);

    }
}
