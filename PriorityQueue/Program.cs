using PriorityQueue.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var rando = new Random();
            var max = 100;
            var queue = new PriorityQueue<int>();

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
