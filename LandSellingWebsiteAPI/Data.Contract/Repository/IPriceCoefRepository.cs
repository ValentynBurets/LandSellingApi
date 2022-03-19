using Data.Identity.Repository.Base;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contract.Repository
{
    public interface IPriceCoefRepository : IEntityRepository<PriceCoef>
    {
        Task<IEnumerable<PriceCoef>> GetByLotId(Guid lotId);
        Task<IEnumerable<PriceCoef>> GetByDaysCount(int daysCount);
        Task<IEnumerable<PriceCoef>> GetByValue(decimal value);
    }
}
