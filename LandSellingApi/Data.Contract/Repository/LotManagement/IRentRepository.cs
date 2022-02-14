using Data.Identity.Repository.Base;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contract.Repository.LotManagement
{
    public interface IRentRepository : IEntityRepository<Rent>
    {
        Task<Rent> GetByCustomerId(Guid customerId);
        Task<Rent> GetByManagerId(Guid managerId);
        Task<Rent> GetByLotId(Guid lotId);
        Task<Rent> GetByPriceCoefId(Guid priceCoefId);
        Task<IEnumerable<Rent>> GetByBeginDateRaising(DateTime date);
        Task<IEnumerable<Rent>> GetByEndDateRaising(DateTime date);
        Task<IEnumerable<Rent>> GetByBeginDateDescending(DateTime date);
        Task<IEnumerable<Rent>> GetByEndDateDescending(DateTime date);
    }
}
