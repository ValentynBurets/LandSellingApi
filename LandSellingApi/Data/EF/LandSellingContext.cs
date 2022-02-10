using Domain.Entity;
using Domain.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace Data.EF
{
    public class LandSellingContext : DbContext
    {
        public LandSellingContext(DbContextOptions<LandSellingContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer(
                x => x.UseNetTopologySuite());
        }

        public virtual DbSet<Customer> Customers{ get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Lot> Lots { get; set; }
        public virtual DbSet<RealEstate> RealEstates { get; set; }
        public virtual DbSet<PriceCoef> PriceCoefs { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Selling> Sellings { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }
     
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
            modelBuilder.Entity<Lot>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Owner)
                .WithMany(b => b.Lots)
                .IsRequired(true)
                .HasForeignKey(k => k.OwnerId);

                entity.HasOne(p => p.Manager)
                .WithMany(b => b.Lots)
                .IsRequired(true)
                .HasForeignKey(k => k.ManagerId);
            });

            //RealEstate
            modelBuilder.Entity<RealEstate>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique(true);

                entity.HasOne(p => p.Lot)
                .WithOne(b => b.RealEstate)
                .IsRequired(false)
                .HasForeignKey<RealEstate>(k => k.LotId);
            });

            //Price Coef
            modelBuilder.Entity<PriceCoef>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Lot)
                .WithMany(b => b.PriceCoefs)
                .IsRequired(false)
                .HasForeignKey(k => k.LotId);
            });

            //Image
            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Lot)
                .WithMany(b => b.Images)
                .HasForeignKey(k => k.LotId);
            });
         
            //Favorites
            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Customer)
                .WithMany()
                .HasForeignKey(k => k.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Lot)
                .WithMany()
                .HasForeignKey(k => k.LotId)
                .OnDelete(DeleteBehavior.Restrict);
  
            });

            //Bid
            modelBuilder.Entity<Bid>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Selling)
                .WithMany(b => b.Bids)
                .HasForeignKey(k => k.SellingId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(p => p.Bidder)
                .WithMany(b => b.Bids)
                .HasForeignKey(k => k.BidderId);
            });

            //Selling 
            modelBuilder.Entity<Selling>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Lot)
                .WithOne(b => b.Selling)
                .HasForeignKey<Selling>(k => k.LotId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(p => p.Customer)
                .WithMany(b => b.Sellings)
                .HasForeignKey(k => k.CustomerId);

                entity.HasOne(p => p.Manager)
                .WithMany(b => b.Sellings)
                .HasForeignKey(k => k.ManagerId);
            });

            //Rent 
            modelBuilder.Entity<Rent>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Lot)
                .WithMany(b => b.Rents)
                .HasForeignKey(k => k.LotId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(p => p.Customer)
                .WithMany(b => b.Rents)
                .HasForeignKey(k => k.CustomerId);

                entity.HasOne(p => p.Manager)
                .WithMany(b => b.Rents)
                .HasForeignKey(k => k.ManagerId);

                entity.HasOne(p => p.PriceCoef)
                .WithOne(b => b.Rent)
                .HasForeignKey<Rent>(k => k.PriceCoefId);
            });
        }
    }
}
