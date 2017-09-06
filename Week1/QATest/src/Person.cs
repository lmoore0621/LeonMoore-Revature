using System;

namespace QATest.src
{
    public class Person
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        // Func<string, string, string> USFullName = (string f, string l) => {return f + " " + l;};
        // Func<string, string, string> EUFullName = (string l, string f) => {return l + " " + f;};

        public delegate string NameFormat(string a, string b);
        public delegate string NameFormatBlank(string a, string b);
        public void DisplayName(NameFormat name) 
        {
            System.Console.WriteLine(name(First, Last));
        }       
    }
}