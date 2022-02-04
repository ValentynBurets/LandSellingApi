using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Identity
{
    public class LandSellingIdentityContext : IdentityDbContext<AuthorisationUser>
    {
        public LandSellingIdentityContext(DbContextOptions<LandSellingIdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
