namespace PriorityQueue
{
    public class Badger
    {
        public string Color { get; set; }

        public double Weight { get; set; }

        /// <summary>
        /// Overrides the left less than operator
        /// This will arrange the badgers in the queue by weight.
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static bool operator <(Badger b1, Badger b2)
        {
            return b1.Weight < b2.Weight;
        }
        
        /// <summary>
        /// The greater than operator is not required to use the priority queue
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static bool operator >(Badger b1, Badger b2)
        {
            return !(b1 < b2);
        }
    }
}
