using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task12InfernoIII
    {
    static void Main(string[] args)
    {
        var sequence = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var commandList = FillTheListOfCommands();

        var elementsToRemove = new List<int>();

        Func<int[], int, int, bool> funcLeft = (arr, index, num) =>
        (index - 1 >= 0) ? (arr[index - 1] + arr[index]) == num
        : (arr[index] == num);

        Func<int[], int, int, bool> funcRight = (arr, index, num) =>
        (index + 1 < arr.Length) ? (arr[index + 1] + arr[index]) == num
        : (arr[index] == num);

        Func<int[], int, int, bool> funcLeftRight = (arr, index, num) => (index + 1 < arr.Length && index - 1 >= 0) ? (arr[index - 1] + arr[index] + arr[index + 1]) == num
        : (index - 1 >= 0) ? (arr[index - 1] + arr[index] == num)
        : (index + 1 < arr.Length) ? (arr[index + 1] + arr[index] == num) :
        arr[index] == num;
        ;

        ImplementTheCommands(sequence, commandList, elementsToRemove, funcLeft, funcRight, funcLeftRight);

        RemoveElementsAndPrintTheResults(sequence, elementsToRemove);
    }

    private static void RemoveElementsAndPrintTheResults(int[] sequence, List<int> elementsToRemove)
    {
        var sequenceAsList = sequence.ToList();

        foreach (var element in elementsToRemove)
        {
            sequenceAsList.Remove(element);
        }

        Console.WriteLine(string.Join(" ", sequenceAsList));
    }

    private static void ImplementTheCommands(int[] sequence, List<string[]> commandList, List<int> elementsToRemove, Func<int[], int, int, bool> funcLeft, Func<int[], int, int, bool> funcRight, Func<int[], int, int, bool> funcLeftRight)
    {
        foreach (var command in commandList)
        {
            var includeOrExclude = command[0];

            var funcType = command[1];

            var conditionalNum = int.Parse(command[2]);

            switch (funcType)
            {
                case "Sum Left":
                    for (int i = 0; i < sequence.Length; i++)
                    {
                        if (funcLeft(sequence, i, conditionalNum))
                        {
                            elementsToRemove.Add(sequence[i]);
                        }
                    }
                    break;
                case "Sum Right":
                    for (int i = 0; i < sequence.Length; i++)
                    {
                        if (funcRight(sequence, i, conditionalNum))
                        {
                            elementsToRemove.Add(sequence[i]);
                        }
                    }
                    break;
                case "Sum Left Right":
                    for (int i = 0; i < sequence.Length; i++)
                    {
                        if (funcLeftRight(sequence, i, conditionalNum))
                        {
                            elementsToRemove.Add(sequence[i]);
                        }
                    }
                    break;
                default: break;
            }

        }
    }

    private static List<string[]> FillTheListOfCommands()
    {
        var commandsList = new List<string[]>();

        var currentCommand = Console.ReadLine()
            .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();


        while (currentCommand[0] != "Forge")
        {
            commandsList.Add(currentCommand);
            currentCommand = Console.ReadLine()
                        .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
        }

        var toReverseList = commandsList.Where(n => n[0] == "Reverse").ToList();

        for (int i = 0; i < toReverseList.Count; i++)
        {
            for (int j = 0; j < commandsList.Count; j++)
            {
                if (commandsList[j][1] == toReverseList[i][1] && commandsList[j][2] == toReverseList[i][2] && commandsList[j][0]=="Exclude")
                {
                    commandsList.Remove(commandsList[j]);
                }
            }
        }

        commandsList = commandsList.Where(n => n[0] != "Reverse").ToList();

        return commandsList;
    }
}

