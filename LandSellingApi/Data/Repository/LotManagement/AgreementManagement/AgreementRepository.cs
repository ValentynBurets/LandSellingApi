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

        public async Task<IEnumerable<Agreement>> GetByMangerId(Guid managerId)
        {
            var lots = await _DbContext.Lots.Where(i => i.ManagerId == managerId).ToListAsync();
            List <Agreement> Agreements = new List<Agreement>();

            foreach (var lot in lots)
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
                Agreements.Add(await _DbContext.Agreements.Where(i => i.LotId == lot.Id).FirstAsync());
            }

            return Agreements;
        }
    }
}
