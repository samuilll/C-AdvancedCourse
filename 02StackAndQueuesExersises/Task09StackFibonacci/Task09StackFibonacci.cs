using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task09StackFibonacci
{
    class Task09StackFibonacci
    {
        static void Main(string[] args)
        {

            long number = long.Parse(Console.ReadLine());

            Stack<long> fibonacci = new Stack<long>();

            fibonacci.Push(0);

            fibonacci.Push(1);

            long counter = 0;

            while (counter<number-1)
            {
                long lastNumber = fibonacci.Pop();

                long previousNumber = fibonacci.Pop();

                fibonacci.Push(lastNumber);

                fibonacci.Push(lastNumber+previousNumber);

                counter++;
            }

            Console.WriteLine(fibonacci.Peek());
        }
    }
}
