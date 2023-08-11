using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ClubMemberShip.Repo.Models
{
    public partial class ClubMembershipContext : DbContext
    {
        public ClubMembershipContext()
        {
        }

        public ClubMembershipContext(DbContextOptions<ClubMembershipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<ClubActivity> ClubActivities { get; set; } = null!;
        public virtual DbSet<ClubBoard> ClubBoards { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<MemberRole> MemberRoles { get; set; } = null!;
        public virtual DbSet<Membership> Memberships { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionString"];
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.DateOfEstablishment).HasColumnType("date");

                entity.Property(e => e.Logo)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.LongDecription).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ShortDecription).HasMaxLength(50);
            });

            modelBuilder.Entity<ClubActivity>(entity =>
            {
                entity.ToTable("ClubActivity");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDay).HasColumnType("date");

                entity.Property(e => e.EndDay).HasColumnType("date");

                entity.Property(e => e.StartDay).HasColumnType("date");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.ClubActivities)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClubActivity_Club");
            });

            modelBuilder.Entity<ClubBoard>(entity =>
            {
                entity.ToTable("ClubBoard");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LongDecription).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ShortDecription).HasMaxLength(50);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.ClubBoards)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClubBoard_Club");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ExpeiredYear).HasColumnType("date");

                entity.Property(e => e.GradeYear).HasColumnType("date");

                entity.Property(e => e.GraduateYear).HasColumnType("date");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Detail).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<MemberRole>(entity =>
            {
                entity.HasKey(e => new { e.MembershipId, e.ClubBoardId });

                entity.ToTable("MemberRole");

                entity.Property(e => e.EndDay).HasColumnType("date");

                entity.Property(e => e.StartDay).HasColumnType("date");

                entity.HasOne(d => d.ClubBoard)
                    .WithMany(p => p.MemberRoles)
                    .HasForeignKey(d => d.ClubBoardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberRole_ClubBoard");

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.MemberRoles)
                    .HasForeignKey(d => d.MembershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberRole_Membership");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.ToTable("Membership");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.NickName).HasMaxLength(50);

                entity.Property(e => e.QuitDate).HasColumnType("date");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Club");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Student");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasKey(e => new { e.MembershipId, e.ClubActivityId });

                entity.ToTable("Participant");

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.LeaveDate).HasColumnType("date");

                entity.Property(e => e.RegisterDate).HasColumnType("date");

                entity.HasOne(d => d.ClubActivity)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.ClubActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participant_ClubActivity");

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.MembershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participant_Membership");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Grade");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Major");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
