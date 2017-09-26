using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void PersonLib()
        {
            var ps = new List<Person>()
            {
                new Person{ FName = "fred1", LName = "belotte1"},
                new Person{ FName = "fred2", LName = "belotte2"},
                new Person{ FName = "fred3", LName = "belotte3"}
            };
        }
    }
}
