using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class _4_AcademyGraduation
    {
        static void Main(string[] args)
        {

        int numberOfNames = int.Parse(Console.ReadLine());

        SortedDictionary<string, double> averageList = new SortedDictionary<string, double>();

        for (int i = 0; i < numberOfNames; i++)
        {
            string name = Console.ReadLine();

            double[] numbers = Console.ReadLine()
           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(double.Parse)
           .ToArray();

            averageList[name] = numbers.Average();
        }

        foreach (var studentValuePair in averageList)
        {
            Console.WriteLine($"{studentValuePair.Key} is graduated with {studentValuePair.Value}");
        }
        }
    }

