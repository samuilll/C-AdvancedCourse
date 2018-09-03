    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02CryptoMaster
{
    class Task02CryptoMaster
    {
        static void Main(string[] args)
        {

            var sequence = new List<int>(Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            int maxLenght = 0;

            for (int i = 0; i < sequence.Count; i++)
            {

                for (int step = 1; step < sequence.Count; step++)
                {
                    var currentIndex = i;

                    var currentLenght = 1;

                    while (true)
                    {

                        var nextIndex = (currentIndex + step) % sequence.Count;

                        if (sequence[nextIndex] > sequence[currentIndex])
                        {
                            currentIndex = nextIndex;

                            currentLenght += 1;
                        }
                        else
                        {                            
                            break;
                        }

                    }
                    if (currentLenght > maxLenght)
                    {
                        maxLenght = currentLenght;
                    }

                }

            }
            Console.WriteLine(maxLenght);

        }
    }
}
