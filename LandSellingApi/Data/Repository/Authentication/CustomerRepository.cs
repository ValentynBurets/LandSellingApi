using Data.Contract.Repository.Authentication;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;

namespace Data.Repository.Authentication
{
    public class CustomerRepository : EntityRepository<Person>, ICustomerRepository
    {
        public CustomerRepository(LandSellingContext exerciseDbContext) : base(exerciseDbContext)
        {
        }

    }
}
