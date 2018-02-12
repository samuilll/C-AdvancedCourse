using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

    class Task03JediCode_X
    {
        static void Main(string[] args)
        {

        var N = int.Parse(Console.ReadLine());

        var linesData = new List<string>();

        for (int i = 0; i < N; i++)
        {
            var line = Console.ReadLine();

            linesData.Add(line);
        }

        var firstPattern = Console.ReadLine();

        var secondPattern = Console.ReadLine();

        int[] indexers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Regex reg1 = new Regex($@"{firstPattern}(?<name>[A-Za-z]{{{firstPattern.Length}}})(?![A-Za-z])");

        Regex reg2 = new Regex($@"{secondPattern}(?<message>[A-Za-z0-9]{{{secondPattern.Length}}}(?![A-Za-z0-9]))");

        var namesData = new Queue<string>();

        var tempMessageData = new List<string>();

        var linesLikeOneLine = string.Join("", linesData);

            var names = reg1.Matches(linesLikeOneLine).Cast<Match>().Select(n => n.Groups["name"].Value).ToArray();

            var messages = reg2.Matches(linesLikeOneLine).Cast<Match>().Select(n => n.Groups["message"].Value).ToArray();

            AddNamesNamesToData(names, namesData);

            AddQueueTodata(messages, tempMessageData);
        

       var messagexData = tempMessageData.ToArray();

        foreach (var index in indexers)
        {
            TryToFindATrueIndex(namesData, messagexData, index);
        }

       // Console.WriteLine(string.Join(", ",namesData));

      //  Console.WriteLine(string.Join(", ", messagexData));

    }

    private static void TryToFindATrueIndex(Queue<string> namesData, string[] messagexData, int index)
    {
        if (index-1 >= 0 && index-1 < messagexData.Length)
        {
            if (namesData.Count > 0)
            {
                Console.WriteLine($"{namesData.Dequeue()} - {messagexData[index - 1]}");
            }
        }
        else if (index-1<0)
        {
            TryToFindATrueIndex(namesData, messagexData, index + 1);
        }
    }

    private static void AddQueueTodata(string[] messages, List<string> messagexData)
    {
        foreach (var message in messages)
        {
            messagexData.Add(message);
        }
    }

    private static void AddNamesNamesToData(string[] names, Queue<string> namesData)
    {
        foreach (var name in names)
        {
            namesData.Enqueue(name);
        }
    }
}

