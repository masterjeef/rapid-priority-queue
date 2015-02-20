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
            for (int i = 0; i < 10; i++)
            {
                queue.Offer(rando.Next(max));
            }
            while (queue.Size > 0)
            {
                Console.WriteLine(queue.Poll());
            }
        }
    }
}
