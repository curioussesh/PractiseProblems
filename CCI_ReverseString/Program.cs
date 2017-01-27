using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCI_ReverseString
{
    class Program
    {
        static string[] strLines = null;
        static string[] strQueries = null;

        static string[] inputCmdStrings = {
            "abcd."
        };

        static int inputCmdStringsCount = -1;
        static int maxCount = 0;

        static string GetCmdLineString()
        {
            //return Console.ReadLine();
            return inputCmdStrings[++inputCmdStringsCount];
        }
        static void Main(string[] args)
        {
            string str = GetCmdLineString();
            char[] c = str.ToCharArray();
            StringReverse(c, str.Length - 2);
            Console.ReadLine();
        }

        static void StringReverse(char[] c, int pointer)
        {
            if (pointer < 0) { return; }
            else { Console.Write(c[pointer]); StringReverse(c, --pointer); }
        }

    }
}
