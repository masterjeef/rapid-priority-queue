using PriorityQueue;
using PriorityQueue.Collections;
using PriorityQueue.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Comparers;
using Xunit;

namespace Testing
{
    public class PriorityQueueTests
    {

        [Fact]
        public void Priority_queue_must_queue_primitive_types()
        {
            var rando = new Random();
            var max = 1000;
            var queue = new PriorityQueue<int>(new IntComparer());

            for (int i = 0; i < max; i++)
            {
                queue.Offer(rando.Next(max));
            }

            Assert.True(queue.Count == max);

            while (queue.Count > 0)
            {
                var next = queue.Poll();

                if (queue.Count > 0)
                {
                    Assert.True(queue.Peek() >= next);
                }
            }
        }

        [Fact]
        public void Priority_queue_can_queue_complex_objects()
        {
            var badgers = new[]
            {
                new Badger { Color = "White", Weight = 20.5 },
                new Badger { Color = "Brown", Weight = 53.71 },
                new Badger { Color = "Black", Weight = 16.3 },
            };

            var badgerComparer = new BadgerComparer();

            var badgerQueue = new PriorityQueue<Badger>(badgerComparer);

            foreach (var badger in badgers)
            {
                badgerQueue.Offer(badger);
            }

            var first = badgerQueue.Poll();
            Assert.Equal(first.Weight, 16.3);

            var second = badgerQueue.Poll();
            Assert.Equal(second.Weight, 20.5);

            var third = badgerQueue.Poll();
            Assert.Equal(third.Weight, 53.71);

            Assert.True(badgerQueue.Count == 0);
        }
    }
}
