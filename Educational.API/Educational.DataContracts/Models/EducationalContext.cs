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
        public virtual DbSet<TbCourseDetail> TbCourseDetails { get; set; } = null!;
        public virtual DbSet<TbProfile> TbProfiles { get; set; } = null!;
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

            modelBuilder.Entity<TbCourseDetail>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.ToTable("TB_CourseDetails");

                entity.Property(e => e.CourseImageUrl).HasMaxLength(50);

                entity.Property(e => e.CourseName).HasMaxLength(50);

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
