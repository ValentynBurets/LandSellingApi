﻿using Data.Identity.Repository.Base;
using Domain.Entity;
using Domain.Entity.Constants;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Location = Domain.Entity.Location;

namespace Data.Contract.Repository.LotManagement
{
    public interface ILotRepository : IEntityRepository<Lot>
    {
        Task<IEnumerable<Lot>> GetByOwnerId(Guid ownerId);
        Task<IEnumerable<Lot>> GetByPublicationDate(DateTime date);
        Task<IEnumerable<Lot>> GetByLotType(LotType lotType);
        Task<IEnumerable<Lot>> GetByState(State state);
        Task<IEnumerable<Lot>> GetByLocation(Location location);
        Task<Guid> GetByLocationId(Guid locationId);
        Task<IEnumerable<Lot>> GetByCostRaising();
        Task<IEnumerable<Lot>> GetByСostDescending();
        Task<int> GetViewsByLotId(Guid lotId);
        int GetQuantity();
    }
}
