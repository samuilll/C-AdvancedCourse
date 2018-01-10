using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task03WordCount
    {
        static void Main(string[] args)
        {

            var words = new HashSet<string>();

            var wordCounterList = new Dictionary<string,int>();

            using (StreamReader reader = new StreamReader("../../words.txt"))
            {
                var line = reader.ReadLine();

                while (line!=null)
                {
                    words.Add(line);
                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(string.Join(" ",words));
            using (StreamReader reader = new StreamReader("../../text.txt"))
            {
                string[] text = reader.ReadToEnd().Split(new char[]{' ','\r','\n'},StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine(string.Join(" ", text));

                foreach (var word in words)
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        var currentWord = text[i];

                        if (currentWord==word)
                        {
                            if (!wordCounterList.ContainsKey(currentWord))
                            {
                                wordCounterList[currentWord] = 0;
                            }
                            wordCounterList[currentWord]++;
                        }
                    }
                }              
            }

          

        using (StreamWriter writer = new StreamWriter("../../result.txt"))
            {
                foreach (var keyValuePair in wordCounterList.OrderByDescending(n=>n.Value))
                {
                    writer.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
                } 
            }
    }
    }

