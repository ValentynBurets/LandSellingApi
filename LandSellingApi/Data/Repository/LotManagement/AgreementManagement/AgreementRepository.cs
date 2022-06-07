using Data.Contract.Repository.LotManagement;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.LotManagement.AgreementManagement
{
    public class AgreementRepository : EntityRepository<Agreement>, IAgreementRepository
    {
        public AgreementRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Agreement>> GetByCustomerId(Guid customerId)
        {
            return await _DbContext.Agreements.Where(i => i.CustomerId == customerId).ToListAsync();
        }

        public async Task<IEnumerable<Agreement>> GetByDate(DateTime date)
        {
            return await _DbContext.Agreements.Where(i => i.StartDate == date).ToListAsync();
        }

        public async Task<IEnumerable<Agreement>> GetByLotId(Guid lotId)
        {
            return await _DbContext.Agreements.Where(i => i.LotId == lotId).ToListAsync();
        }

        public async Task<IEnumerable<Agreement>> GetByManagerId(Guid managerId)
        {
            var lotManagers = await _DbContext.LotManagers.Where(l => l.ManagerId == managerId).ToListAsync();
            List <Agreement> Agreements = new List<Agreement>();

            foreach (var lot in lotManagers)
            {
                Agreements.Add(await _DbContext.Agreements.Where(i => i.LotId == lot.Id).FirstAsync());
            }

            return Agreements;
        }

        public async Task<IEnumerable<Agreement>> GetByOwnerId(Guid ownerId)
        {
            var lots = await _DbContext.Lots.Where(i => i.OwnerId == ownerId).ToListAsync();
            List<Agreement> Agreements = new List<Agreement>();

            foreach (var lot in lots)
            {
                if(_DbContext.Agreements.Any(a => a.LotId == lot.Id))
                {
                    Agreements.Add(await _DbContext.Agreements.Where(i => i.LotId == lot.Id).FirstAsync());
                }
            }

            return Agreements;
        }

        public int GetQuantity()
        {
            return _DbContext.Lots.Count();
        }
    }
}
