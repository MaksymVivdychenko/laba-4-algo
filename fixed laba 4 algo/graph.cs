using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixed_laba_4_algo
{
    internal class Graph
    {
        public List<Node> nodes { get; set; }
        int WorkBees;
        int ScoutBees;
        int Iterations;
        public Graph(int[,] matrix, int workBees, int scoutBees, int iterations) 
        {
            Iterations = iterations;
            WorkBees = workBees;
            ScoutBees = scoutBees;
            nodes = new List<Node>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                nodes.Add(new Node(i));
            }
            for (int i = 0;i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 1)
                    {
                        nodes[i].neighbours.Add(nodes[j]);
                    }
                }
            }
        }
        public void CountDegreeOfNodes()
        {
            foreach(Node node in nodes)
            {
                node.SetDegreeOfNode();
            }
        }
        public void ABC()
        {
            for (int i = 0; i < Iterations; i++)
            {
                CountDegreeOfNodes();
                nodes.Sort((x,y) => y.CompareTo(x));
                int workBeesCounter = WorkBees;
                for (int j = 0; j < ScoutBees; j++)
                { 
                    Node node = nodes[j];
                    if (node.isVisited == false)
                    {
                        List<Node> neighbours = node.neighbours;
                        int countOfColoredNodes;
                        if (neighbours.Count > WorkBees / ScoutBees)
                        {
                            countOfColoredNodes = WorkBees / ScoutBees;                      
                        }
                        else
                        {
                            countOfColoredNodes = neighbours.Count;
                        }
                        workBeesCounter -= countOfColoredNodes;
                        for (int k = 0; k < countOfColoredNodes; k++)
                        {
                            neighbours[k].ColorNodeFirstPossible();
                        }
                        node.ColorNodeFirstPossible();
                        node.isVisited = true;
                        node.NodeDegree = 0;
                    }
                }
            }
        }
        public int CalculateVertexColorValue()
        {
            List<int> values = new();
            foreach (Node node in nodes)
            {
                if(!values.Contains(node.Color))
                {
                    values.Add(node.Color);
                }
            }
            return values.Count;
        }
        public void printColors()
        {
            Dictionary<int, string> colors = new Dictionary<int, string>
        {
            { 0, "червоний" },
            { 1, "синій" },
            { 2, "зелений" },
            { 3, "жовтий" },
            { 4, "помаранчевий" },
            { 5, "фіолетовий" },
            { 6, "коричневий" },
            { 7, "рожевий" },
            { 8, "бірюзовий" },
            { 9, "сірий" },
            { 10, "чорний" },
            { 11, "білий" },
            { 12, "золотий" },
            { 13, "срібний" },
            { 14, "персиковий" },
            { 15, "оливковий" },
            { 16, "лаймовий" },
            { 17, "м'ятний" },
            { 18, "бежевий" },
            { 19, "аквамарин" },
            { 20, "ліловий" },
            { 21, "шоколадний" },
            { 22, "кремовий" },
            { 23, "бургунді" },
            { 24, "хакі" },
            { 25, "малиновий" },
            { 26, "індиго" },
            { 27, "лавандовий" },
            { 28, "рубіновий" },
            { 29, "сапфіровий" },
            { 30, "смарагдовий" }
        };
            nodes.Sort((x, y) => x.numOfNode.CompareTo(y.numOfNode));
            for (int i = 0; i < nodes.Count; i++)
            {
                Console.WriteLine($"Вузол{nodes[i].numOfNode+1}: {colors[nodes[i].Color]}");
            }
        }
        public int countUncoloredNodes()
        {
            int result = 0;
            foreach (Node node in nodes)
            {
                if(node.Color == -1)
                {
                    result++;
                }
            }
            return result;
        }
    }
    internal class Node : IComparable<Node> 
    {
        public bool isVisited;
        public int numOfNode;
        public int Color { get; set; }
        public List<Node> neighbours { get; set; }
        public int NodeDegree { get; set; }
        public Node(int numOfNode)
        {
            this.numOfNode = numOfNode;
            isVisited = false;
            Color = -1;
            neighbours = new List<Node>();
            NodeDegree = -2;
        }
        public void ColorNodeFirstPossible()
        {
            List<int> neighboursColors = NeighboursColors();
            for (int i = 0; i < 150; i++)
            {
                if(!neighboursColors.Contains(i))
                {
                    Color = i;
                    break;
                }
            }

        }
        public List<int> NeighboursColors()
        {
            List<int> colors = new List<int>();
            foreach (Node node in neighbours)
            {
                colors.Add(node.Color);
            }
            return colors;
        }
        public void SetDegreeOfNode()
        {
            if (NodeDegree != 0)
            {
                NodeDegree = neighbours.Count;
            }
        }
        public int CompareTo(Node node)
        {
            if(node == null) return 1;

            return NodeDegree.CompareTo(node.NodeDegree);
        }

    }
}
