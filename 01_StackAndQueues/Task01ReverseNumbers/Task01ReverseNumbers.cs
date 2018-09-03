using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Task01ReverseNumbersWithAStack
{
    static void Main(string[] args)
    {

        int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Stack<int> stack = new Stack<int>(numbers);

        while (stack.Count > 0)
        {
            Console.Write($"{stack.Pop()} ");
        }
        Console.WriteLine();
    }
}

