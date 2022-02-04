using Data.Contract.Repository.Authentication;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;

namespace Data.Repository.Authentication
{
    public class AdminRepository : EntityRepository<Admin>, IAdminRepository
    {
        public AdminRepository(LandSellingContext exerciseDbContext) : base(exerciseDbContext)
        {
        }

    }
}
