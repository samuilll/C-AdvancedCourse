using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task08FullDirectoryTraversal
    {
        static void Main(string[] args)
    {
        var filesDict = new Dictionary<string, List<FileInfo>>();

        string dirPath = string.Empty;

        while (!Directory.Exists(dirPath))
        {
            Console.WriteLine("Choose the derictory you want to traverse trough:");

            dirPath = Console.ReadLine();
        }

        TraverseTroughAllDirectories(filesDict, dirPath);

        SaveTheInformation(filesDict);

    }

    private static void SaveTheInformation(Dictionary<string, List<FileInfo>> filesDict)
    {
        Console.WriteLine("Choose the file path you want to save the information:");

        var filePath = Console.ReadLine();

        var filesCounter = 0;

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var pair in filesDict.OrderByDescending(n => n.Value.Count).ThenByDescending(n => n.Key))
            {
                writer.Write($"{pair.Key}{Environment.NewLine}");

                foreach (var file in pair.Value.OrderBy(n => n.Length))
                {
                    writer.Write($"--{file.Name} - {(decimal)file.Length / 1024:f4}kb{Environment.NewLine}");

                    filesCounter++;
                }
            }
        }

        Console.WriteLine("Operation Complete! The count of all files is {0}",filesCounter);
    }

    private static void TraverseTroughAllDirectories(Dictionary<string, List<FileInfo>> filesDict, string dirPath)
    {
        var currentDirInfo = new DirectoryInfo(dirPath);

        var currentDirFiles = currentDirInfo.GetFiles();

        var innerDirectories = currentDirInfo.GetDirectories();

        foreach (var file in currentDirFiles)
        {
            var ext = file.Extension;

            if (!filesDict.ContainsKey(ext))
            {
                filesDict[ext] = new List<FileInfo>();
            }

            filesDict[ext].Add(file);
        }

        foreach (var directory in innerDirectories)
        {
            TraverseTroughAllDirectories(filesDict,directory.FullName);
        }
    }
}

