using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 class Task00PhoneBookUpgrade
    {
        static void Main(string[] args)
        {
        Dictionary<string, string> phonebook = new Dictionary<string, string>();

        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        while (input[0] != "END")
        {
            if (input[0]=="A")
            {
                phonebook[input[1]] = input[2];
            }
            else if (input[0]=="S")
            {
                if (phonebook.ContainsKey(input[1]))
                {
                    Console.WriteLine($"{input[1]} -> {phonebook[input[1]]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input[1]} does not exist.");
                }
            }
            else if (input[0]== "ListAll")
            {
                foreach (var pair in phonebook.OrderBy(n=>n.Key))
                {
                    Console.WriteLine($"{pair.Key} -> {pair.Value}");
                }
            }

            input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

    //    string searchedName = Console.ReadLine();

        //while (searchedName != "stop")
        //{
        //    if (phonebook.ContainsKey(searchedName))
        //    {
        //        Console.WriteLine($"{searchedName} -> {phonebook[searchedName]}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Contact {searchedName} does not exist.");
        //    }

        //    searchedName = Console.ReadLine();
        //}
    }
    }

