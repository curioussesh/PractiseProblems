using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Equals
{

    // https://www.hackerrank.com/challenges/equal
        


    class Program
    {

        static string[] inputCmdStrings = {
            "1",
            "4",
            "2 2 3 7"
        };

        static int[,] intArray = null;
        static int inputCmdStringsCount = -1;
        static int maxCount = 0;

        static string GetCmdLineString()
        {
            //return Console.ReadLine();
            return inputCmdStrings[++inputCmdStringsCount];
        }

        static void Main(string[] args)
        {
            int noofcases = Convert.ToInt32(GetCmdLineString());
            string line = "";
            string[] line_split = null;
            int tmpValue = 0;
            int[] A = null;

            for (int i = 0; i < noofcases; i++)
            {
                int noofelements = Convert.ToInt32(GetCmdLineString());
                line = GetCmdLineString();
                line_split = line.Split(' ');
                A = new int[noofelements];
                for (int j=0; j< noofelements; j++)
                {
                    A[j] = Convert.ToInt32(line_split[j]);
                }

                Console.WriteLine(GetCount(A));
            }

           
            Console.ReadLine();
        }

        static int GetCount(int[] A)
        {
            int[] B = { 1, 3, 5 };
            int maxCount = 0;
            while (!AllSame(A))
            {
                int[] D = new int[A.Length];
                Array.Copy(A, D, A.Length);
                int counter=0, count = 0;
                for(int i= 0;  i < B.Length; i++){
                    int[] C = new int[A.Length];
                    Array.Copy(A, C, A.Length);
                    count = 0;
                    for(int j= 0;  j < A.Length; j++){

                        if (i != j)
                        {
                            C[j] = A[j] + B[i];
                        }
                        else
                        {
                            C[j] = A[j];
                        }
                        if (A.Contains(C[j]))
                        {
                            count++;
                        }

                    }
                    if (counter < count) { Array.Copy(C, D, C.Length); counter = count; }
                }
                Array.Copy(D, A, D.Length);
                maxCount++;
            }
            return maxCount;
        }

        private static bool AllSame(int[] a)
        {
            int k = a[0];
            foreach(int i in a)
            {
                if (k != i)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
