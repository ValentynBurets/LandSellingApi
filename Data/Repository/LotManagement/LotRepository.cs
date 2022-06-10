using Data.Contract.Repository.LotManagement;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using Domain.Entity.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Location = Domain.Entity.Location;

namespace Data.Repository.LotManagement
{
    public class LotRepository : EntityRepository<Lot>, ILotRepository
    {
        public LotRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Lot>> GetByCostRaising()
        {
            return await _DbContext.Lots.OrderBy(l => l.BuyPrice).ToListAsync();
        }
        public async Task<IEnumerable<Lot>> GetByСostDescending()
        {
            return await _DbContext.Lots.OrderByDescending(l => l.BuyPrice).ToListAsync();
        }

        public async Task<IEnumerable<Lot>> GetByLocation(Location location)
        {
            return await _DbContext.Lots.Where(l => l.Location == location).ToListAsync();
        }

        public async Task<Guid> GetByLocationId(Guid locationId)
        {
            return (await _DbContext.Lots.Where(l => l.LocationId == locationId).FirstAsync()).Id;
        }

        public async Task<IEnumerable<Lot>> GetByOwnerId(Guid ownerId)
        {
            return await _DbContext.Lots.Where(l => l.OwnerId == ownerId).ToListAsync();
        }


        public async Task<IEnumerable<Lot>> GetByPublicationDate(DateTime date)
        {
            return await _DbContext.Lots.Where(l => l.PublicationDate == date).ToListAsync();
        }

        public async Task<IEnumerable<Lot>> GetByState(State state)
        {
            return await _DbContext.Lots.Where(l => l.Status == state).ToListAsync();
        }

        public async Task<int> GetViewsByLotId(Guid lotId)
        {
            return (await _DbContext.Lots.Where(l => l.Id == lotId).FirstAsync()).Views;
        }

        public async Task<IEnumerable<Lot>> GetByLotType(LotType lotType)
        {
            if(lotType == LotType.Auction)
            {
                return await _DbContext.Lots.Where(l => l.IsAuction == true && l.IsRent == false).ToListAsync();
            }
            else if(lotType == LotType.Rent)
            {
                return await _DbContext.Lots.Where(l => l.IsAuction == false && l.IsRent == true).ToListAsync();
            }
            else
            {
                return await _DbContext.Lots.ToListAsync();
            }
        }

        public int GetQuantity()
        {
            return _DbContext.Lots.Count();
        }
    }
}
