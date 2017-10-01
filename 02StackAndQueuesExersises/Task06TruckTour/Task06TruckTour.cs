using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class PetrolPump
{
    public int Quantity { get; set; }

    public int DistanceToTheNext { get; set; }

    public int Index { get; set; }

    public PetrolPump(int a, int b, int c)
    {
        this.Quantity = a;

        this.DistanceToTheNext = b;

        this.Index = c;
    }
}
class Task06TruckTour
{
    static void Main(string[] args)
    {

        int numberOfPumps = int.Parse(Console.ReadLine());

        Queue<PetrolPump> circle = new Queue<PetrolPump>();

        for (int i = 0; i < numberOfPumps; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var currentPump = new PetrolPump(input[0], input[1], i);

            circle.Enqueue(currentPump);

        }

        var count = 0;

        while (count <= circle.Count)
        {
            var moves = 0;

            var fuel = 0;

            while (true)
            {
                var quantity = circle.Peek().Quantity;

                var disctance = circle.Peek().DistanceToTheNext;

                fuel = fuel + quantity - disctance;

                if (fuel >= 0)
                {
                    circle.Enqueue(circle.Dequeue());
                    moves += 1;
                }
                else
                {
                    circle.Enqueue(circle.Dequeue());
                    break;
                }

                if (moves == circle.Count)
                {
                    goto next;
                }
            }

            count++;
        }

        next:

        Console.WriteLine(circle.Peek().Index); ;
    }
}

