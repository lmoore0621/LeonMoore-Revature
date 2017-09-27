using Microsoft.EntityFrameworkCore;
using SchedulerApp.Domain;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchedulerApp.Data
{
    public class DataSource : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;initial catalog=SchedulerDb;integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<Member>());
            Configure(modelBuilder.Entity<Course>());
            Configure(modelBuilder.Entity<StudentCourses>());
        }

        private void Configure(EntityTypeBuilder<Member> entity)
        {
            entity.ToTable("Members");
            entity.HasKey(m => m.Id);
            entity.Property(m => m.RoleName).HasMaxLength(50).IsRequired();
            entity.Property(m => m.Username).HasMaxLength(50).IsRequired();
            entity.Property(m => m.Password).HasMaxLength(50).IsRequired();
            entity.Property(m => m.FirstName).HasMaxLength(50).IsRequired();
            entity.Property(m => m.LastName).HasMaxLength(50).IsRequired();

            entity.HasMany(m => m.StudentCourses).WithOne(sc => sc.Student).HasForeignKey(sc => sc.StudentId);
            entity.HasMany(m => m.ProfessorCourses).WithOne(c => c.Professor).HasForeignKey(c => c.ProfessorId).OnDelete(DeleteBehavior.Restrict);
        }

        private void Configure(EntityTypeBuilder<Course> entity)
        {
            entity.ToTable("Courses");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).HasMaxLength(75).IsRequired();
            entity.Property(c => c.StartDate).HasColumnType("date");
            entity.Property(c => c.EndDate).HasColumnType("date");
            entity.Property(c => c.StartTime).HasColumnType("time");

            entity.HasMany(c => c.StudentCourses).WithOne(sc => sc.Course).HasForeignKey(sc => sc.CourseId);
        }

        private void Configure(EntityTypeBuilder<StudentCourses> entity)
        {
            entity.ToTable("StudentCourses");
            entity.HasKey(sc => new { sc.StudentId, sc.CourseId });
        }
    }
}
