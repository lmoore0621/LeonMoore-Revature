using System;
using System.Collections.Generic;
using QATest.test;

namespace QATest.src
{
    public static class Contacts
    {
        private static List<Person> pList = new List<Person>();

        public static bool Add(Person p)
        {
            try
            {
                pList.Add(p);    
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static Person Update(Person p)
        {
            var co = pList.Find(c => c.Id == p.Id);
            if (co != null)
            {
                co = p;
            }
                return co;
        }

        public static void Delete()
        {

        }

        public static List<Person> List()
        {
            return pList;
        }
    }
}