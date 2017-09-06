using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractTest
{
    class Program
    {
            abstract class ShapesClass
            {
                abstract public int Area();
            }
            class Square : ShapesClass
            {
                int side = 0;

                public Square(int n)
                {
                    side = n;
                }
                // Area method is required to avoid
                // a compile-time error.
                public override int Area()
                {
                    return side * side;
                }

                static void Main()
                {
                    Square sq = new Square(12);
                    Console.WriteLine("Area of the square = {0}", sq.Area());
                }

                interface I
                {
                    void M();
                }
                abstract class C : I
                {
                    public abstract void M();
                }

            }
            // Output: Area of the square = 144
    }
}

