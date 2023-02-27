using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Educational.DataContracts.Models
{
    public partial class EducationalContext : DbContext
    {
        public EducationalContext()
        {
        }

        public EducationalContext(DbContextOptions<EducationalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAuthor> TbAuthors { get; set; } = null!;
        public virtual DbSet<TbCategory> TbCategories { get; set; } = null!;
        public virtual DbSet<TbCertification> TbCertifications { get; set; } = null!;
        public virtual DbSet<TbCity> TbCities { get; set; } = null!;
        public virtual DbSet<TbCountry> TbCountries { get; set; } = null!;
        public virtual DbSet<TbCoupon> TbCoupons { get; set; } = null!;
        public virtual DbSet<TbCourseDetail> TbCourseDetails { get; set; } = null!;
        public virtual DbSet<TbProfile> TbProfiles { get; set; } = null!;
        public virtual DbSet<TbReview> TbReviews { get; set; } = null!;
        public virtual DbSet<TbState> TbStates { get; set; } = null!;
        public virtual DbSet<TbTutor> TbTutors { get; set; } = null!;
        public virtual DbSet<TbUser> TbUsers { get; set; } = null!;

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAuthor>(entity =>
            {
                entity.HasKey(e => e.AuthorId);

                entity.ToTable("TB_Author");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("TB_Category");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(50);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCertification>(entity =>
            {
                entity.HasKey(e => e.CertificateId);

                entity.ToTable("TB_Certification");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TbCertifications)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_TB_Certification_TB_CourseDetails");

                entity.HasOne(d => d.Tutor)
                    .WithMany(p => p.TbCertifications)
                    .HasForeignKey(d => d.TutorId)
                    .HasConstraintName("FK_TB_Certification_TB_Tutor");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TbCertifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TB_Certification_TB_User");
            });

            modelBuilder.Entity<TbCity>(entity =>
            {
                entity.ToTable("TB_City");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCountry>(entity =>
            {
                entity.ToTable("TB_Country");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCoupon>(entity =>
            {
                entity.HasKey(e => e.CouponId);

                entity.ToTable("TB_Coupon");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.PurposeOfCoupon)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCourseDetail>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.ToTable("TB_CourseDetails");

                entity.Property(e => e.CourseImageUrl)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.CourseName)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Price).HasMaxLength(50);
            });

            modelBuilder.Entity<TbProfile>(entity =>
            {
                entity.HasKey(e => e.ProfileId);

                entity.ToTable("TB_Profile");

                entity.Property(e => e.ProfileId).HasColumnName("profileId");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<TbReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId);

                entity.ToTable("TB_Review");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.ReviewCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ReviewerEmail).HasMaxLength(50);

                entity.Property(e => e.ReviewerName).HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TbReviews)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_TB_Review_TB_Review");
            });

            modelBuilder.Entity<TbState>(entity =>
            {
                entity.ToTable("TB_State");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbTutor>(entity =>
            {
                entity.HasKey(e => e.Tutorid);

                entity.ToTable("TB_Tutor");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("TB_User");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
