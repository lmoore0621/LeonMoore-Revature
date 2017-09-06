using System.Collections.Generic;

namespace TodoList.src
{
    public static class List
    {
        private static List<Todo> tList = new List<Todo>();

        public static bool Create(Todo todo)
        {
            try
            {
                tList.Add(todo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void Read(int id)
        {

        }

        public static void Update(Todo t)
        {

        }

        public static void Delete()
        {

        }

        public static void Complete()
        {

        }
    }
}