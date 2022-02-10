using Data.Identity.Repository.Base;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contract.Repository
{
    public interface IFavoriteRepository : IEntityRepository<Favorite>
    {
        Task<IEnumerable<Bid>> GetByCustomerId(Guid customerId);
        Task<IEnumerable<Bid>> GetByLotId(Guid lotId);
    }
}
