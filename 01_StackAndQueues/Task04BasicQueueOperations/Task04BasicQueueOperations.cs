using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task04BasicQueuesOperations
{
    static void Main(string[] args)
    {
        int[] parameters = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[] pushNumbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Queue<int> basic = new Queue<int>(pushNumbers);

        for (int i = 0; i < parameters[1]; i++)
        {
            basic.Dequeue();
        }

        bool exist = basic.Contains(parameters[2]);

        if (exist)
        {
            Console.WriteLine("true");
        }
        else if (basic.Count > 0)
        {
            Console.WriteLine(basic.Min());
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}

