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
        Task<IEnumerable<Bid>> GetBySellingId(Guid sellingId);
        Task<IEnumerable<Bid>> GetByValue(decimal value);
        Task<IEnumerable<Bid>> GetBidsWinners();
    }
}
