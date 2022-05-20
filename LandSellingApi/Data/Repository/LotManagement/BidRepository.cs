using Data.Contract.Repository;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BidRepository : EntityRepository<Bid>, IBidRepository
    {
        public BidRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Bid>> GetBidsWinners()
        {
            return await _DbContext.Bids.Where(b => b.IsWinner == true).ToListAsync();
        }

        public async Task<IEnumerable<Bid>> GetByBidderId(Guid bidderId)
        {
            return await _DbContext.Bids.Where(b => b.BidderId == bidderId).ToListAsync();
        }

        public async Task<IEnumerable<Bid>> GetByLotId(Guid lotId)
        {
            return await _DbContext.Bids.Where(b => b.LotId == lotId).ToListAsync();
        }

        public async Task<IEnumerable<Bid>> GetByValue(decimal value)
        {
            return await _DbContext.Bids.Where(b => b.Value == value).ToListAsync();
        }
    }
}
