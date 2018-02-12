using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial
{
    class Program
    {
        static void Main(string[] args)
        {

            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>( Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> locks = new Queue<int>( Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            int intelligenceValue = int.Parse(Console.ReadLine());

            int usedBillets = 0;

            int barrelUsed = 0;

            while (bullets.Count>0 && locks.Count>0)
            {
                if (barrelUsed == barrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    barrelUsed = 0;
                }
                if (bullets.Pop()<=locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                
                usedBillets += 1;
                barrelUsed += 1;
            }

            if (barrelUsed == barrelSize && bullets.Count > 0)
            {
                Console.WriteLine("Reloading!");
                barrelUsed = 0;
            }

            if (locks.Count>0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue- usedBillets*bulletPrice}");
            }


        }
    }
}
