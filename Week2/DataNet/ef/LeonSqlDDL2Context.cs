using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataNet
{
    public partial class LeonSqlDDL2Context : DbContext
    {
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<email> email { get; set; }
        public virtual DbSet<Emails> Emails { get; set; }
        public virtual DbSet<Phones> Phones { get; set; }

        // Unable to generate entity type for table 'book.contact'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"data source=leonrevaturedb.database.windows.net;initial catalog=LeonSqlDDL2;user id=lmoore0621;Password=Aol12345=;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.ContactId);
            });

            modelBuilder.Entity<email>(entity =>
            {
                entity.ToTable("email", "book");

                entity.Property(e => e.EmailId).HasColumnName("emailID");

                entity.Property(e => e.ActiveFlag)
                    .HasColumnName("activeFlag")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(300);

                entity.Property(e => e.ChangeDate)
                    .HasColumnName("changeDate")
                    .HasComputedColumnSql("(sysutcdatetime())");

                entity.Property(e => e.ContactId).HasColumnName("contactID");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");
            });

            modelBuilder.Entity<Emails>(entity =>
            {
                entity.HasKey(e => e.EmailId);

                entity.HasIndex(e => e.ContactId);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.ContactId);
            });

            modelBuilder.Entity<Phones>(entity =>
            {
                entity.HasKey(e => e.PhoneId);

                entity.HasIndex(e => e.ContactId);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.ContactId);
            });
        }
    }
}
