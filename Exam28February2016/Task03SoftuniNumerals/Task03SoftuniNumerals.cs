using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


class Task03SoftuniNumerals
{
    static void Main(string[] args)
    {

        var numberAsString = Console.ReadLine();

        var table = new Dictionary<string, int> { ["aa"] = 0, ["aba"] = 1, ["bcc"] = 2, ["cc"] = 3, ["cdc"] = 4 };

        var numbersAsStringArray = new List<string>();

        var builder = new StringBuilder();  


        for (int i = 0; i < numberAsString.Length; i++)
        {
            builder.Append(numberAsString[i]);

            if (table.ContainsKey(builder.ToString()))
            {
                numbersAsStringArray.Add(builder.ToString());

                builder.Clear();
            }
        }

        int[] numbersAsIntegers = numbersAsStringArray.Select(n => n = table[n].ToString()).Select(int.Parse).ToArray();

        BigInteger decimalNumber = new BigInteger();

         decimalNumber = CalculateTheDecimallNumber(numbersAsIntegers);

        Console.WriteLine(decimalNumber);

    }

    private static BigInteger CalculateTheDecimallNumber(int[] numbersAsIntegers)
    {
        BigInteger number = new BigInteger();

        Array.Reverse(numbersAsIntegers);

        for (int i = 0; i < numbersAsIntegers.Length; i++)
        {
            number += numbersAsIntegers[i] * PowFive(i);
        }

        return number;
    }
       private static BigInteger PowFive(int index)
    {
        BigInteger number = new BigInteger();

         number = 1;

        if (index == 0)
        {
            return 1;
        }

        for (int i = 1; i <= index; i++)
        {
            number *= 5;
        }
        return number;
    }
}
