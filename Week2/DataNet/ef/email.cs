using System;
using System.Collections.Generic;

namespace DataNet
{
    public partial class email
    {
        public int EmailId { get; set; }
        public int ContactId { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public bool? ActiveFlag { get; set; }
    }
}
