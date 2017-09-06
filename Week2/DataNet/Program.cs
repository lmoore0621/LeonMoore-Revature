using System;
using System.Linq;
using DataNet.ado;
using DataNet.ef;
using static DataNet.ef.SqlWeek3;

namespace DataNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //PlayWithAdo();
            PlayWithEFCodeFirst();
        }

        public static void PlayWithAdo()
        {
            var ado = new AdoData();
            ado.ReadConnected();
        }

        public static void PlayWithEFCodeFirst()
        {
            var ef = new SqlWeek3();

            ef.Contacts.Add(new Contact() {First = "Leon", Last = "Moore"});
            ef.SaveChanges();

            var contacts = ef.Contacts.ToList();
            System.Console.WriteLine(contacts.First());
        }

        public static void PlayWithDatabaseFirst()
        {
            var ef = new LeonSqlDDL2Context();

            ef.Contacts.Add(new Contact)
        }
    }
}
