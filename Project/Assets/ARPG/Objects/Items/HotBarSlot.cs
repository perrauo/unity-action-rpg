using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Cirrus.ARPG.Objects.Items
{
    public class VirtualHotBarSlot : VirtualSlot
    {
        public VirtualHotBarSlot(Slot slot) : base(slot) { }
    }

    public class HotBarSlot : Slot
    {
        public Text NumberText;

        public override VirtualSlot CreateVirtualSlot()
        {
            return new VirtualHotBarSlot(this);
        }
    }
}