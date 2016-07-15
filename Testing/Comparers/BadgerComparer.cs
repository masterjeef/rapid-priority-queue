using PriorityQueue;
using System.Collections.Generic;

namespace Testing.Comparers
{
    public class BadgerComparer : IComparer<Badger>
    {

        public int Compare(Badger x, Badger y)
        {
            return x.Weight.CompareTo(y.Weight);
        }
    }
}
