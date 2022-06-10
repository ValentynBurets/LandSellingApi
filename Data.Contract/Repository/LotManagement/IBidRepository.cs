using Data.Identity.Repository.Base;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contract.Repository
{
    public interface IBidRepository : IEntityRepository<Bid>
    {
        Task<IEnumerable<Bid>> GetByBidderId(Guid bidderId);
        Task<IEnumerable<Bid>> GetByLotId(Guid lotId);
        Task<IEnumerable<Bid>> GetByValue(decimal value);
        Task<IEnumerable<Bid>> GetBidsWinners();
        int GetQuantity();
    }
}
