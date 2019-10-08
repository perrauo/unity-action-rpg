using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cirrus.ARPG.World.Objects;
using Cirrus.ARPG.World.Objects.Characters;
//using Cirrus.ARPG.World.Objects.BaseObjects.Effects;
using Cirrus.ARPG.World.Objects.Characters.Controls;

using System.Threading;

namespace Cirrus.ARPG.World.Objects
{
    public class SceneList : MonoBehaviour, IList<BaseObject>
    {
        public BaseObject this[int index] { get => _list[index]; set => _list[index] = value; }

        public delegate void OnList(SceneList list);

        public delegate void OnListEvent(SceneList list, BaseObject obj);

        public delegate void OnListManyEvent(SceneList list, IEnumerable<BaseObject> obj);

        public OnList OnListClearHandler;

        public OnList OnListChangedHandler;

        public OnListEvent OnAddedHandler;

        public OnListEvent OnRemovedHandler;


        public OnListManyEvent OnAddedManyHandler;

        public OnListManyEvent OnRemovedManyHandler;


        // TODO : listen to list event inside agent to update Environment listener

        [SerializeField]
        public List<BaseObject> _list;

        public int Count => _list.Count;

        public bool IsReadOnly => ((IList<BaseObject>)_list).IsReadOnly;

        //public bool IsReadOnly => _list.IsReadOnly;

        // TODO
        private Mutex _mutex;

        public void OnEnable()
        {
            _mutex = new Mutex();
            _list = new List<BaseObject>();
        }

        public void SendEvent()
        {
            OnListChangedHandler?.Invoke(this);
        }

        public void Add(BaseObject item)
        {            
            _list.Add(item);
            OnAddedHandler?.Invoke(this, item);

        }

        public void AddRange(IEnumerable<BaseObject> objects)
        {
            ((List<BaseObject>)_list).AddRange(objects);
            OnAddedManyHandler?.Invoke(this, objects);
        }


        public void Clear()
        {
            IEnumerable<BaseObject> content = _list.ToArray();
            _list.Clear();
            OnRemovedManyHandler?.Invoke(this, content);

        }

        public bool Contains(BaseObject item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(BaseObject[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<BaseObject> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(BaseObject item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, BaseObject item)
        {
            _list.Insert(index, item);
            OnAddedHandler?.Invoke(this, item);

        }

        public bool Remove(BaseObject item)
        {
            bool res = _list.Remove(item);
            OnRemovedHandler?.Invoke(this, item);
            return res;
        }

        public void RemoveRange(IEnumerable<BaseObject> objects)
        {
            List<BaseObject> removed = new List<BaseObject>();
            foreach (BaseObject obj in objects)
            {
                if (_list.Remove(obj))
                {
                    removed.Add(obj);
                }

            }

            OnRemovedManyHandler?.Invoke(this, removed);
        }

        public void RemoveAt(int index)
        {
            BaseObject obj = _list[index];
            _list.RemoveAt(index);  
            OnRemovedHandler?.Invoke(this, obj);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
