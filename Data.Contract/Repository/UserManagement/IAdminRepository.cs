using Data.Identity.Repository.Base;
using Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Data.Contract.Repository.Authentication
{
    public interface IAdminRepository : IEntityRepository<Admin>
    {
        public Task<Admin> GetByIdLink(Guid idLink);
    }
}
