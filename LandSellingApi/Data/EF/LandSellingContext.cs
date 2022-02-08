using Domain.Entity;
using Domain.Entity.Users;
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

            //Manager
            modelBuilder.Entity<Manager>()
                .HasIndex(i => i.Id)
                .IsUnique();
            
            //Lot
            modelBuilder.Entity<Lot>()
                .HasIndex(i => i.Id)
                .IsUnique();

            modelBuilder.Entity<Lot>()
                .HasOne(p => p.Owner)
                .WithMany(b => b.Lots)
                .IsRequired(true)
                .HasForeignKey(k => k.OwnerId);

            modelBuilder.Entity<Lot>()
                .HasOne(p => p.Manager)
                .WithMany(b => b.Lots)
                .IsRequired(true)
                .HasForeignKey(k => k.OwnerId);

            //House
            modelBuilder.Entity<House>()
                .HasIndex(i => i.Id)
                .IsUnique(true);

            modelBuilder.Entity<House>()
                .HasOne(p => p.Lot)
                .WithOne(b => b.House)
                .IsRequired(false)
                .HasForeignKey<House>(k => k.LotId);

            //Price Coef

            modelBuilder.Entity<PriceCoef>()
                .HasIndex(i => i.Id)
                .IsUnique();

            modelBuilder.Entity<PriceCoef>()
                .HasOne(p => p.Lot)
                .WithMany(b => b.PriceCoefs)
                .IsRequired(false)
                .HasForeignKey(k => k.LotId);

            //Image
            modelBuilder.Entity<Image>()
                .HasOne(p => p.Lot)
                .WithMany(b => b.Images);

            modelBuilder.Entity<Favorite>()
                .HasIndex(i => i.Id)
                .IsUnique();

            //Favorites
            modelBuilder.Entity<Favorite>()
                .HasIndex(i => i.Id)
                .IsUnique();

            modelBuilder.Entity<Favorite>()
                .HasOne(p => p.Customer)
                .WithMany(b => b.Favorites)
                .HasForeignKey(k => k.CustomerId);

            modelBuilder.Entity<Favorite>()
                .HasOne(p => p.Lot)
                .WithMany(b => b.Favorites)
                .HasForeignKey(k => k.LotId);
                
        }
    }
}
