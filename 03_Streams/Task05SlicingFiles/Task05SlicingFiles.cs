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

        ChoosenAction(choise);
    }

    private static void ChoosenAction(string choise)
    {
        if (choise == "Slice")
        {
            Console.WriteLine("Please choose the path of the file you want to slice:");
            var fileToDividePath = Console.ReadLine();

            Console.WriteLine("Please choose the path of the derictory you want to put sliced files:");
            var writeDirectoryPath = Console.ReadLine();

            Console.WriteLine("How many files do you want to create?");

            try
            {
                var partsNumber = int.Parse(Console.ReadLine());

                Slice(partsNumber, fileToDividePath, writeDirectoryPath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Pointed file does not exist!");
            }
            catch (FormatException)
            {
                Console.WriteLine("You have to imput a number!");
            }
        
        }
        else if (choise == "Assemble")
        {
            Console.WriteLine("Please write the path of the derictory where the files are:");
            var filesToAssembleDir = Console.ReadLine();
          
                try
                {
                    var files = Directory.GetFiles(filesToAssembleDir);

                    if (files.Length == 0)
                    {
                        Console.WriteLine("There are no files in the derictory. You have to slice first");

                        choise = ChooseTheOperation();

                        ChoosenAction(choise);
                    }

                    Assemble(files);

                }
                catch (DirectoryNotFoundException)
                {
                   Console.WriteLine("Please choose an existing derictory!");

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
        Console.WriteLine("Please choose the name of the file you want to create, including the extension:");

        var newFileName = Console.ReadLine();

        using (FileStream writer = new FileStream($"../../{newFileName}", FileMode.Create, FileAccess.Write))
        {
            var counter = 0;

            foreach (var file in files)
            {
                using (var reader = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    var buffer = new byte[4096];

                    while (true)
                    {
                        var readBytes = reader.Read(buffer, 0, buffer.Length);

                        if (readBytes==0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, buffer.Length);
                    }

                    Console.WriteLine($"File № {++counter} completed");

                }
            }
        }
    }

    private static void Slice(int partsNumber, string fileToDividePath, string writeDirectoryPath)
    {
        using (var reader = new FileStream(fileToDividePath, FileMode.Open, FileAccess.Read))
        {
            if (!Directory.Exists(writeDirectoryPath))
            {
                Directory.CreateDirectory(writeDirectoryPath);
            }

            var partSize = reader.Length / partsNumber + 1;

            for (int i = 0; i < partsNumber; i++)
            {
                var partNumber = i.ToString();

                using (var writer = new FileStream($"{writeDirectoryPath}/part - {partNumber}.mkv", FileMode.Create))
                {

                    var buffer = new byte[4096];

                    while (writer.Length < partSize)
                    {

                        var readBytes = reader.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, buffer.Length);

                    }

                    Console.WriteLine($"File № {i} completed");

                }

            }


        }
    }
}

