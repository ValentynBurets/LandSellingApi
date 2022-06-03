using Data.Identity.Repository.Base;
using Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Data.Contract.Repository.LotManagement
{
    public interface ILocationRepository : IEntityRepository<Location>
    {
        Task<Guid> GetByLongitudeAndLatitude(double longitude, double latitude);
    }
}
