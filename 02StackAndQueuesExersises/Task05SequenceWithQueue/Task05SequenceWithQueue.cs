using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Task05SequenceWithQueue
{
    static void Main(string[] args)
    {

        long number = long.Parse(Console.ReadLine());

        Queue<long> sequence = new Queue<long>();

        Queue<long> current = new Queue<long>();

        long s1 = number;

        sequence.Enqueue(s1);

        while (sequence.Count < 50)
        {
            long s2 = s1 + 1;

            long s3 = 2 * s1 + 1;

            long s4 = s1 + 2;

            sequence.Enqueue(s2);
            sequence.Enqueue(s3);
            sequence.Enqueue(s4);
            current.Enqueue(s2);
            current.Enqueue(s3);
            current.Enqueue(s4);

            s1 = current.Dequeue();
        }

        for (int i = 0; i < 50; i++)
        {
            Console.Write("{0} ", sequence.Dequeue());
        }
    }
}

