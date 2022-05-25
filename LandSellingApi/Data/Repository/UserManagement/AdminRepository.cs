using Data.Contract.Repository.Authentication;
using Data.EF;
using Data.Repository.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Repository.Authentication
{
    public class AdminRepository : EntityRepository<Admin>, IAdminRepository
    {
        public AdminRepository(LandSellingContext exerciseDbContext) : base(exerciseDbContext)
        {
        }

        public async Task<Admin> GetByIdLink(Guid idLink)
        {
            return await _DbContext.Admins.FirstAsync(e => e.IdLink == idLink);
        }
    }
}
