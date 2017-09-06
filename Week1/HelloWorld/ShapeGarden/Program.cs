using System;
using ShapeGarden.Abstracts;
using ShapeGarden.Interfaces;
using ShapeGarden.Models;

namespace ShapeGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            
            
            PlayWithShapes();
            
        }

        public static void PlayWithShapes()
        {
            Rectangle r1 = new Rectangle();
            AShape a1 = new Square();
            var a2 = new Square();
            IShape i1 = new Triangle();
            Object o = 10;
            int i = (int)o;
            int i2 = (int)((Object)a2);

            var arr1 = new AShape[] {r1, a1, a2};
            PrintShapes(arr1);
            PrintShapes(r1);
            PrintShapes(a1, a2, arr1);

            System.Console.WriteLine(r1.Sides);
        }

        public static void PrintShapes(params IShape[] r)
        {
            try 
            {
                foreach (AShape item in r)
                {
                    System.Console.WriteLine(item.Sides);
                }
            }
            catch (NullReferenceException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("message", ex);
            }
            finally
            {

            }
        }
    }
}