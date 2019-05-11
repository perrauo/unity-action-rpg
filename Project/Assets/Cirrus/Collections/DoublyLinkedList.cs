using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace Cirrus.Collections
{
    public class List<T>
    {
        public Node<T> Head
        {
            get
            {
                return _head;
            }
        }

        public Node<T> Tail
        {
            get
            {
                return _tail;
            }
        }

        private Node<T> _head;
        private Node<T> _tail;
        private Dictionary<T, Node<T>> _cache;
        //private Lock _lock;

        public int Count
        {
            get
            {
                //_lock.Acquire();
                int count = _count;
                //_lock.Release();
                return count;
            }
        }

        public void Clear()
        {
            _head = null;
            _count = 0;

            
        }


        private int _count;

        public List()
        {
            _count = 0;
            _head = _tail = null;
           // _lock = new Lock();
            _cache = new Dictionary<T, Node<T>>();
        }


        public bool Empty()
        {
            return (_count == 0);
        }

        public void PushBack(T item)
        {
           // _lock.Acquire();
            try
            {
                if (_head == null)
                {
                    Node<T> i = new Node<T>();
                    i.Data = item;
                    _head = _tail = i;
                    _cache[item] = i;
                }
                else
                {
                    Node<T> i = new Node<T>();
                    i.Data = item;
                    _tail.Next = i;
                    i.Previous = _tail;
                    _tail = i;
                    _cache[item] = i;
                }
                _count++;
                //Logging.Trace(item + " added to linked list.  Now have " + _count + " items.");
            }
            finally
            {
               // _lock.Release();
            }
        }

        public void PushFront(T item)
        {
                if (_head == null)
                {
                    Node<T> i = new Node<T>();
                    i.Data = item;
                    _head = _tail = i;
                    _cache[item] = i;
                }
                else
                {
                    Node<T> i = new Node<T>();
                    i.Data = item;
                    _head.Previous = i;
                    i.Next = _head;
                    _head = i;
                    _cache[item] = i;
                }

                _count++;
                //Logging.Trace(item + " added to linked list.  Now have " + _count + " items.");


        }

        public void Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("item cannot be null");
            }
            //Debug.Assert("Tried to remove null item from DoublyLinkedList", item != null);
           // _lock.Acquire();
            if (!_cache.ContainsKey(item))
            {
                //_lock.Release();
                throw new ArgumentException("item is not in the list");
            }

            Node<T> current = _cache[item];
            //Logging.Trace(current.Data + " equals " + item + ".  Removing item from doubly linked list.");
            // this is the item, remove it
            Node<T> previous = current.Previous;
            Node<T> next = current.Next;
            if (previous == null)
            {
                // this must be the head
                _head = next;
            }
            else
            {
                previous.Next = next;
            }
            if (next == null)
            {
                // this must be the tail
                _tail = previous;
            }
            else
            {
                next.Previous = previous;
            }
            _count--;
            //Logging.Trace("Doubly linked list now has " + _count + " items.");
            _cache.Remove(item);
           // _lock.Release();
            return;
        }
    }

    public class Node<T>
    {
        public T Data;
        public Node<T> Previous;
        public Node<T> Next;
    }
}