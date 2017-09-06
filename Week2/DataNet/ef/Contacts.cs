using System;
using System.Collections.Generic;

namespace DataNet
{
    public partial class Contacts
    {
        public Contacts()
        {
            Emails = new HashSet<Emails>();
            Phones = new HashSet<Phones>();
        }

        public int ContactId { get; set; }
        public string First { get; set; }
        public string Last { get; set; }

        public ICollection<Emails> Emails { get; set; }
        public ICollection<Phones> Phones { get; set; }
    }
}
