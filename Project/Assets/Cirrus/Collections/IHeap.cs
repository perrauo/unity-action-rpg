using System;

namespace Cirrus.Collections
{
    public interface IHeap<T>
    {
        HeapType Type { get; }

        void DeleteBest();
        T ExtractBest();
        //T Best();
        //int insert(T item);
    }
}