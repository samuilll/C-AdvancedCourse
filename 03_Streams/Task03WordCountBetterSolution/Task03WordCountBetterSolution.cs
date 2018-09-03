using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task03WordCountBetterSolution
{
    static void Main(string[] args)
    {

        using (StreamReader readerOne = new StreamReader($"../../words.txt"))
        {
            using (StreamReader readerTwo = new StreamReader("../../text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../result.txt"))
                {
                    var wordsInFirstFile = new HashSet<string>();

                    var line = readerOne.ReadLine();

                    while (line != null)
                    {
                        wordsInFirstFile.Add(line);
                        line = readerOne.ReadLine();
                    }

                    var alltext = readerTwo.ReadToEnd();

                    var wordsInSecondFile = alltext.Split(new[] { ' ', '!', '?', '.', '-', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    var wordsInBoth = wordsInFirstFile.Intersect(wordsInSecondFile);

                    var wordOccurencesDict = new Dictionary<string,int>();

                    foreach (var word in wordsInBoth)
                    {
                        int currentWordCount = wordsInSecondFile.Where(n => n == word).Count();

                        wordOccurencesDict[word] = currentWordCount;
                    }

                    foreach (var pair in wordOccurencesDict.OrderByDescending(n=>n.Value))
                    {
                        writer.WriteLine($"{pair.Key} => {pair.Value}");
                    }

                }
            }
        }
    }
}

