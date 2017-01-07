using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Practice
{
    // https://www.hackerrank.com/challenges/connected-cell-in-a-grid
    class Program
    {

        static string[] inputCmdStrings = {
            "4",
            "4",
            "0 1 0 0",
            "0 1 1 0",
            "0 0 1 0",
            "1 0 0 0"
        };

        static int[,] intArray = null;
        static int inputCmdStringsCount = -1;
        static int maxCount = 0;

        static string GetCmdLineString()
        {
            //return Console.ReadLine();
            return inputCmdStrings[++inputCmdStringsCount];
        }

        static int connectedcellmaxcount(int rowInd, int columnInd, int currentCount)
        {
            if(rowInd < 0 || rowInd >= intArray.GetLength(0) || columnInd < 0 || columnInd >= intArray.GetLength(1) || intArray[rowInd, columnInd] <= 0)
            {
                return 0;
            }
            else if(intArray[rowInd, columnInd] == 1)
            {
                connectedcellmaxcount(rowInd + 1, columnInd, currentCount);
                connectedcellmaxcount(rowInd, columnInd + 1, currentCount);
                connectedcellmaxcount(rowInd+1, columnInd + 1, currentCount);
                currentCount++;
            }
            if (currentCount > maxCount) { maxCount = currentCount; }
            return currentCount;
            
        }
       
        static void Main(String[] args)
        {

            int rows = Convert.ToInt32(GetCmdLineString());
            int columns = Convert.ToInt32(GetCmdLineString());
            intArray = new int[rows,columns];
            string line = "";
            string[] line_split = null;
            int tmpValue = 0;

            for (int i = 0; i < rows; i++)
            {
                line = GetCmdLineString();
                line_split = line.Split(' ');
                for (int j = 0; j < columns; j++)
                {
                    intArray[i, j] = Convert.ToInt32(line_split[j]);
                    connectedcellmaxcount(i, j, 0);
                }
            }
           
            Console.WriteLine(maxCount);
            Console.ReadLine();

        }
    }
}
