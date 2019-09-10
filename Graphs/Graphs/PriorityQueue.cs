using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class PriorityQueue
    {
        public PriorityQueue(int _size)
        {
            queue = new int?[_size + 1];
            shortest = new int[_size + 1];
            indexes = new int[_size + 1];
            queue[0] = null;
            count = 0;
        }
        int count;
        int?[] queue;
        int[] shortest;
        int[] indexes;

        public int Count
        { get { return count; } }

        public int?[] Queue
        {
            get { return queue; }
        }
        public void setSP(int _node, int _sp)
        {
            int tmp = shortest[_node];
            shortest[_node] = _sp;
            if (_sp > tmp)
                moveDown(_node);
            else
                moveUp(_node);
        }

        public void insert(int _v, int _sp)
        {
            queue[++count] = _v;
            indexes[_v] = count;
            shortest[_v] = _sp;
            moveUp(_v);
        }
        public int extractMin()
        {
            int result = (int)queue[1];
            queue[1] = queue[count];
            indexes[(int)queue[count]] = 1;
            moveDown((int)queue[1]);
            queue[count] = null;
            count--;
            return result;
        }

        private void moveUp(int _node)
        {
            for (int i = indexes[_node]; i > 1; i = i / 2)
            {
                if (shortest[(int)queue[i]] < shortest[(int)queue[i / 2]])
                {
                    int? temp = queue[i];
                    queue[i] = queue[i / 2];
                    queue[i / 2] = temp;
                    indexes[(int)queue[i]] = i;
                    indexes[(int)temp] = i / 2;
                }
            }
        }
        private void moveDown(int _node)
        {
            for (int i = indexes[_node]; (i * 2) <= count; i = i * 2)
                if (shortest[(int)queue[i]] > shortest[(int)queue[i * 2]])
                {
                    int? temp = queue[i];
                    queue[i] = queue[i * 2];
                    queue[i * 2] = temp;
                    indexes[(int)queue[i]] = i;
                    indexes[(int)temp] = i * 2;
                }
            for (int i = indexes[_node]; (i * 2 + 1) <= count; i = i * 2)
                if (shortest[(int)queue[i]] > shortest[(int)queue[i * 2 + 1]])
                {
                    int? temp = queue[i];
                    queue[i] = queue[i * 2 + 1];
                    queue[i * 2 + 1] = temp;
                    i = i * 2 + 1;
                    indexes[(int)queue[i]] = i;
                    indexes[(int)temp] = i / 2 + 1;
                }
        }
    }
}
