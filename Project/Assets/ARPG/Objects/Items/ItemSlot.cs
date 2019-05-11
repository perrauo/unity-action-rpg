using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Cirrus.ARPG.Objects.Characters.Actions;

namespace Cirrus.ARPG.Objects.Items
{
    public class VirtualItemSlot : VirtualSlot
    {
        public VirtualItemSlot(Slot slot) : base(slot) { }

        public override bool Accept(IInventoryItem item)
        {
            if (item == null) return true;
            return item is Item;
        }

        public override void IncrementFreeCount()
        {
            _user.FreeItemSlot++;
        }

        public override void DecrementFreeCount()
        {
            _user.FreeItemSlot--;
        }
    }

    public class ItemSlot : Slot
    {
        public override VirtualSlot CreateVirtualSlot()
        {
            return new VirtualItemSlot(this);
        }
    }
}