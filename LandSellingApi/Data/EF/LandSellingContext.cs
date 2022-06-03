using Domain.Entity;
using Domain.Entity.LotManagement;
using Domain.Entity.LotManagement.AgreementManagement;
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

        public virtual DbSet<User> Users{ get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Lot> Lots { get; set; }
        public virtual DbSet<PriceCoef> PriceCoefs { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Agreement> Agreements { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<LotManager> LotManagers { get; set; }
        public virtual DbSet<AgreementManager> AgreementManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //User
            modelBuilder.Entity<User>()
                .HasIndex(i => i.Id)
                .IsUnique(true);

            //Admin
            modelBuilder.Entity<Admin>()
                .HasIndex(i => i.Id)
                .IsUnique(true);

            //Location
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Lot)
                .WithOne(b => b.Location)
                .IsRequired(true)
                .HasForeignKey<Lot>(l => l.LocationId);
            });

            //Lot
            modelBuilder.Entity<Lot>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Owner)
                .WithMany(b => b.Lots)
                .IsRequired(true)
                .HasForeignKey(k => k.OwnerId);
            });

            //LotManager
            modelBuilder.Entity<LotManager>(entity =>
            {
                entity.HasIndex(i => i.Id)
               .IsUnique();

                entity.HasOne(p => p.Lot)
               .WithMany(b => b.LotManagers)
               .IsRequired(true)
               .HasForeignKey(k => k.ManagerId);

                entity.HasOne(p => p.Manager)
               .WithMany(b => b.LotManagers)
               .IsRequired(true)
               .HasForeignKey(k => k.ManagerId);
            });

            //AgreementManager
            modelBuilder.Entity<AgreementManager>(entity =>
            {
                entity.HasIndex(i => i.Id)
               .IsUnique();

                entity.HasOne(p => p.Agreement)
               .WithMany(b => b.AgreementManagers)
               .IsRequired(true)
               .HasForeignKey(k => k.ManagerId);

                entity.HasOne(p => p.Manager)
               .WithMany(b => b.AgreementManagers)
               .IsRequired(true)
               .HasForeignKey(k => k.ManagerId);
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

            //Bid
            modelBuilder.Entity<Bid>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Lot)
                .WithMany(b => b.Bids)
                .HasForeignKey(k => k.LotId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(p => p.Bidder)
                .WithMany(b => b.Bids)
                .HasForeignKey(k => k.BidderId);
            });

            //Agreement
            modelBuilder.Entity<Agreement>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Lot)
                .WithOne(b => b.Agreement)
                .HasForeignKey<Agreement>(k => k.LotId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(p => p.Customer)
                .WithMany(b => b.Agreements)
                .HasForeignKey(k => k.CustomerId);
            });

            //Payment
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasIndex(i => i.Id)
                .IsUnique();

                entity.HasOne(p => p.Agreement)
                .WithMany(b => b.Payments)
                .HasForeignKey(k => k.AgreementId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(p => p.User)
                .WithMany(b => b.Payments)
                .HasForeignKey(k => k.UserId);
            });

        }
    }
}
