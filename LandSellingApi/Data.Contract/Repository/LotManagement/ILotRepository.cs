using Data.Identity.Repository.Base;
using Domain.Entity;
using Domain.Entity.Constants;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contract.Repository.LotManagement
{
    public interface ILotRepository : IEntityRepository<Lot>
    {
        Task<Lot> GetByOwnerId(Guid ownerId);
        Task<Lot> GetByMangerId(Guid managerId);
        Task<IEnumerable<Lot>> GetByPublicationDate(DateTime date);
        Task<IEnumerable<Lot>> GetByState(LotState state);
        Task<IEnumerable<Lot>> GetByPrice(decimal price);
        Task<IEnumerable<Lot>> GetByLocation(Geometry location);
        Task<IEnumerable<Lot>> GetByCostRaising();
        Task<IEnumerable<Lot>> GetByСostReduction();

    }
}
