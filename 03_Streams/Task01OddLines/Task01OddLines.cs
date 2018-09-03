using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01OddLines
{
    class Task01OddLines
    {
        static void Main(string[] args)
        {

            using (StreamReader reader = new StreamReader("../../fileToRead.txt"))
            {
                int lineNumber = 0;

                var line = reader.ReadLine();

                while (line!=null)
                {
                    lineNumber++;

                    if (lineNumber%2!=0)
                    {
                        Console.WriteLine(line);
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }
}
