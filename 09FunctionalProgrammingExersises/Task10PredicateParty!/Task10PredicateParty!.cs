using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {

        var names = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var rearrangeCommand = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        while (rearrangeCommand[0] != "Party!")
        {
            Func<string[], List<string>> func = n =>
            (n[1] == "StartsWith" || n[1] == "EndsWith") ? StringManipulation(names, n)
            : LengthManipulation(names, n);

            names = func(rearrangeCommand);

            rearrangeCommand = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
        }

        if (names.Count>0)
        {
            Console.WriteLine(string.Join(", ", names) + " are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }

    }

    private static List<string> LengthManipulation(List<string> names, string[] commands)
    {
        var removeOrDouble = commands[0];

        int lenght = int.Parse(commands[2]);

        if (removeOrDouble == "Remove")
        {
            return names.Where(k => k.Length != lenght).ToList();

        }
        else
        {
            return DoubleByLenght(names, lenght);
        }

    }

    private static List<string> DoubleByLenght(List<string> names, int lenght)
    {
        var temp = new List<int>();

        for (int i = 0; i < names.Count; i++)
        {
            if (names[i].Length == lenght)
            {
                temp.Add(i);
            }
        }
        foreach (var index in temp)
        {
            names.Insert(index, names[index]);
        }

        return names;
    }

    private static List<string> StringManipulation(List<string> names, string[] commands)
    {
        var removeOrDouble = commands[0];

        var direction = commands[1];

        var textPart = commands[2];

        if (removeOrDouble == "Remove")
        {
            if (direction == "EndsWith")
            {
                return names.Where(k => k.IndexOf(textPart) +textPart.Length != k.Length).ToList();
            }
            else
            {
                return names.Where(k => k.IndexOf(textPart) != 0).ToList();

            }
        }
        else
        {
            if (direction == "EndsWith")
            {
                return DoubleByEndsWith(names, textPart);
            }
            else
            {
                return DoubleByStartsWith(names, textPart);
            }
        }
    }

    private static List<string> DoubleByStartsWith(List<string> names, string textPart)
    {
        var temp = new List<int>();

        for (int i = 0; i < names.Count; i++)
        {
            if (names[i].IndexOf(textPart) == 0)
            {
                temp.Add(i);
            }
        }
        foreach (var index in temp)
        {
            names.Insert(index, names[index]);
        }

        return names;
    }

    private static List<string> DoubleByEndsWith(List<string> names, string textPart)
    {
        var temp = new List<int>();

        for (int i = 0; i < names.Count; i++)
        {
            if (names[i].LastIndexOf(textPart)+textPart.Length == names[i].Length)
            {
                temp.Add(i);
            }
        }
        foreach (var index in temp)
        {
            names.Insert(index, names[index]);
        }

        return names;
    }
}