using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class _2_SoftuniParty
    {
        static void Main(string[] args)
        {

        string input = Console.ReadLine();

        SortedSet<string> invitedGuests = new SortedSet<string>();

        while (input!="PARTY")
        {
            invitedGuests.Add(input);

            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        while (input != "END")
        {
            invitedGuests.Remove(input);

            input = Console.ReadLine();
        }

        Console.WriteLine(invitedGuests.Count);

        foreach (var leftedGuest in invitedGuests)
        {
            Console.WriteLine(leftedGuest);
        }

    }
    }

