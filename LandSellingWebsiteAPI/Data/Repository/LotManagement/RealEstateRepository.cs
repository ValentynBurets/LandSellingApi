using Data.Contract.Repository.LotManagement;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.LotManagement
{
    public class RealEstateRepository : EntityRepository<RealEstate>, IRealEstateRepository
    {
        public RealEstateRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }

        public async Task<RealEstate> GetByLotId(Guid lotId)
        {
            return await _DbContext.RealEstates.FirstOrDefaultAsync(r => r.LotId == lotId);
        }

        public async Task<IEnumerable<RealEstate>> GetBySquarDescending()
        {
            return await _DbContext.RealEstates.OrderByDescending(r => r.Square).ToListAsync();
        }

        public async Task<IEnumerable<RealEstate>> GetBySquare(float square)
        {
            return await _DbContext.RealEstates.Where(r => r.Square == square).ToListAsync();
        }

        public async Task<IEnumerable<RealEstate>> GetBySquareRaising()
        {
            return await _DbContext.RealEstates.OrderBy(r => r.Square).ToListAsync();
        }
    }
}
