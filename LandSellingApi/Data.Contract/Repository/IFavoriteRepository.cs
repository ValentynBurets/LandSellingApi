using Data.Identity.Repository.Base;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contract.Repository
{
    public interface IFavoriteRepository : IEntityRepository<Favorite>
    {
        Task<IEnumerable<Favorite>> GetByCustomerId(Guid customerId);
        Task<IEnumerable<Favorite>> GetByLotId(Guid lotId);
    }
}
