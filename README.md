![alt text](https://raw.githubusercontent.com/masterjeef/rapid-priority-queue/master/min-heap.png "Rapid Priority Queue")

# Rapid Priority Queue

A simple and super efficient priority Queue for .net that uses a min heap for the underlying data structure.

| Method | Operation | Time Complexity |
| ------ | --------- | --------------- |
| Peek() | Find Min | O(1) |
| Offer() | Insert | O(log(n)) |
| Poll() | Dequeue | O(log(n)) |

You can read more about heaps here : https://en.wikipedia.org/wiki/Heap_(data_structure)

## Get the code

To install Rapid Priority Queue, run the following command in the Package Manager Console

    Install-Package RapidPriorityQueue

## Usage

### Primitive Types

    var queue = new PriorityQueue<int>();
    
    var rando = new Random();
    var max = 10;
    
    for (int i = 0; i < max; i++)
    {
        queue.Offer(rando.Next(max));
    }

    while (queue.Count > 0)
    {
        var next = queue.Poll();
    }

### Complex Objects (Badgers)

##### First, our Badger class

    public class Badger
    {
        public string Color { get; set; }

        public double Weight { get; set; }

        // IMPORTANT: the less than operator must be overloaded to use this object
        // in the priority queue
        
        public static bool operator <(Badger b1, Badger b2)
        {
            return b1.Weight < b2.Weight;
        }
        
        // The greater than operator will not be used in the priority queue, but
        // you must implement both. I recommend the following.
        
        public static bool operator >(Badger b1, Badger b2)
        {
            return !(b1 < b2);
        }
    }

##### Next, Badger prioritizing

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

If you run the program you will see that the badgers are dequeued in the proper order, by ascending weight!

    The Black badger weighs 16.3 lbs
    The White badger weighs 20.5 lbs
    The Brown badger weighs 53.71 lbs