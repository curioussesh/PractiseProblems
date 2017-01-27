using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTheTree
{
    class Program
    {


        static string[] inputCmdStrings = {
            "6",
            "100 200 100 500 100 600",
            "1 2",
            "2 3",
            "2 5",
            "4 5",
            "5 6"
        };

        static int[,] intArray = null;
        static int inputCmdStringsCount = -1;
        static int maxCount = 0;

        static string GetCmdLineString()
        {
            //return Console.ReadLine();
            return inputCmdStrings[++inputCmdStringsCount];
        }


        class Node
        {
            public int name { get; set; }
            public int value { get; set; }
            public List<Node> childNodes { get; set; } 

            public Node(int _name, int _value)
            {
                this.name = _name;
                this.value = _value;
            }

            public void AddChildNodes(Node _node)
            {
                if (childNodes == null)
                {
                    childNodes = new List<Node>();
                }
                childNodes.Add(_node);
            }

        }

        class Tree
        {
            public Node headNode { get; set; }

            public Node currentNode { get; set; }
            

            public Tree(int _name, int _value)
            {
                headNode = new Node(_name, _value);
                currentNode = headNode;
            }

            public void FindNode(Node n, int _name)
            {
                if (n.name == _name)
                {
                    currentNode = n;
                }
                else
                {
                    foreach (Node n1 in n.childNodes)
                    {
                        FindNode(n1, _name);
                    }
                }
            }

            public int FindChildNodeMinDiff(Node n, int totalValue, int minSoFar)
            {
                if (n.childNodes == null)
                {
                    return n.value;
                }
                else
                {
                    foreach (Node n1 in n.childNodes)
                    {
                        int k = Math.Abs(totalValue - FindChildNodeMinDiff(n1, totalValue, minSoFar));
                        if (k > minSoFar)
                        {
                            currentNode = n1;
                            minSoFar = k;
                        }
                    }
                    return minSoFar;
                }
            }
        }

        static void Main(string[] args)
        {
            int nodeCount = Convert.ToInt32(GetCmdLineString());
            string nodeValues = GetCmdLineString();
            int i = 0, totalValue=0, currentValue=0;
            List<Node> allNodes = new List<Node>();
            foreach(string str in nodeValues.Split(' '))
            {
                totalValue = totalValue + (currentValue = Convert.ToInt32(str));
                allNodes.Add(new Node(i, currentValue));
                i++;
            }

            Node n = (allNodes.Where(q => nodeValues.Equals(0)).First());
            Tree tree = new Tree(n.name, n.value);
            
            for(int j=0; j<i; j++)
            {
                
                Node n1 = allNodes.Where(q => nodeValues.Equals(GetCmdLineString().Split(' ')[0])).First();
                Node n2 = allNodes.Where(q => nodeValues.Equals(GetCmdLineString().Split(' ')[1])).First();
                tree.FindNode(tree.headNode, n1.name);
                n1 = tree.currentNode;
                n1.AddChildNodes(n2);

            }

            Console.WriteLine(tree.FindChildNodeMinDiff(tree.headNode, totalValue, 0));
            Console.ReadLine();

           
        }
    }
}
