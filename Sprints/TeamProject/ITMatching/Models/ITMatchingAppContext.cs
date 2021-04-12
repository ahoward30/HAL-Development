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
        public virtual DbSet<FAQ> FAQs { get; set; }
        public virtual DbSet<HelpRequest> HelpRequests { get; set; }
        public virtual DbSet<Itmuser> Itmusers { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ExpertService> ExpertServices { get; set; }
        public virtual DbSet<RequestService> RequestServices { get; set; }
        public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Name=ITMatchingConnection");
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
            });

            modelBuilder.Entity<Expert>(entity =>
            {
                entity.ToTable("Expert");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItmuserId).HasColumnName("ITMUserID");

                entity.Property(e => e.WorkSchedule).HasMaxLength(60);
            });

            modelBuilder.Entity<ExpertFeedback>(entity =>
            {
                entity.ToTable("ExpertFeedback");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ExpertId).HasColumnName("ExpertID");

                entity.Property(e => e.FeedbackText).HasMaxLength(100);
            });

            modelBuilder.Entity<FAQ>(entity =>
            {
                entity.ToTable("FAQ");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<HelpRequest>(entity =>
            {
                entity.ToTable("HelpRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.RequestDescription).HasMaxLength(2000);

                entity.Property(e => e.RequestTitle).HasMaxLength(40);

                entity.Property(e => e.IsOpen).HasColumnName("IsOpen");

            });

            modelBuilder.Entity<Itmuser>(entity =>
            {
                entity.ToTable("ITMUser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AspNetUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PhoneNumber).HasMaxLength(13);

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.ToTable("Meeting");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ExpertId).HasColumnName("ExpertID");

                entity.Property(e => e.HelpRequestId).HasColumnName("HelpRequestID");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ServiceCategory)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ExpertService>(entity =>
            {
                entity.ToTable("ExpertService");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<RequestService>(entity =>
            {
                entity.ToTable("RequestService");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<WorkSchedule>(entity =>
            {
                entity.ToTable("WorkSchedule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Day).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
