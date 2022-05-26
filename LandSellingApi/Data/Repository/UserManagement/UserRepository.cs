using Data.Contract.Repository.Authentication;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.Authentication
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(LandSellingContext dbContext) : base(dbContext)
        {
        }
        public async Task<User> GetByIdLink(Guid idLink)
        {
            return await _DbContext.Users.FirstAsync(e => e.IdLink == idLink);
        }

        public async Task<string> GetUserCustomerIdAsync(Guid userId)
        {
            return (await _DbContext.Users.Where(i => i.Id == userId).FirstAsync()).CustomerId;
        }
    }
}
