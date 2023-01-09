using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFrameWork.Medical_Research_Application
{
    class Utilities
    {
        internal static string Prompt(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        internal static int GetNumber(string question)
        {
            return int.Parse(Prompt(question));
        }
    }
}
