using Data.Identity.Repository.Base;
using Domain.Entity;

namespace Data.Contract.Repository.Authentication
{
    public interface IAdminRepository : IEntityRepository<Admin>
    {
    }
}
