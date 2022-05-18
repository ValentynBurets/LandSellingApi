using Data.Identity.Repository.Base;
using Domain.Entity.Users;

namespace Data.Contract.Repository.Authentication
{
    public interface IManagerRepository : IEntityRepository<Manager>
    {
    }
}
