using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.IO
{
   public static class InputReader
    {
        private const string endCommand = "quit";

        public static void StartReadingCommnads()
        {

            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
                string input = Console.ReadLine();
                input = input.Trim();

                if (input==endCommand)
                {
                    break;
                }

                CommandInterpreter.InterpredCommand(input);
            }

            
        }
    }
}
