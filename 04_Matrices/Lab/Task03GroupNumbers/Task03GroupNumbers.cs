    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


        class Task03GroupNumbers
        {
            static void Main(string[] args)
            {

            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ',',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[3][];

            int[] indexers = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
       
                if (Math.Abs(numbers[i] % 3) == 0)
                {
                    indexers[i] = 0;
                }
                else if (Math.Abs(numbers[i]%3)==1)
                {
                    indexers[i] = 1;
                }
                else
                {
                    indexers[i] = 2;
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[indexers.Where(n=>n==i).Count()];

                int p = 0;
                for (int j = 0; j < indexers.Length; j++)
                {
                    if (indexers[j]==i)
                    {
                        matrix[i][p++] = numbers[j];
                    }
                }
            }

            foreach (var sequence in matrix)
            {
                Console.WriteLine(string.Join(" ",sequence));
            }
            }
        }

