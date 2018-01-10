using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task02LineNumbers
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../fileToRead.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../fileToWrite.txt"))
                {
                    var lineNumber = 0;

                    var line = reader.ReadLine();

                    while (line!=null)
                    {
                        lineNumber++;
                        writer.WriteLine($"{lineNumber}.{line}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }

