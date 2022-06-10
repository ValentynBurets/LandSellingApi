using Data.Contract.Repository.LotManagement.AgreementManagement;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity.LotManagement.AgreementManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.LotManagement.AgreementManagement
{
    public class AgreementManagerRepository : EntityRepository<AgreementManager>, IAgreementManagerRepository
    {
        public AgreementManagerRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }

        public async Task<AgreementManager> GetByAgreementId(Guid agreementId)
        {
            return await _DbContext.AgreementManagers.Where(i => i.AgreementId == agreementId).FirstAsync();
        }
    }
}
