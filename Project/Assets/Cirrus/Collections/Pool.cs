using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Cirrus.Collections
{

    public class Pool<T> where T : new()
    {
        private readonly ConcurrentBag<T> _items = new ConcurrentBag<T>();
        private int _counter = 0;
        private const int _max = 10;

        public void Release(T item)
        {
            if (_counter < _max)
            {
                _items.Add(item);
                _counter++;
            }
        }

        public T Get()
        {
            T item;
            if (_items.TryTake(out item))
            {
                _counter--;
                return item;
            }
            else
            {
                T obj = new T();
                _items.Add(obj);
                _counter++;
                return obj;

            }
        }
    }
}