using Data.Contract.Repository.LotManagement.AgreementManagement;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.LotManagement.AgreementManagement
{
    public class PaymentRepository : EntityRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Payment>> GetByAgreementId(Guid agreementId)
        {
            return await _DbContext.Payments.Where(i => i.AgreementId == agreementId).ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetByDate(DateTime date)
        {
            return await _DbContext.Payments.Where(i => i.Date == date).ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetByUserId(Guid userId)
        {
            return await _DbContext.Payments.Where(i => i.UserId == userId).ToListAsync();
        }
    }
}
