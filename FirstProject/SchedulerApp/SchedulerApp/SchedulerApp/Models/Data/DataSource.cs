using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using SchedulerApp.Models.Model;

namespace SchedulerApp.Models.Data
{
    public class DataSource : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<Member>());
            Configure(modelBuilder.Entity<Course>());
        }

        private void Configure(EntityTypeConfiguration<Member> entity)
        {
            entity.ToTable("Members");
            entity.HasKey(m => m.Id);
            entity.Property(m => m.RoleName).HasMaxLength(50).IsRequired();
            entity.Property(m => m.Username).HasMaxLength(50).IsRequired();
            entity.Property(m => m.Password).HasMaxLength(50).IsRequired();
            entity.Property(m => m.FirstName).HasMaxLength(50).IsRequired();
            entity.Property(m => m.LastName).HasMaxLength(50).IsRequired();
        }

        private void Configure(EntityTypeConfiguration<Course> entity)
        {
            entity.ToTable("Courses");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).HasMaxLength(75).IsRequired();
            entity.Property(c => c.StartDate).HasColumnType("date");
            entity.Property(c => c.EndDate).HasColumnType("date");
            entity.Property(c => c.StartTime).HasColumnType("time");

            entity.HasMany(c => c.Students).WithMany(s => s.StudentCourses).Map(m => { m.ToTable("StudentCourses"); m.MapLeftKey("StudentId"); m.MapRightKey("CourseId"); });
            entity.HasOptional(c => c.Professor).WithMany(p => p.ProfessorCourses).HasForeignKey(c => c.ProfessorId).WillCascadeOnDelete(false);
        }
    }
}
