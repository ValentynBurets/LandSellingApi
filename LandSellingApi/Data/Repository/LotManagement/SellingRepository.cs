using Data.Contract.Repository.LotManagement;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.LotManagement
{
    public class SellingRepository : EntityRepository<Selling>, ISellingRepository 
    {
        public SellingRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Selling>> GetByCustomerId(Guid customerId)
        {
            return await _DbContext.Sellings.Where(s => s.CustomerId == customerId).ToListAsync();
        }

        public async Task<Selling> GetByLotId(Guid lotId)
        {
            return await _DbContext.Sellings.FirstAsync(s => s.LotId == lotId);
        }

        public async Task<IEnumerable<Selling>> GetByMangerId(Guid managerId)
        {
            return await _DbContext.Sellings.Where(s => s.ManagerId == managerId).ToListAsync();
        }

        public async Task<IEnumerable<Selling>> GetBySellingPrice(decimal price)
        {
            return await _DbContext.Sellings.Where(s => s.SellingPrice == price).ToListAsync();
        }

        public async Task<IEnumerable<Selling>> GetBySellingPriceDescending()
        {
            return await _DbContext.Sellings.OrderByDescending(s => s.SellingPrice).ToListAsync();
        }

        public async Task<IEnumerable<Selling>> GetBySellingPriceRaising()
        {
            return await _DbContext.Sellings.OrderBy(s => s.SellingPrice).ToListAsync();
        }
    }
}
