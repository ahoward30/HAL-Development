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
        public virtual DbSet<ExpertService> ExpertServices { get; set; }
        public virtual DbSet<Faq> Faqs { get; set; }
        public virtual DbSet<HelpRequest> HelpRequests { get; set; }
        public virtual DbSet<Itmuser> Itmusers { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<PotentialMatch> PotentialMatches { get; set; }
        public virtual DbSet<RequestSchedule> RequestSchedules { get; set; }
        public virtual DbSet<RequestService> RequestServices { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ITMatchingConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasOne(d => d.Itmuser)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ItmuserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_ITMUserID");
            });

            modelBuilder.Entity<Expert>(entity =>
            {
                entity.HasOne(d => d.Itmuser)
                    .WithMany(p => p.Experts)
                    .HasForeignKey(d => d.ItmuserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expert_ITMUserID");
            });

            modelBuilder.Entity<ExpertFeedback>(entity =>
            {
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ExpertFeedbacks)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExpertFeedback_ClientID");

                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.ExpertFeedbacks)
                    .HasForeignKey(d => d.ExpertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExpertFeedback_ExpertID");
            });

            modelBuilder.Entity<ExpertService>(entity =>
            {
                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.ExpertServices)
                    .HasForeignKey(d => d.ExpertId)
                    .HasConstraintName("FK_ExpertService_ExpertId");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ExpertServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExpertService_ServiceId");
            });

            modelBuilder.Entity<Itmuser>(entity =>
            {
                entity.Property(e => e.UserName).IsUnicode(false);
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.HasOne(d => d.HelpRequest)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.HelpRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meeting_HelpRequestID");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_MeetingID");
            });

            modelBuilder.Entity<PotentialMatch>(entity =>
            {
                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.PotentialMatches)
                    .HasForeignKey(d => d.ExpertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PotentialMatch_ExpertID");

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.PotentialMatches)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PotentialMatch_MeetingID");
            });

            modelBuilder.Entity<RequestSchedule>(entity =>
            {
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.RequestSchedules)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestSchedule_ClientId");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestSchedules)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestSchedule_RequestId");
            });

            modelBuilder.Entity<RequestService>(entity =>
            {
                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestServices)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_RequestService_ServiceId");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.RequestServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestService_RequestId");
            });

            modelBuilder.Entity<WorkSchedule>(entity =>
            {
                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.WorkSchedules)
                    .HasForeignKey(d => d.ExpertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkSchedule_ExpertId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
