using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Graph
    {
        private int[][] adjacencyList;
        private int[,] weight;
        private int[] shortest;
        private int?[] pred;

        private void Relax(int u, int v, PriorityQueue Q = null)
        {
            if (v != -1)
            {
                if (shortest[u] + weight[u, v] < shortest[v])
                {
                    shortest[v] = shortest[u] + weight[u, v];
                    pred[v] = u;
                    if (Q != null)
                        Q.setSP(v, shortest[v]);
                }
            }
        }

        public Graph()
        {
            adjacencyList = new int[][]
                    {
            new int[]{1, 2},
            new int[]{3, 2},
            new int[] {1, 3, 4 },
            new int[] {4},
            new int[] {3},
                    };
            weight = new int[,]
                {
                {0, 6, 4, 0, 0},
                {0, 0, 2, 3, 0},
                {0, 1, 0, 9, 3},
                {0, 0, 0, 0, 4},
                {7, 0, 0, 5, 0}
                };
            shortest = new int[5];
            pred = new int? [5];
        }
        public Graph(int[][] _adjacancyList, int[,] _weights)
        {
            adjacencyList = _adjacancyList;
            weight = _weights;
            shortest = new int[_adjacancyList.GetLength(0)];
            pred = new int?[_adjacancyList.GetLength(0)];
        }

        public int[][] AdjacencyList
        {
            get { return adjacencyList; }
        }

        public int[] Shortest
        {
            get { return shortest;  }
        }

        public int?[] Pred
        {
            get { return pred; }
        }

        public int [] TopologicalSort()
        {
            int[] in_degree = new int[adjacencyList.Length + 1];
            Queue<int> next = new Queue<int>();
            List<int> linear_order = new List<int>();
            foreach (int[] node in adjacencyList)
            {
                foreach (int adjacent in node)
                    if (adjacent > 0)
                        in_degree[adjacent]++;
            }
            for (int i = 0; i < in_degree.Length - 1; i++)
                if (in_degree[i] == 0)
                    next.Enqueue(i);
            while (next.Count > 0)
            {
                int u = next.Dequeue();
                linear_order.Add(u);
                foreach (int adjacent in adjacencyList[u])
                {
                    if (adjacent > 0)
                    {
                        in_degree[adjacent]--;
                        if (in_degree[adjacent] == 0)
                            next.Enqueue(adjacent);
                    }
                }
            }
            return linear_order.ToArray();
        }

        public void DagShortestPaths(int V)
        {
            int[] linear_order = TopologicalSort();
            foreach (int u in linear_order)
                foreach (int adjacent in AdjacencyList[u])
                    Relax(u, adjacent);
        }

        public void Dijkstra(int V)
        {
            for (int i = V+1; i < shortest.Length; i++)
                shortest[i] = 100500;
            PriorityQueue PQ = new PriorityQueue(shortest.Length);
            for (int i = 0; i < shortest.Length; i++)
            {
                PQ.insert(i, shortest[i]);
            }
            while (PQ.Count > 0)
            {
                int node = PQ.extractMin();
                foreach (int adjacent in adjacencyList[node])
                {
                    Relax(node, adjacent, PQ);
                }
            }

        }
    }
}
