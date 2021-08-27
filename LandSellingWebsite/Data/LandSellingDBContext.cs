using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LandSellingWebsite.ViewModels.Lot.Favorite;

#nullable disable

namespace LandSellingWebsite.Models
{
    public partial class LandSellingDBContext : DbContext
    {
        public LandSellingDBContext()
        {
        }

        public LandSellingDBContext(DbContextOptions<LandSellingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Land> Lands { get; set; }
        public virtual DbSet<Lot> Lots { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<LotStatusType> LotStatusTypes { get; set; }
        public virtual DbSet<PriceCoef> PriceCoefs { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }
        public virtual DbSet<RentStatusType> RentStatusTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Selling> Sellings { get; set; }
        public virtual DbSet<SellingStatusType> SellingStatusTypes { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<VHouse> VHouses { get; set; }
        public virtual DbSet<VLand> VLands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("LandSellingWebsiteContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.HasIndex(e => new { e.Country, e.Region, e.City }, "ix_person");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Street).HasMaxLength(100);
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("AppUser");

                entity.HasIndex(e => new { e.Name, e.SurName, e.Email, e.Password }, "ix_AppUser");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(100);

                entity.Property(e => e.SurName).HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AppUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__AppUser__RoleId__2739D489");
            });

            modelBuilder.Entity<Bid>(entity =>
            {
                entity.ToTable("Bid");

                entity.HasIndex(e => e.BidderId, "IX_Bid_BidderId");

                entity.HasIndex(e => e.LotId, "IX_Bid_LotId");

                entity.Property(e => e.Value).HasColumnType("money");

                entity.HasOne(d => d.Bidder)
                    .WithMany(p => p.Bids)
                    .HasForeignKey(d => d.BidderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bid__BidderId__3B75D760");

                entity.HasOne(d => d.Lot)
                    .WithMany(p => p.Bids)
                    .HasForeignKey(d => d.LotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bid__LotId__3C69FB99");
            });


            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasOne(d => d.Lot)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.LotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Favorites__LotId__7755B73D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Favorites__LotId__76619304");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.ToTable("House");

                entity.HasIndex(e => e.LotId, "IX_House_LotId");

                entity.HasIndex(e => e.Storeys, "ix_FloorHouse");

                entity.HasIndex(e => new { e.Rooms, e.Storeys, e.Person }, "ix_House");

                entity.HasIndex(e => e.Person, "ix_PersonHouse");

                entity.HasIndex(e => e.Rooms, "ix_RoomsHouse");

                entity.HasOne(d => d.Lot)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.LotId)
                    .HasConstraintName("FK__House__LotId__36B12243");
            });

            modelBuilder.Entity<Land>(entity =>
            {
                entity.ToTable("Land");

                entity.HasIndex(e => e.LotId, "IX_Land_LotId");

                entity.HasOne(d => d.Lot)
                    .WithMany(p => p.Lands)
                    .HasForeignKey(d => d.LotId)
                    .HasConstraintName("FK__Land__LotId__33D4B598");
            });

            modelBuilder.Entity<Lot>(entity =>
            {
                entity.ToTable("Lot");

                entity.HasIndex(e => e.AddressId, "IX_Lot_AddressId");

                entity.HasIndex(e => e.OwnerId, "IX_Lot_OwnerId");

                entity.HasIndex(e => e.PublicationDate, "ix_LotPublicationDate");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.PublicationDate).HasColumnType("date");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Lots)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Lot__AddressId__286302EC");

                entity.HasOne(d => d.LotStatus)
                    .WithMany(p => p.Lots)
                    .HasForeignKey(d => d.LotStatusId)
                    .HasConstraintName("FK__Lot__LotStatusId__14270015");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Lots)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__Lot__OwnerId__29572725");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.ImageData).IsRequired();

                entity.HasOne(d => d.Lot)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.LotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Image__LotId__6BE40491");
            });

            modelBuilder.Entity<LotStatusType>(entity =>
            {
                entity.ToTable("LotStatusType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PriceCoef>(entity =>
            {
                entity.ToTable("PriceCoef");

                entity.HasIndex(e => e.LotId, "IX_PriceCoef_LotId");

                entity.Property(e => e.Value).HasColumnType("smallmoney");

                entity.HasOne(d => d.Lot)
                    .WithMany(p => p.PriceCoefs)
                    .HasForeignKey(d => d.LotId)
                    .HasConstraintName("FK__PriceCoef__LotId__300424B4");
            });

            modelBuilder.Entity<Rent>(entity =>
            {
                entity.ToTable("Rent");

                entity.HasIndex(e => e.CustomerId, "IX_Rent_CustomerId");

                entity.HasIndex(e => e.LotId, "IX_Rent_LotId");

                entity.HasIndex(e => e.ManagerId, "IX_Rent_ManagerId");

                entity.HasIndex(e => e.RentStatusId, "IX_Rent_RentStatusId");

                entity.Property(e => e.BeginDate).HasColumnType("date");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RentCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rent__CustomerId__4AB81AF0");

                entity.HasOne(d => d.Lot)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.LotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rent__LotId__48CFD27E");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.RentManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rent__ManagerId__4BAC3F29");

                entity.HasOne(d => d.RentStatus)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.RentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rent__RentStatus__49C3F6B7");
            });

            modelBuilder.Entity<RentStatusType>(entity =>
            {
                entity.ToTable("RentStatusType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Selling>(entity =>
            {
                entity.ToTable("Selling");

                entity.HasIndex(e => e.BidWinnerId, "IX_Selling_BidWinnerId");

                entity.HasIndex(e => e.LotId, "IX_Selling_LotId");

                entity.HasIndex(e => e.ManagerId, "IX_Selling_ManagerId");

                entity.HasIndex(e => e.SellingStatusId, "IX_Selling_SellingStatusId");

                entity.HasIndex(e => e.MinPrice, "ix_MinPriceSelling");

                entity.Property(e => e.MinPrice).HasColumnType("money");

                entity.Property(e => e.PriceBuyItNow).HasColumnType("money");

                entity.HasOne(d => d.BidWinner)
                    .WithMany(p => p.Sellings)
                    .HasForeignKey(d => d.BidWinnerId)
                    .HasConstraintName("FK__Selling__BidWinn__4316F928");

                entity.HasOne(d => d.Lot)
                    .WithMany(p => p.Sellings)
                    .HasForeignKey(d => d.LotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Selling__LotId__412EB0B6");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Sellings)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__Selling__Manager__4222D4EF");

                entity.HasOne(d => d.SellingStatus)
                    .WithMany(p => p.Sellings)
                    .HasForeignKey(d => d.SellingStatusId)
                    .HasConstraintName("FK__Selling__Selling__440B1D61");
            });

            modelBuilder.Entity<SellingStatusType>(entity =>
            {
                entity.ToTable("SellingStatusType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<VHouse>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vHouse");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.LotStatus)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OwnerName).HasMaxLength(100);

                entity.Property(e => e.OwnerSurName).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(100);

                entity.Property(e => e.PublicationDate).HasColumnType("date");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Street).HasMaxLength(100);
            });

            modelBuilder.Entity<VLand>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vLand");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.LotStatus)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OwnerName).HasMaxLength(100);

                entity.Property(e => e.OwnerSurName).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(100);

                entity.Property(e => e.PublicationDate).HasColumnType("date");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Street).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<LandSellingWebsite.ViewModels.Lot.Favorite.FavoriteViewModel> FavoriteViewModel { get; set; }
    }
}
