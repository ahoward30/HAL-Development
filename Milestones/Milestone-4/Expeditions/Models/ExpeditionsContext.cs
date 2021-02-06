using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Expeditions.Models
{
    public partial class ExpeditionsContext : DbContext
    {
        public ExpeditionsContext()
        {
        }

        public ExpeditionsContext(DbContextOptions<ExpeditionsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Expedition> Expeditions { get; set; }
        public virtual DbSet<Peak> Peaks { get; set; }
        public virtual DbSet<TrekkingAgency> TrekkingAgencies { get; set; }
        public virtual DbSet<FAQ> FAQs { get; set; }
        public virtual DbSet<Newsfeed> Newsfeeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Name=ExpeditionsConnectionAzure");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expedition>(entity =>
            {
                entity.ToTable("Expedition");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PeakId).HasColumnName("PeakID");

                entity.Property(e => e.Season).HasMaxLength(10);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TerminationReason).HasMaxLength(80);

                entity.Property(e => e.TrekkingAgencyId).HasColumnName("TrekkingAgencyID");

                entity.HasOne(d => d.Peak)
                    .WithMany(p => p.Expeditions)
                    .HasForeignKey(d => d.PeakId)
                    .HasConstraintName("Expedition_FK_Peak");

                entity.HasOne(d => d.TrekkingAgency)
                    .WithMany(p => p.Expeditions)
                    .HasForeignKey(d => d.TrekkingAgencyId)
                    .HasConstraintName("Expedition_FK_TrekkingAgency");
            });

            modelBuilder.Entity<Peak>(entity =>
            {
                entity.ToTable("Peak");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TrekkingAgency>(entity =>
            {
                entity.ToTable("TrekkingAgency");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<FAQ>(entity =>
            {
                entity.ToTable("FAQ");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Question).HasMaxLength(500);

                entity.Property(e => e.Answer).HasMaxLength(500);
            });

            modelBuilder.Entity<Newsfeed>(entity =>
            {
                entity.ToTable("Newsfeed");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.Content).HasMaxLength(int.MaxValue);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
