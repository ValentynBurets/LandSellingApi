using Data.Identity.Repository.Base;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contract.Repository.LotManagement
{
    public interface IRealEstateRepository : IEntityRepository<RealEstate>
    {
        Task<RealEstate> GetByLotId(Guid lotId);
        Task<IEnumerable<RealEstate>> GetBySquare(float squareId); 
    }
}
