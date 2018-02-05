using BashSoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
   public static class Tester
    {
        static void CompareContent(string userOutputPath,string expectedOutpudPath)
        {
         OutputWriter
        }
        public static string GetMismatchPath(string expectedOutpudPath)
        {
            int indexOf = expectedOutpudPath.LastIndexOf("\\");
            string derictoryPath = expectedOutpudPath.Substring(0, indexOf);
            string finalPath = derictoryPath + @"\Mismatches.txt";
            return finalPath;
        }
    }
}
