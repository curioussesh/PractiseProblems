using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Pairs
{
    // https://www.hackerrank.com/challenges/pairs
    class Program
    {

        static string line1 = "5 2";
        static string line2 = "1 5 3 4 2";
        /* Head ends here */
        static int pairs(int[] a, int k)
        {
            int count = 0;
            Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
            foreach(int i in a)
            {
                dictionary.Add(i, true);
                if (dictionary.ContainsKey(i + k))
                {
                    count++;
                }
                if (dictionary.ContainsKey(i - k))
                {
                    count++;
                }
            }
            return count;
        }
        /* Tail starts here */
        static void Main(String[] args)
        {
            int res;

            String line = line1;
            String[] line_split = line.Split(' ');
            int _a_size = Convert.ToInt32(line_split[0]);
            int _k = Convert.ToInt32(line_split[1]);
            int[] _a = new int[_a_size];
            int _a_item;
            String move = line2;
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }

            res = pairs(_a, _k);
            Console.WriteLine(res);
            Console.ReadLine();

        }
    }
}
