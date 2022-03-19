using Data.Contract.Repository;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PriceCoefRepository : EntityRepository<PriceCoef>, IPriceCoefRepository
    {
        public PriceCoefRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<PriceCoef>> GetByDaysCount(int daysCount)
        {
            return await _DbContext.PriceCoefs.Where(p => p.DaysCount == daysCount).ToListAsync();
        }

        public async Task<IEnumerable<PriceCoef>> GetByLotId(Guid lotId)
        {
            return await _DbContext.PriceCoefs.Where(p => p.LotId == lotId).ToListAsync();
        }

        public async Task<IEnumerable<PriceCoef>> GetByValue(decimal value)
        {
            return await _DbContext.PriceCoefs.Where(p => p.Value == value).ToListAsync();
        }
    }
}
