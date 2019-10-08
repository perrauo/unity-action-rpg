using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirrus.Collections
{

    public class Ahnentafel
    {
        protected ArrayList m_content;

        protected Ahnentafel()
        {
            m_content = new ArrayList();
        }

        public bool isEmpty()
        {
            if (getCount() == 0)
                return true;
            return false;
        }

        public int getCount()
        {
            return m_content.Count;
        }

        public void clear()
        {
            m_content.Clear();
        }

        protected int getParentIndex(int index)
        {
            if (index < 0 || index > getCount() - 1)
                throw new System.InvalidOperationException("Invalid index.");
            int result = (int)Math.Floor(((double)index - 1) / 2);
            return result;
        }

        protected int getLeftChildIndex(int index)
        {
            if (index < 0 || index > getCount() - 1)
                throw new System.InvalidOperationException("Invalid index.");
            int result = (2 * index) + 1;
            if (result > getCount() - 1)
                result = index; // return itself if no children
            return result;
        }

        protected int getRightChildIndex(int index)
        {
            if (index < 0 || index > getCount() - 1)
                throw new System.InvalidOperationException("Invalid index.");
            int result = (2 * index) + 2;
            if (result > getCount() - 1)
                result = index; // return itself if no children
            return result;
        }
    }
    public enum HeapType
    {
        minHeap,
        maxHeap
    };




    public class Heap<T> : Ahnentafel, IHeap<T> where T : IComparable<T>
    {

        private HeapType heapType;

        public Heap(HeapType type)
        {
            heapType = type;
        }

        public HeapType Type
        {
            get { return heapType; }
        }

        public T Best()
        {
            if (isEmpty())
                throw new System.InvalidOperationException("Heap is empty.");
            return (T)m_content[0];
        }

        public T ExtractBest()
        {
            T result = Best();
            DeleteBest();
            return result;
        }

        public void DeleteBest()
        {
            if (isEmpty())
                throw new System.InvalidOperationException("Heap is empty.");
            switchItems(0, getCount() - 1);
            m_content.RemoveAt(getCount() - 1);
            if (!isEmpty())
                bubbleDown(0);
        }

        public virtual int insert(T item)
        {
            int index = m_content.Add(item);
            index = bubbleUp(index);
            return index;
        }

        protected bool isFirstBigger(int first, int second)
        {
            return (((IComparable<T>)m_content[first]).CompareTo(((T)m_content[second])) > 0);
        }

        private int bubbleUp(int index)
        {
            if (index == 0)
                return 0;
            int parent = getParentIndex(index);
            // while parent is smaller and item not on root already
            while ((heapType == HeapType.minHeap && index != 0 && isFirstBigger(parent, index))
                || (heapType == HeapType.maxHeap && index != 0 && isFirstBigger(index, parent)))
            {
                switchItems(index, parent);
                index = parent;
                parent = getParentIndex(parent);
            }
            return index;
        }

        private int bubbleDown(int index)
        {
            int leftChild, rightChild, targetChild;
            bool finished = false;
            do
            {
                leftChild = getLeftChildIndex(index);
                rightChild = getRightChildIndex(index);
                // if left child is bigger then right child
                if (leftChild == index && rightChild == index) // when no children, get child will return element itself
                {
                    finished = true; // bubbled down to the end
                }
                else // bubble further
                {
                    if ((heapType == HeapType.minHeap && isFirstBigger(leftChild, rightChild)) ||
                        (heapType == HeapType.maxHeap && isFirstBigger(rightChild, leftChild)))
                        targetChild = rightChild;
                    else
                        targetChild = leftChild;
                    // if smaller item at index is bigger than smaller child
                    if ((heapType == HeapType.minHeap && isFirstBigger(index, targetChild))
                        || (heapType == HeapType.maxHeap && isFirstBigger(targetChild, index)))
                    {
                        switchItems(targetChild, index);
                        index = targetChild;
                    }
                    else
                        finished = true;
                }
            }
            while (!finished);
            return index;
        }

        private void switchItems(int index1, int index2)
        {
            T temp = (T)m_content[index1];
            m_content[index1] = m_content[index2];
            m_content[index2] = temp;
        }
    }


    public class HeapNode<T> : IComparable<HeapNode<T>>
    {
        public T t;
        public float key;

        public int CompareTo(object obj)
        {
            return key.CompareTo(obj);
        }

        public int CompareTo(HeapNode<T> other)
        {
            return key.CompareTo(other.key);
        }
    }

    public class SimpleHeap<T> : IHeap<T>
    {
        public Heap<HeapNode<T>> heap;

        public SimpleHeap(HeapType type)
        {
            heap = new Heap<HeapNode<T>>(type);
        }

        public HeapType Type => heap.Type;

        public void DeleteBest()
        {
            heap.DeleteBest();
        }

        public T ExtractBest()
        {
            return heap.ExtractBest().t;
        }

        public void Peek(out T t, out float utility)
        {
            t = heap.Best().t;
            utility = heap.Best().key;
        }

        public int Insert(T item, float utility)
        {
            var hn = new HeapNode<T>();
            hn.t = item;
            hn.key = utility;
            return heap.insert(hn);
        }

        public bool IsEmpty()
        {
            if (Count == 0)
                return true;
            return false;
        }

        public int Count
        {
            get
            {
                return heap.getCount();
            }
        }

        public void Clear()
        {
            heap.clear();
        }
    }


    public class MinHeap<T> : Heap<T>
        where T : IComparable<T>
    {
        public MinHeap()
            : base(HeapType.minHeap)
        {
        }

        public T getMin() { return base.Best(); }
        public T extractMin() { return base.ExtractBest(); }
        public void deleteMin() { base.DeleteBest(); }
    }

    public class MaxHeap<T> : Heap<T>
        where T : IComparable<T>
    {
        public MaxHeap()
            : base(HeapType.maxHeap)
        {
        }

        public T getMax() { return base.Best(); }
        public T extractMax() { return base.ExtractBest(); }
        public void deleteMax() { base.DeleteBest(); }
    }

    public class MidHeap<T> : MinHeap<T>
        where T : IComparable<T>
    {
        private MaxHeap<T> m_maxHeap;

        public MidHeap()
            : base()
        {
            m_maxHeap = new MaxHeap<T>();
        }

        public new bool isEmpty()
        {
            return (base.isEmpty() && m_maxHeap.isEmpty());
        }

        public new int getCount()
        {
            return (base.getCount() + m_maxHeap.getCount());
        }

        public new void clear()
        {
            base.clear();
            m_maxHeap.clear();
        }

        public override int insert(T item)
        {
            int value;
            if (base.isEmpty() || base.getMin().CompareTo(item) < 0)
                value = base.insert(item);
            else
                value = m_maxHeap.insert(item);
            if (m_maxHeap.getCount() > base.getCount() + 1)
                base.insert(m_maxHeap.extractMax());
            else if (base.getCount() > m_maxHeap.getCount() + 1)
                m_maxHeap.insert(base.extractMin());

            return value;
        }

        public T getMid() { return correctHeap().Best(); }
        public T extractMid() { return correctHeap().ExtractBest(); }
        public void deleteMid() { correctHeap().DeleteBest(); }

        private Heap<T> correctHeap()
        {
            if (base.getCount() > m_maxHeap.getCount())
                return this;
            else
                return m_maxHeap;
        }
    }


}
