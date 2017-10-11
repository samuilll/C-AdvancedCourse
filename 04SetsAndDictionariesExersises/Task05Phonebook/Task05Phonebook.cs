using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task05Phonebook
    {
        static void Main(string[] args)
        {

        Dictionary<string, string> phonebook = new Dictionary<string, string>();

        string[] input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

        while (input[0]!="search")
        {
            phonebook[input[0]] = input[1];

            input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
        }

        string searchedName = Console.ReadLine();

        while (searchedName!="stop")
        {
            if (phonebook.ContainsKey(searchedName))
            {
                Console.WriteLine($"{searchedName} -> {phonebook[searchedName]}");
            }
            else
            {
                Console.WriteLine($"Contact {searchedName} does not exist.");
            }

            searchedName = Console.ReadLine();
        }
        }
    }

