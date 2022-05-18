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
        Task<IEnumerable<Lot>> GetByOwnerId(Guid ownerId);
        Task<IEnumerable<Lot>> GetByMangerId(Guid managerId);
        Task<IEnumerable<Lot>> GetByPublicationDate(DateTime date);
        Task<IEnumerable<Lot>> GetByState(State state);
        Task<IEnumerable<Lot>> GetByLocation(Geometry location);
        Task<IEnumerable<Lot>> GetByMinCostRaising();
        Task<IEnumerable<Lot>> GetByMinСostDescending();
        Task<IEnumerable<Lot>> GetByMaxCostRaising();
        Task<IEnumerable<Lot>> GetByMaxСostDescending();

    }
}
