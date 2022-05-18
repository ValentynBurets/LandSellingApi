using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Identity
{
    public class DesignTimeIdentityContext : IDesignTimeDbContextFactory<LandSellingIdentityContext>
    {
        public LandSellingIdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LandSellingIdentityContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=LandSellingIdentityContext;Integrated Security=True");
            return new LandSellingIdentityContext(optionsBuilder.Options);
        }
    }
}

