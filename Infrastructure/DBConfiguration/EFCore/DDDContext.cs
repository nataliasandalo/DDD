using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.DBConfiguration.EFCore
{
    public partial class DDDContext : DbContext
    {
        public DDDContext()
        {
        }

        public DDDContext(DbContextOptions<DDDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-16JNG16A\\SQLEXPRESS01; Database=DDD; TrustServerCertificate=True;MultipleActiveResultSets=False;Encrypt=True;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Address1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Address");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Postalcode)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__IdUser__267ABA7A");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("VALUE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
