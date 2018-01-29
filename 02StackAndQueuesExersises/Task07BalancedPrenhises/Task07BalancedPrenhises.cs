using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task07BalancedParetheses
{
    static void Main(string[] args)
    {

        string line = Console.ReadLine();

        var check = false;

        var index = 0;

        Stack<char> stackSequence = new Stack<char>();

        Queue<char> queueSequence = new Queue<char>();

        if (line.Length == 2 && CompareSymbols(line[0], line[1]))
        {
            check = true;
        }

        for (int i = 0; i < line.Length - 1; i++)
        {
            stackSequence.Push(line[i]);

            if (CompareSymbols(line[i], line[i + 1]))          //    [[()]](){}[{}]     ([)]
            {

                check = true;

                for (int j = 1; j <= stackSequence.Count; j++)
                {
                    queueSequence.Enqueue(line[i + j]);

                    index = j;
                }

                i = i + index;

                if (i + 1 != line.Length)
                {
                    check = false;
                }

                while (stackSequence.Count > 0)
                {
                    if (CompareSymbols(stackSequence.Pop(), queueSequence.Dequeue()))
                    {
                        continue;
                    }
                    else
                    {
                        check = false;

                        goto next;
                    }
                }

            }

        }

        //    [[()]](){}[{}]     ([)]

        //    [[()]](){}[{}]     ([)]

        next:

        if (check)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }

    private static bool CompareSymbols(char stackSymbol, char queueSymbol)
    {
        if (stackSymbol == '(' && queueSymbol == ')')
        {
            return true;
        }
        else if (stackSymbol == '{' && queueSymbol == '}')
        {
            return true;
        }
        else if (stackSymbol == '[' && queueSymbol == ']')
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

