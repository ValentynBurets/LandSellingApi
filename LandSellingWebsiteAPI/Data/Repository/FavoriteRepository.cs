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
    public class FavoriteRepository : EntityRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Favorite>> GetByCustomerId(Guid customerId)
        {
            return await _DbContext.Favorites.Where(f => f.CustomerId == customerId).ToListAsync();
        }

        public async Task<IEnumerable<Favorite>> GetByLotId(Guid lotId)
        {
            return await _DbContext.Favorites.Where(f => f.LotId == lotId).ToListAsync();
        }
    }
}
