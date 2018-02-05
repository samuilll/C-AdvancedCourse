using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


    class Task03CubicMessages
    {
        static void Main(string[] args)
    {
        var data = new Dictionary<string, int>();

        InputTheInformationInTheDictionary(data);

        PassingTroughTheEachMessage(data);
    }

    private static void PassingTroughTheEachMessage(Dictionary<string, int> data)
    {
        foreach (var pair in data)
        {
            var decryptNumber = pair.Value;

            var message = pair.Key;

            Regex regex = new Regex($"^(?<before>\\d+)(?<message>[A-Za-z]{{{decryptNumber}}})(?<after>[^A-Za-z]*)$");

            if (regex.IsMatch(pair.Key))
            {
                PrintTheOutput(regex.Match(pair.Key));
            }
        }
    }

    private static void PrintTheOutput(Match match)
    {
        var message = match.Groups["message"].Value;

        var beforeString = match.Groups["before"].Value;

        var afterString = match.Groups["after"].Value;

        var beforeIndexers = beforeString
            .ToCharArray()
            .Where(n => Int32.TryParse(n.ToString(), out int p))
            .Select(n=>int.Parse(n.ToString()))
            .ToArray();

        var afterIndexers = afterString
                    .ToCharArray()
                    .Where(n => Int32.TryParse(n.ToString(), out int p))
                    .Select(n => int.Parse(n.ToString()))
                    .ToArray();

        var output = new StringBuilder();

        foreach (var index in beforeIndexers)
        {
            if (index>=0 && index<message.Length)
            {
                output.Append(message[index].ToString());
            }
            else
            {
                output.Append(" ");
            }
        }
        foreach (var index in afterIndexers)
        {
            if (index >= 0 && index < message.Length)
            {
                output.Append(message[index].ToString());
            }
            else
            {
                output.Append(" ");
            }
        }
        Console.WriteLine($"{message} == {output.ToString()}");

    }

    private static void InputTheInformationInTheDictionary(Dictionary<string, int> data)
    {
        var linesCount = 1;

        var line = Console.ReadLine();

        var message = string.Empty;

        int decryptNumber;

        while (line != "Over!")
        {
            if (linesCount % 2 != 0)
            {
                message = line;
            }
            else
            {
                decryptNumber = int.Parse(line);
                data[message] = decryptNumber;
            }
            line = Console.ReadLine();
            linesCount += 1;
        }
    }
}

