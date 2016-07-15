using System.Collections.Generic;

namespace PriorityQueue.Comparers
{
    public class IntComparer : IComparer<int>
    {

        public int Compare(int x, int y)
        {
            return x - y;
        }
    }
}
