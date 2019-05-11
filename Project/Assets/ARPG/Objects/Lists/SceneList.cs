using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cirrus.ARPG.Objects;
using Cirrus.ARPG.Objects.Characters;
//using Cirrus.ARPG.Objects.BaseObjects.Effects;
using Cirrus.ARPG.Objects.Characters.Controls.AI;

namespace Cirrus.ARPG.Objects
{
    public class SceneList : MonoBehaviour, IList<BaseObject>
    {
        public BaseObject this[int index] { get => ((IList<BaseObject>)List)[index]; set => ((IList<BaseObject>)List)[index] = value; }

        public virtual List<BaseObject> List { get; }

        public int Count => ((IList<BaseObject>)List).Count;

        public bool IsReadOnly => ((IList<BaseObject>)List).IsReadOnly;

        public void Add(BaseObject item)
        {
            ((IList<BaseObject>)List).Add(item);
        }

        public void Clear()
        {
            ((IList<BaseObject>)List).Clear();
        }

        public bool Contains(BaseObject item)
        {
            return ((IList<BaseObject>)List).Contains(item);
        }

        public void CopyTo(BaseObject[] array, int arrayIndex)
        {
            ((IList<BaseObject>)List).CopyTo(array, arrayIndex);
        }

        public IEnumerator<BaseObject> GetEnumerator()
        {
            return ((IList<BaseObject>)List).GetEnumerator();
        }

        public int IndexOf(BaseObject item)
        {
            return ((IList<BaseObject>)List).IndexOf(item);
        }

        public void Insert(int index, BaseObject item)
        {
            ((IList<BaseObject>)List).Insert(index, item);
        }

        public bool Remove(BaseObject item)
        {
            return ((IList<BaseObject>)List).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<BaseObject>)List).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<BaseObject>)List).GetEnumerator();
        }
    }
}
