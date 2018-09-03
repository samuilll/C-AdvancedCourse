using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Judge
{
   public static class Tester
    {
      public  static void CompareContent(string userOutputPath, string expectedOutpudPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");

            try
            {
                string mismatchPath = GetMismatchPath(expectedOutpudPath);

                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutpudPath);

                bool hasMismatch;
                string[] mismatches = GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);

                PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("File read!");
            }
            catch (FileNotFoundException)
            {

                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }

        }

        private static void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }
                try
                {
                    File.AppendAllLines(mismatchPath, mismatches);
                }
                catch (DirectoryNotFoundException)
                {

                    OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                }
                return;
            }

            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
        }

        private static string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
        {
            hasMismatch = false;
            string output = string.Empty;
            string[] mismatches = new string[actualOutputLines.Length];

            int minOutputlines = actualOutputLines.Length;

            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                hasMismatch = true;
                minOutputlines = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            for (int index = 0; index < actualOutputLines.Length && index<expectedOutputLines.Length; index++)
            {
                string actualLine = actualOutputLines[index];
                string expectedLine = expectedOutputLines[index];

                if (actualLine != expectedLine)
                {
                    output = $"Mismatch at line {index} --expected: \"{expectedLine}\", actual: \"{actualLine}\"";
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine + Environment.NewLine;
                }
                mismatches[index] = output;
            }

            return mismatches;
        }

        public static string GetMismatchPath(string expectedOutpudPath)
        {
            int indexOf = expectedOutpudPath.LastIndexOf("\\");
            string derictoryPath = expectedOutpudPath.Substring(0, indexOf);
            string finalPath = derictoryPath + @"\Mismatches.txt";
            return finalPath;
        }
    }
}
