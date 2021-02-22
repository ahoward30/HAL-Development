using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ITMatching.Models
{
    public partial class ITMatchingAppContext : DbContext
    {
        public ITMatchingAppContext()
        {
        }

        public ITMatchingAppContext(DbContextOptions<ITMatchingAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Expert> Experts { get; set; }
        public virtual DbSet<ExpertFeedback> ExpertFeedbacks { get; set; }
        public virtual DbSet<Itmuser> Itmusers { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceTag> ServiceTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=IT-MatchingApp;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItmuserId).HasColumnName("ITMUserID");

                entity.HasOne(d => d.Itmuser)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ItmuserId)
                    .HasConstraintName("FK__Client__ITMUserI__38996AB5");
            });

            modelBuilder.Entity<Expert>(entity =>
            {
                entity.ToTable("Expert");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItmuserId).HasColumnName("ITMUserID");

                entity.Property(e => e.WorkSchedule)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.HasOne(d => d.Itmuser)
                    .WithMany(p => p.Experts)
                    .HasForeignKey(d => d.ItmuserId)
                    .HasConstraintName("FK__Expert__ITMUserI__3B75D760");
            });

            modelBuilder.Entity<ExpertFeedback>(entity =>
            {
                entity.ToTable("Expert_Feedback");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FeedbackText).HasMaxLength(100);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ExpertFeedbacks)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Expert_Fe__Clien__49C3F6B7");

                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.ExpertFeedbacks)
                    .HasForeignKey(d => d.ExpertId)
                    .HasConstraintName("FK__Expert_Fe__Exper__48CFD27E");
            });

            modelBuilder.Entity<Itmuser>(entity =>
            {
                entity.ToTable("ITMUsers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AspnetUserId)
                    .IsRequired()
                    .HasMaxLength(900)
                    .HasColumnName("ASPNetUserId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.ToTable("Meeting");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Meeting__ClientI__45F365D3");

                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.ExpertId)
                    .HasConstraintName("FK__Meeting__ExpertI__44FF419A");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Meeting__Service__440B1D61");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ServiceTag>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.ServiceTags)
                    .HasForeignKey(d => d.ExpertId)
                    .HasConstraintName("FK__ServiceTa__Exper__412EB0B6");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceTags)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__ServiceTa__Exper__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
