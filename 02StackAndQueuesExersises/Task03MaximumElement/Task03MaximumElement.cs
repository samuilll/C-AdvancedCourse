using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task03MaximumElement
{
    static void Main(string[] args)
    {

        int numberOfInputs = int.Parse(Console.ReadLine());

        Stack<int> stack = new Stack<int>();

        Stack<int> max = new Stack<int>();

        max.Push(int.MinValue);

        for (int i = 0; i < numberOfInputs; i++)
        {
            int[] query = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            switch (query[0])
            {
                case 1:
                    {
                        stack.Push(query[1]);

                        if (max.Peek() < stack.Peek())
                        {
                            max.Push(stack.Peek());
                        }
                        break;
                    }
                case 2:
                    {
                        if (stack.Pop() == max.Peek())
                        {
                            max.Pop();
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine(max.Peek());
                        break;
                    }
            }
            if (max.Count == 0)
            {
                max.Push(int.MinValue);
            }
        }
    }
}

