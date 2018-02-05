using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class IOManager
    {
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();

            int initialIdentation = SessionData.CurrentPath.Split('\\').Length;

            Queue<string> subFolders = new Queue<string>();

            subFolders.Enqueue(SessionData.CurrentPath);

            while (subFolders.Count != 0)
            {
                var currentPath = subFolders.Dequeue();

                int identation = currentPath.Split('\\').Length - initialIdentation;

                if (depth - identation < 0)
                {
                    break;
                }

                try
                {
                    foreach (var directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);
                    }
                    OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));

                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }
                }
                catch (UnauthorizedAccessException)
                {                
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                
                }
              
            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path = SessionData.CurrentPath + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }
        }

        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {

                try
                {
                    string currentPath = SessionData.CurrentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.CurrentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {

                    OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                    
                }
            }
            else
            {
                string currentPath = SessionData.CurrentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }

            SessionData.CurrentPath = absolutePath;
        }

    }
}
