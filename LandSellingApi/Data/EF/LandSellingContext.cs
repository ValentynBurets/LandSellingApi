using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.EF
{
    public class LandSellingContext: DbContext
    {
        public LandSellingContext(DbContextOptions<LandSellingContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Customer
            modelBuilder.Entity<Customer>()
                .HasIndex(i => i.Id)
                .IsUnique(true);

            //Admin
            modelBuilder.Entity<Admin>()
                .HasIndex(i => i.Id)
                .IsUnique(true);

        }
    }
}
