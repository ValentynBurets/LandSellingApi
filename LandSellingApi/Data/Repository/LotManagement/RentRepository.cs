using Data.Contract.Repository.LotManagement;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repository.LotManagement
{
    public class RentRepository : EntityRepository<Rent>, IRentRepository
    {
        public RentRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Rent>> GetByBeginDate(DateTime date)
        {
            return await _DbContext.Rents.OrderBy(r => r.BeginDate).ToListAsync();
        }

        public async Task<IEnumerable<Rent>> GetByBeginDateDescending(DateTime date)
        {
            return await _DbContext.Rents.OrderByDescending(r => r.BeginDate).ToListAsync();
        }
        public async Task<IEnumerable<Rent>> GetByEndDateRaising(DateTime date)
        {
            return await _DbContext.Rents.OrderBy(r => r.EndDate).ToListAsync();
        }

        public async Task<IEnumerable<Rent>> GetByEndDateDescending(DateTime date)
        {
            return await _DbContext.Rents.OrderByDescending(r => r.EndDate).ToListAsync();
        }
        public async Task<Rent> GetByCustomerId(Guid customerId)
        {
            return await _DbContext.Rents.FirstAsync(r => r.CustomerId == customerId);
        }

        public async Task<Rent> GetByLotId(Guid lotId)
        {
            return await _DbContext.Rents.FirstAsync(r => r.LotId == lotId);
        }

        public async Task<Rent> GetByManagerId(Guid managerId)
        {
            return await _DbContext.Rents.FirstAsync(r => r.ManagerId == managerId);
        }

        public async Task<Rent> GetByPriceCoefId(Guid priceCoefId)
        {
            return await _DbContext.Rents.FirstAsync(r => r.PriceCoefId == priceCoefId);
        }

        public Task<IEnumerable<Rent>> GetByBeginDateRaising(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
