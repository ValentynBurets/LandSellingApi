using Data.Identity.Repository.Base;
using Domain.Entity;
using Domain.Entity.LotManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contract.Repository.LotManagement
{
    public interface ILotManagerRepository : IEntityRepository<LotManager>
    {
        Task<IEnumerable<Lot>> GetLotByMangerId(Guid managerId);
        Task<LotManager> GetByLotId(Guid lotId);
    }
}
