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

        Console.WriteLine("Please choose the path of the file:");

             string filePath = Console.ReadLine();

        Console.WriteLine($"Please choose the name (with extension) of the destiantion file :");

        string destinationFilePath = @"../../" + Console.ReadLine();

            using (FileStream source = new FileStream(filePath,FileMode.Open))
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

                        Console.WriteLine("{0:P}", (double)source.Position / fileLength);
                    }

                    
            }
            }
        }
    }

