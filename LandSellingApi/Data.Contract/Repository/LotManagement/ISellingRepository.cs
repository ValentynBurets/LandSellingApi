using Data.Identity.Repository.Base;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contract.Repository.LotManagement
{
    public interface ISellingRepository : IEntityRepository<Selling>
    {
        Task<Selling> GetByLotId(Guid lotId);
        Task<Selling> GetByCustomerId(Guid customerId);
        Task<Selling> GetByMangerId(Guid managerId);
        Task<IEnumerable<Selling>> GetBySellingPrice();
    }
}
