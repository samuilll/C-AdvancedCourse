using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class _1_ParkingLot
    {
        static void Main(string[] args)
        {

        SortedSet<string> carsInTheParking = new SortedSet<string>();

        string[] input = Console.ReadLine()
            .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        while (input[0]!="END")
        {
            string direction = input[0];

            string carNumber = input[1];

            if (direction=="IN")
            {
                carsInTheParking.Add(carNumber);
            }
            else if (direction=="OUT")
            {
                carsInTheParking.Remove(carNumber);
            }

            input = Console.ReadLine()
                       .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .ToArray();
        }

        if (carsInTheParking.Count!=0)
        {
            foreach (var carNumber in carsInTheParking)
            {
                Console.WriteLine(carNumber);
            }
        }
        else
        {
            Console.WriteLine("Parking Lot is Empty");
        }
     
        }
    }

