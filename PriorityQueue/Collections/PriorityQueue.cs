using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue.Comparers;
using System.Collections;

namespace PriorityQueue.Collections
{
    public class PriorityQueue<T> : IQueue<T>
    {

        private T[] _heap = new T[3];
        private int _count = 0;
        private int _rows = 2;
        private readonly IComparer<T> _comparer;

        public PriorityQueue(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public int Count
        {
            get
            {
                return _count;
            }
            private set
            {
                _count = value;
            }
        }

        /// <summary>
        /// Pulls the next object from the queue
        /// </summary>
        /// <returns>The object</returns>
        public T Poll()
        {
            T top = default(T);
            if (Count > 0)
            {
                top = _heap[0];
                _heap[0] = _heap[Count - 1];
                Count--;
                BubbleDown(0);
            }
            return top;
        }

        /// <summary>
        /// Offer an object to the queue
        /// </summary>
        /// <param name="t">The offering (object)</param>
        /// <returns>Success</returns>
        public bool Offer(T t)
        {
            bool success = false;
            if (t != null)
            {
                if (Count >= _heap.Length)
                {
                    ExpandHeap();
                }
                _heap[Count] = t;
                BubbleUp(Count);
                Count++;
                success = true;
            }
            return success;
        }

        /// <summary>
        /// Peek at the next object in the queue, but not take it out
        /// </summary>
        /// <returns>The object</returns>
        public T Peek()
        {
            T top = default(T);
            if (Count > 0)
            {
                top = _heap[0];
            }
            return top;
        }

        private void ExpandHeap()
        {
            var newHeap = new T[Count + (int)Math.Pow(2, _rows)];
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
                var child = _heap[index];
                var parent = _heap[parentIndex];
                if (parentIndex >= 0 && _comparer.Compare(child, parent) < 0)
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
                if (childIndex < Count)
                {
                    var child = _heap[childIndex];
                    var rightChild = _heap[childIndex + 1];
                    if (_comparer.Compare(child, rightChild) > 0)
                    {
                        childIndex++;
                    }
                    child = _heap[childIndex];
                    var parent = _heap[index];
                    if (_comparer.Compare(parent, child) > 0)
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
            return (index >= Count / 2) && (index < Count);
        }
    }
}
