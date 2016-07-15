using PriorityQueue.Collections;
using PriorityQueue.Comparers;
using System;
using System.Collections.Generic;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {

            // Sample with integers
            var rando = new Random();
            var max = 100;

            IComparer<int> comparer = new IntComparer();
            var queue = new PriorityQueue<int>(comparer);

            for (int i = 0; i < max; i++)
            {
                queue.Offer(rando.Next(max));
            }

            while (queue.Count > 0)
            {
                var next = queue.Poll();
                Console.WriteLine(next);
            }

        }
    }
}
