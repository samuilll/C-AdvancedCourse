using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task10SimpleTextEditor
{
    static void Main(string[] args)
    {

        StringBuilder textBuilder = new StringBuilder(string.Empty);

        Stack<string> stackBuilder = new Stack<string>();

        stackBuilder.Push(string.Empty);

        int operationsNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < operationsNumber; i++)
        {
            var command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            switch (command[0])
            {
                case "1":
                    {
                        ImplementTheAppendFunction(command[1], textBuilder, stackBuilder);
                        break;
                    }
                case "2":
                    {
                        ImplementTheEraseFunction(int.Parse(command[1]), textBuilder, stackBuilder);

                        break;
                    }
                case "3":
                    {
                        PrintTheReurnedElement(int.Parse(command[1]), textBuilder);
                        break;
                    }
                case "4":
                    {
                       textBuilder = new StringBuilder(ImplementTheUndoFunction(textBuilder, stackBuilder));
                        break;
                    }

            }
        }
    }

    private static string ImplementTheUndoFunction(StringBuilder textBuilder, Stack<string> stackBuilder)
    {
        stackBuilder.Pop();

        textBuilder.Clear();

        textBuilder = new StringBuilder(stackBuilder.Peek());

      //  Console.WriteLine();

        return textBuilder.ToString();


    }

    private static void PrintTheReurnedElement(int index, StringBuilder textBuilder)
    {
        if (textBuilder.Length>0)
        {
            Console.WriteLine(textBuilder.ToString()[index - 1]);
        }

        //  Console.WriteLine();
    }

    private static void ImplementTheEraseFunction(int countOfElementsToErase, StringBuilder textBuilder, Stack<string> stackBuilder)
    {

        textBuilder.Remove(textBuilder.Length - countOfElementsToErase, countOfElementsToErase);

        stackBuilder.Push(textBuilder.ToString());

     //   Console.WriteLine();
    }

    private static void ImplementTheAppendFunction(string textToAppend, StringBuilder textBuilder, Stack<string> stackBuilder)
    {
        textBuilder.Append(textToAppend);

        stackBuilder.Push(textBuilder.ToString());

       // Console.WriteLine();
    }
}

// 4   1 2 3 4 //   2/    