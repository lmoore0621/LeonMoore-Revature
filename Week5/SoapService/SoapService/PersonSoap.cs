using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoapService
{
    public class PersonSoap
    {
        [DataMember]
        public string FName { get; set; }
        [DataMember]
        public string LName { get; set; }
    }
}