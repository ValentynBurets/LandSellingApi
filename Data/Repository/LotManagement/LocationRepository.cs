using Data.Contract.Repository.LotManagement;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.LotManagement
{
    public class LocationRepository : EntityRepository<Location>, ILocationRepository
    {
        public LocationRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }

        public async Task<Guid> GetByLongitudeAndLatitude(double longitude, double latitude)
        {
            return (await _DbContext.Locations.Where(i => i.Latitude == latitude && i.Longitude == longitude).FirstAsync()).Id;
        }
    }
}
