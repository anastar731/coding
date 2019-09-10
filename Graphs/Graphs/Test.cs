using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Test
    {
        private static PriorityQueue initPQ()
        {
            int[] arr = { 1, 5, 7, 4, 6, 2, 3 };
            int[] sp = { 2, 1, 7, 5, 10, 25, 7 };
            PriorityQueue PQ = new PriorityQueue(arr.Count());
            for (int i = 0; i < arr.Count(); i++)
                PQ.insert(arr[i], sp[i]);
            return PQ;
        }
        private static Graph initAcyclicWeightGraph()
        {
            Graph graph =  new Graph(new int[][]
                {
            new int[]{1, 2, 4, 5, 9, 10, 11, 14},//0
            new int[]{3},//1
            new int[]{3},//2
            new int[] {6},//3
            new int[] {7},//4
            new int[] {7},//5
            new int[] {7},//6
            new int[] {8},//7
            new int[] {12},//8
            new int[] {13},//9
            new int[] {13},//10
            new int[] {13},//11
            new int[] {13},//12
            new int[] {15},//13
            new int[] {16},//14
            new int[] {16},//15
            new int[] {17},//16
            new int[] {18},//17
            new int[] {19},//18
            new int[] {-1} //19
               }, new int[,] {
               //   0   1   2   3   4   5   6   7   8   9   10  11  12  13  14  15  16  17  18  19
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //0
                {  -2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //1
                {  -6,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //2
                {   0,-15,-15,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //3
                {  -4,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //4
                {  -3,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //5
                {   0,  0,  0, -4,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //6
                {   0,  0,  0,  0, -1, -1, -1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //7
                {   0,  0,  0,  0,  0,  0,  0, -2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //8
                {  -4,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //9
                {  -3,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //10
                {  -2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //11
                {   0,  0,  0,  0,  0,  0,  0,  0,  -1,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //12
                {   0,  0,  0,  0,  0,  0,  0,  0,  0, -4, -4, -4, -4,  0,  0,  0,  0,  0,   0,  0},    //13
                {  -3,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //14
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, -1,  0,  0,  0,  0,   0,  0},    //15
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, -1, -1,  0,  0,   0,  0},    //16
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, -3,  0,   0,  0},    //17
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, -1,   0,  0},    //18
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,   0,  0},    //19   
               } );
            return graph;
        }
        public static bool testPQInsertMethod()
        {
            int?[] result = { null,
                5, //1
                1, //2
                7, //7
                4, //5
                6, //10
                2, //25
                3 //7 }
            };
            PriorityQueue PQ = initPQ();
            bool res = Enumerable.SequenceEqual(PQ.Queue, result);
            return res;
            // return Enumerable.SequenceEqual(PQ.Queue, result);
        }
       
        public static bool testPQExtractMinMethod()
        {
            int?[] result = { null, 1, 4, 7, 3, 6, 2, 3 };
            PriorityQueue PQ = initPQ();
            if (PQ.extractMin() == 5 && Enumerable.SequenceEqual(PQ.Queue, result))
                return true;
            return false;
        }
        public static bool testPQsetSP()
        {
            PriorityQueue PQ = initPQ();
            int?[] result_decreaseKey = { null, 5, 1, 3, 4, 6, 2, 7 };
            int?[] result_increaseKey = { null, 1, 5, 3, 4, 6, 2, 7 };
            PQ.setSP(3, 4);
            bool res_deceaseKey = Enumerable.SequenceEqual(PQ.Queue, result_decreaseKey);
            PQ.setSP(5, 3);
            bool res_increaseKey = Enumerable.SequenceEqual(PQ.Queue, result_increaseKey);
            return (res_deceaseKey && res_increaseKey);
        }
        public static bool testGraphTopologicalSortMethod()
        {
            Graph graph = initAcyclicWeightGraph();
           // int[] res = graph.TopologicalSort();
            int[] result = { 0, 2, 4, 5, 9, 10, 11, 14 ,1 , 3, 6, 7, 8, 12, 13, 15, 16, 17, 18, 19 };
            bool res = Enumerable.SequenceEqual(graph.TopologicalSort(), result);
            return Enumerable.SequenceEqual(graph.TopologicalSort(), result);
        }

        public static bool testGraphDagShortestPathMethod()
        {
            Graph graph = initAcyclicWeightGraph();
            int[] resultShortest =  
                { 0, -2, -6, -21, -4, -3, -25, -26, -28, -4, -3, -2, -29, -33, -3, -34, -35, -38, -39, -39 };

            int?[] resultPred =
                { null, 0, 0, 2, 0, 0, 3, 6, 7, 0, 0, 0, 8, 12, 0, 13, 15, 16, 17, 18 };

            graph.DagShortestPaths(0);
            bool res1 = Enumerable.SequenceEqual(graph.Shortest, resultShortest);
            bool res2 = Enumerable.SequenceEqual(graph.Pred, resultPred);
            return res1 && res2;

        }

        public static bool testGraphDiekstraMethod()
        {
            Graph graph = new Graph();
            graph.Dijkstra(0);
            int[] resultShortest =
                { 0, 5, 4, 8, 7 };
            int?[] resultPred =
                { null, 2, 0, 1, 2};
            bool res1 = Enumerable.SequenceEqual(graph.Shortest, resultShortest);
            bool res2 = Enumerable.SequenceEqual(graph.Pred, resultPred);
            return true;
        }
    }
}

