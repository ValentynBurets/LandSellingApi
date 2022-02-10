using Data.Identity.Repository.Base;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contract.Repository
{
    public interface IImageRepository : IEntityRepository<Image>
    {
        Task<IEnumerable<Image>> GetByLotId(Guid lotId);
    }
}
