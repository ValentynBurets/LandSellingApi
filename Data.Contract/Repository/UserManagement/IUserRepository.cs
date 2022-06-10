using Data.Identity.Repository.Base;
using Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Data.Contract.Repository.Authentication
{
    public interface IUserRepository : IEntityRepository<User>
    {
        public Task<User> GetByIdLink(Guid idLink);
        public Task<Guid> GeIdLinkById(Guid id);
        Task<string> GetByUserIdAsync(Guid userId);
    }
}
