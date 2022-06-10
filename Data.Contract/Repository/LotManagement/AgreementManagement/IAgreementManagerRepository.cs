using Data.Identity.Repository.Base;
using Domain.Entity.LotManagement.AgreementManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contract.Repository.LotManagement.AgreementManagement
{
    public interface IAgreementManagerRepository : IEntityRepository<AgreementManager>
    {
        Task<AgreementManager> GetByAgreementId(Guid agreementId);
    }
}
