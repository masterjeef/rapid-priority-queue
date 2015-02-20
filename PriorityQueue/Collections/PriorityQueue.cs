using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue.Interfaces;

namespace PriorityQueue.Collections
{
    public class PriorityQueue<T> : IQueue<T>
    {

        private T[] _heap = new T[3];
        private int _size = 0;
        private int _rows = 2;

        public int Size
        {
            get
            {
                return _size;
            }
            private set
            {
                _size = value;
            }
        }

        public T Poll()
        {
            T top = default(T);
            if (Size > 0)
            {
                top = _heap[0];
                _heap[0] = _heap[Size - 1];
                Size--;
                BubbleDown(0);
            }
            return top;
        }

        public bool Offer(T t)
        {
            bool success = false;
            if (t != null)
            {
                if (Size >= _heap.Length)
                {
                    ExpandHeap();
                }
                _heap[Size] = t;
                BubbleUp(Size);
                Size++;
                success = true;
            }
            return success;
        }

        public T Peek()
        {
            T top = default(T);
            if (Size > 0)
            {
                top = _heap[0];
            }
            return top;
        }

        private void ExpandHeap()
        {
            var newHeap = new T[Size + (int)Math.Pow(2, _rows)];
            for (int i = 0; i < _heap.Length; i++)
            {
                newHeap[i] = _heap[i];
            }
            _heap = newHeap;
            _rows++;
        }

        private void BubbleUp(int index)
        {
            if (index >= 0)
            {
                int parentIndex = Parent(index);
                dynamic child = _heap[index];
                dynamic parent = _heap[parentIndex];
                if (parentIndex >= 0 && child < parent)
                {
                    _heap[parentIndex] = child;
                    _heap[index] = parent;
                    BubbleUp(parentIndex);
                }
            }
        }

        private void BubbleDown(int index)
        {
            if (!IsLeaf(index))
            {
                var childIndex = LeftChild(index);
                if (childIndex < Size)
                {
                    dynamic child = _heap[childIndex];
                    dynamic rightChild = _heap[childIndex + 1];
                    if (child > rightChild)
                    {
                        childIndex++;
                    }
                    child = _heap[childIndex];
                    dynamic parent = _heap[index];
                    if (parent > child)
                    {
                        _heap[index] = child;
                        _heap[childIndex] = parent;
                        BubbleDown(childIndex);
                    }
                }
            }
        }

        private int LeftChild(int index)
        {
            return (2 * index) + 1;
        }

        private int RightChild(int index)
        {
            return (2 * index) + 2;
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private bool IsLeaf(int index)
        {
            return (index >= Size / 2) && (index < Size);
        }
    }
}
