using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.UI
{
    public class ItemSlot : Slot
    {
        public virtual ItemSlot Create(Transform parent, int index)
        {
            _index = index;
            ItemSlot slot = Instantiate(this, parent).GetComponent<ItemSlot>();
            return slot;
        }
    }
}
