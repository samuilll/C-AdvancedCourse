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

        List<string[]> commands = CommandsInputWithRemovingTheRemoveLines();

        foreach (var command in commands)
        {
            Func<string[], List<string>> func = n =>
            (n[1] == "Starts with" || n[1] == "Ends with" || n[1] == "Contains") ? StringManipulation(names, n)
            : LengthManipulation(names, n);

            names = func(command);
        }

        if (names.Count > 0)
        {
            Console.WriteLine(string.Join(" ", names));
        }
        else
        {
            Console.WriteLine("");
        }

    }

    private static List<string[]> CommandsInputWithRemovingTheRemoveLines()
    {
        var commands = new List<string[]>();

        var currentCommand = Console.ReadLine()
           .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
           .ToArray();


        while (currentCommand[0] != "Print")
        {

            commands.Add(currentCommand);

            currentCommand = Console.ReadLine()
                        .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
        }

        var removeCommands = commands.Where(n => n[0] == "Remove filter").ToList();

        foreach (var toRemove in removeCommands)
        {
            var toRemoveAddFilter = commands.Where(n => n[0] == "Add filter" && n[1] == toRemove[1] && n[2] == toRemove[2]).First();

            commands.Remove(toRemoveAddFilter);

            commands.Remove(toRemove);
        }

        return commands;
    }

    private static List<string> LengthManipulation(List<string> names, string[] commands)
    {

        int lenght = int.Parse(commands[2]);

           return names.Where(k => k.Length != lenght).ToList();

       
    }
    private static List<string> StringManipulation(List<string> names, string[] commands)
    {
        var removeOrDouble = commands[0];

        var direction = commands[1];

        var textPart = commands[2];

            if (direction == "Ends with")
            {
                return names.Where(k => k.IndexOf(textPart) + textPart.Length != k.Length).ToList();
            }
            else if (direction=="Starts with")
            {
                return names.Where(k => k.IndexOf(textPart) != 0).ToList();

            }
        else
        {
            return names.Where(k => k.IndexOf(textPart) == -1).ToList();
        }

    }

}