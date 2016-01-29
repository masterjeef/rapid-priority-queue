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

            // Sample with integers

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

            // Sample with Badgers

            var badgers = new []
            {
                new Badger { Color = "White", Weight = 20.5 },
                new Badger { Color = "Brown", Weight = 53.71 },
                new Badger { Color = "Black", Weight = 16.3 },
            };

            var badgerQueue = new PriorityQueue<Badger>();

            foreach (var badger in badgers)
            {
                badgerQueue.Offer(badger);
            }

            while (badgerQueue.Count > 0)
            {
                var nextBadger = badgerQueue.Poll();
                Console.WriteLine("The {0} badger weighs {1} lbs", nextBadger.Color, nextBadger.Weight);
            }
        }
    }
}
