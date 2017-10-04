using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task11PoisonousPlants
{
    static void Main(string[] args)
    {

        int numberOfPlants = int.Parse(Console.ReadLine());//

        int[] plantsArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(  );

        int[] daysAlive = new int[plantsArray.Length];

        Stack<int> indexersStack = new Stack<int>();

        // Stack<int> storage = new Stack<int>(plantsArray);

        int maxDaysAlive = 1;

        indexersStack.Push(0);

        var currentMinValue = plantsArray[0];

        daysAlive[0] = -1;

        for (int i = 1; i < plantsArray.Length; i++)
        {

            var currentPlantValue = plantsArray[i];

            if (plantsArray[i] <= currentMinValue)
            {
                daysAlive[i] = -1;

                indexersStack.Clear();

                currentMinValue = plantsArray[i];

            //    Console.WriteLine($"{plantsArray[i]:D2} -> {daysAlive[i]}");

                continue;
            }

            if (indexersStack.Count == 0)

            {
                indexersStack.Push(i);

                daysAlive[i] = 1;
            }
            else
            {
                var currentPop = indexersStack.Pop();

                if (plantsArray[i]>plantsArray[currentPop])
                {
                    daysAlive[i] = 1;

                    if (daysAlive[currentPop]==1)
                    {
                        indexersStack.Push(i);
                    }
                    else
                    {
                        indexersStack.Push(currentPop);
                        indexersStack.Push(i);
                    }

                }
                else
                {
                    indexersStack.Push(currentPop);

                    while (true)
                    {
                        if (indexersStack.Count == 0)
                        {
                            indexersStack.Push(i);
                            break;
                        }
                        var poppedIndex = indexersStack.Pop();

                        if (plantsArray[i]<=plantsArray[poppedIndex])
                        {
                            if (daysAlive[i]<=daysAlive[poppedIndex])
                            {
                                daysAlive[i] = daysAlive[poppedIndex] + 1;

                                if (maxDaysAlive<daysAlive[i])
                                {
                                    maxDaysAlive = daysAlive[i];
                                }
                            }
                            
                        }
                        else
                        {
                            indexersStack.Push(poppedIndex);
                            indexersStack.Push(i);
                            break;
                        }

                    }
                    }
            }

         //  Console.WriteLine($"{plantsArray[i]:D2} -> {daysAlive[i]}");
        }
        Console.WriteLine(maxDaysAlive);
    }
}
