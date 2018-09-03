using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task02BasicStackOperations
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

        Stack<int> stack = new Stack<int>(pushNumbers);

        for (int i = 0; i < parameters[1]; i++)
        {
            stack.Pop();
        }

        bool exist = stack.Contains(parameters[2]);

        if (exist)
        {
            Console.WriteLine("true");
        }
        else if (stack.Count > 0)
        {
            Console.WriteLine(stack.Min());
        }
        else
        {
            Console.WriteLine(0);
        }

    }
}

