using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Cirrus.ARPG.Objects.Items
{
    public class VirtualKeySlot : VirtualSlot
    {
        public VirtualKeySlot(Slot slot) : base(slot) { }

        public override bool Accept(IInventoryItem item)
        {
            if (item == null) return true;
            return item is Items.Key;
        }

        public override void IncrementFreeCount()
        {
            _user.FreeKeySlot++;
        }

        public override void DecrementFreeCount()
        {
            _user.FreeKeySlot--;
        }
    }

    public class KeySlot : Slot
    {
        public Text NumberText;
    }
}