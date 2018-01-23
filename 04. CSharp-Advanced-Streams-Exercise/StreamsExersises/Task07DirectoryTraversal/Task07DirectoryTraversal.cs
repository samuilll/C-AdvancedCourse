using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


class Task07DirectoryTraversal
{
    static void Main(string[] args)
    {



        var filesDict = new Dictionary<string, List<FileInfo>>();

        var files = GetFilesFromDirectory();

        SaveTheResult(filesDict, files);
    }

    private static void SaveTheResult(Dictionary<string, List<FileInfo>> filesDict, IEnumerable<FileInfo> files)
    {
        foreach (var file in files)
        {
            var ext = file.Extension;

            if (!filesDict.ContainsKey(ext))
            {
                filesDict[ext] = new List<FileInfo>();
            }

            filesDict[ext].Add(file);
        }

        Console.WriteLine("Choose the file path you want to save the information:");

        var filePath = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var pair in filesDict.OrderByDescending(n => n.Value.Count).ThenByDescending(n => n.Key))
            {
                writer.Write($"{pair.Key}{Environment.NewLine}");

                foreach (var file in pair.Value.OrderBy(n => n.Length))
                {
                    writer.Write($"--{file.Name} - {file.Length / 1024}kb{Environment.NewLine}");
                }
            }
        }
    }

    private static IEnumerable<FileInfo> GetFilesFromDirectory()
    {


        try
        {
            Console.WriteLine("Choose the derictory you want to traverse trough:");

            var dirPath = Console.ReadLine();

            var dirInfo = new DirectoryInfo(dirPath);

            return dirInfo.GetFiles();

        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("There is no such a directory");

            return null;
        }

    }


}


