using System;
using ShapeGarden.Interfaces;

namespace ShapeGarden.Models
{
    public class ShapeList<T> where T : class, IShape
    {
        private T[] collection = new T[int.MaxValue];
        private int count = 0;
        
        public void Add(T u)
        {
            collection[count] = u;
            count += 1;
        }

        public void Remove(T u)
        {
            T temp;

            foreach (var i in collection)
            {
                if(i.Sides == u.Sides)
                {
                    temp = i;
                    break;
                }
            }
            temp = null;
        }
    }

    public class WorkWithGenerics
    {
        public void Play()
        {
            var g = new ShapeList<int>();

            g.Add(5);
            g.Remove(10);
        }
    }
}