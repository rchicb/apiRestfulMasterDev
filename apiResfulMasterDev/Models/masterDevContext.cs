using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apiResfulMasterDev.Models
{
    public partial class masterDevContext : DbContext
    {
        public masterDevContext()
        {
        }

        public masterDevContext(DbContextOptions<masterDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Credential> Credential { get; set; }
        public virtual DbSet<Message> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AMS7JKJ\\MSSQLSERVER01;Database=masterDev;Trusted_Connection=True;User=connection;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credential>(entity =>
            {
                entity.ToTable("credential");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Sharedsecret)
                    .IsRequired()
                    .HasColumnName("sharedsecret")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Userkey)
                    .IsRequired()
                    .HasColumnName("userkey")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasColumnName("tag")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
