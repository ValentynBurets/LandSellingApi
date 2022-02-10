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
        Task<IEnumerable<Rent>> GetByDate(DateTime date);
    }
}
