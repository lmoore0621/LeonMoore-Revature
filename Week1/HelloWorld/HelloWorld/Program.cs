using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            int Fizz = 0;
            int Buzz = 0;
            int Fizzbuzz = 0;
            
            for(int i = 1; i <= 100; i++) {
                if(i%3 == 0 && i%5 == 0) {
                    Fizzbuzz++;
                    System.Console.WriteLine("Fizzbuzz");
                } else if (i%3 == 0) {
                    Fizz++;
                    System.Console.WriteLine("Fizz");
                } else if (i%5 == 0) {
                    Buzz++;
                    System.Console.WriteLine("Buzz");
                } else {
                    System.Console.WriteLine(i);
                }
            }
            System.Console.WriteLine(@" 
FizzBuzz = {0}
Fizz = {1} 
Buzz = {2}", 
Fizzbuzz, Fizz, Buzz);
        }
    }
}
