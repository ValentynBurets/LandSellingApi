using Data.Contract.Repository;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ImageRepository : EntityRepository<Image>, IImageRepository
    {
        public ImageRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Image>> GetByLotId(Guid lotId)
        {
            return await _DbContext.Images.Where(i => i.LotId == lotId).ToListAsync();
        }
    }
}
