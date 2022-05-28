using Data.Contract.Repository.LotManagement;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using Domain.Entity.LotManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.LotManagement
{
    public class LotManagerRepository : EntityRepository<LotManager>, ILotManagerRepository
    {
        public LotManagerRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Lot>> GetLotByMangerId(Guid managerId)
        {
            var LotManagers = await _DbContext.LotManagers.Where(l => l.ManagerId == managerId).ToListAsync();
            List<Lot> lots = new List<Lot>();
            foreach(var l in LotManagers)
            {
                lots.Add(l.Lot);
            }
            return lots;
        }
    }
}