using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_SparseArrays
{
    class Program
    {

        static string[] strLines = null;
        static string[] strQueries = null;

        static string[] inputCmdStrings = {
            "4",
            "aba",
            "baba",
            "aba",
            "xzxb",
            "3",
            "aba",
            "xzxb",
            "ab"
        };

        static int inputCmdStringsCount = -1;
        static int maxCount = 0;

        static string GetCmdLineString()
        {
            //return Console.ReadLine();
            return inputCmdStrings[++inputCmdStringsCount];
        }

        static int FindMatch(string qString)
        {
            int count = 0;
            foreach(string str in strLines)
            {
                if (str == qString)
                {
                    count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {

            int n = Convert.ToInt32(GetCmdLineString());
            strLines = new string[n];
            for (int i = 0; i < n; i++)
            {
                strLines[i] = GetCmdLineString();
            }

            int q = Convert.ToInt32(GetCmdLineString());
            strQueries = new string[q];
            for (int i = 0; i < q; i++)
            {
                strQueries[i] = GetCmdLineString();
            }

            for(int i=0; i < q; i++)
            {
                Console.WriteLine(FindMatch(strQueries[i]));
            }

        }

    }
}
