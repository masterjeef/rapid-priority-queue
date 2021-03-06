﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue.Comparers
{
    public interface IQueue<T>
    {
        T Poll();

        bool Offer(T t);

        T Peek();
    }
}
