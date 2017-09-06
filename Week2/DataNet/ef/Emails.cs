using System;
using System.Collections.Generic;

namespace DataNet
{
    public partial class Emails
    {
        public int EmailId { get; set; }
        public string Address { get; set; }
        public int? ContactId { get; set; }

        public Contacts Contact { get; set; }
    }
}
