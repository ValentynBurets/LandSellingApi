using Data.Contract.Repository.Authentication;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;

namespace Data.Repository.Authentication
{
    public class UserRepository : EntityRepository<Person>, IUserRepository
    {
        public UserRepository(LandSellingContext exerciseDbContext) : base(exerciseDbContext)
        {
        }

    }
}
