using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task05SlicingFiles
{
    static void Main(string[] args)
    {
        string choise = ChooseTheOperation();

        var fileToDividePath = "../../20449027_1752259334801383_4517628934508725667_o.jpg";

        var writeDirectoryPath = "../../DividedFiles/";

        ChoosenAction(choise, fileToDividePath, writeDirectoryPath);

    }

    private static void ChoosenAction(string choise, string fileToDividePath, string writeDirectoryPath)
    {
        if (choise == "Slice")
        {
            Console.WriteLine("How many files do you want to create?");

            var partsNumber = int.Parse(Console.ReadLine());

            Slice(partsNumber, fileToDividePath, writeDirectoryPath);
        }
        else if (choise == "Assemble")
        {
            while (true)
            {


                try
                {
                    var files = Directory.GetFiles("../../DividedFiles/");

                    if (files.Length == 0)
                    {
                        Console.WriteLine("There are no files in the derictory. You have to slice first");

                        choise = ChooseTheOperation();

                        ChoosenAction(choise, fileToDividePath, writeDirectoryPath);
                    }

                    Assemble(files);

                    break;

                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("The directory does not exist.\nIt will be created automatically.");

                    Directory.CreateDirectory("../../DividedFil/");

                }
            }

        }
        else
        {
            Console.WriteLine("\"Slice\" or \"Assemble\" please");
        }
    }

    private static string ChooseTheOperation()
    {
        Console.WriteLine("Choose the operation you want to implement:(Slice/Assemble)");

        var choise = Console.ReadLine();
        return choise;
    }

    private static void Assemble(string[] files)
    {
        using (FileStream destination = new FileStream("../../result.jpg", FileMode.Create, FileAccess.Write))
        {
            var counter = 0;

            foreach (var file in files)
            {
                using (var source = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    var buffer = new byte[source.Length];

                    var reader = source.Read(buffer, 0, buffer.Length);

                    destination.Write(buffer, 0, buffer.Length);

                    Console.WriteLine($"File № {++counter} completed");

                }
            }
        }
    }

    private static void Slice(int partsNumber, string fileToDividePath, string writeDirectoryPath)
    {
        using (var source = new FileStream(fileToDividePath, FileMode.Open, FileAccess.Read))
        {

            var partSize = source.Length / partsNumber + 1;

            for (int i = 0; i < partsNumber; i++)
            {
                var partNumber = i.ToString();

                using (var destination =
                    new FileStream($"{writeDirectoryPath}part - {partNumber}.mkv", FileMode.Create))
                {

                    var buffer = new byte[4096];

                    while (destination.Length < partSize)
                    {

                        var reader = source.Read(buffer, 0, buffer.Length);

                        if (reader == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, buffer.Length);

                    }

                    Console.WriteLine($"File № {i} completed");

                }

            }


        }
    }
}

