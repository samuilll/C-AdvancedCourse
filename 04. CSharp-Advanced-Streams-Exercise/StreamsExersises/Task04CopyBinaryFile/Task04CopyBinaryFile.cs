using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task04CopyBinaryFile
    {
        static void Main(string[] args)
        {

            const string winRarFilePath = "../../20449027_1752259334801383_4517628934508725667_o.jpg";
            const string destinationFilePath = "../../result.jpg";

            using (FileStream source = new FileStream(winRarFilePath,FileMode.Open))
            {
                using (FileStream destination = new FileStream(destinationFilePath,FileMode.Create))
                {
                    var fileLength = source.Length;

                    var buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytes);

                        Console.WriteLine("{0:P}", Math.Min(source.Position / fileLength, 1));
                    }
            }
            }
        }
    }

