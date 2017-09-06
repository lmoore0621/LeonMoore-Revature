using Microsoft.EntityFrameworkCore;

namespace DataNet.ef
{
    public class SqlWeek3 : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=leonrevaturedb.database.windows.net;Database=LeonSqlDDL2;user id=lmoore0621;password=Aol12345=;");
        }

        public class Contact
        {
            public int ContactId { get; set; }
            public string First { get; set; }
            public string Last { get; set; }
        }

        public class Phone
        {
            public int PhoneId { get; set; }
            public Contact Contact { get; set; }
            public string Number { get; set; }
        }

        public class Email
        {
            public int EmailId { get; set; }
            public Contact Contact { get; set; }
            public string Address { get; set; }
        }
    }
}