using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Cirrus.ARPG.Objects.Items
{
    public class VirtualEquipmentSlot : VirtualSlot
    {
        public VirtualEquipmentSlot(Slot slot) : base(slot) { }

        public override bool Accept(IInventoryItem item)
        {
            if (item == null) return true;
            return item is Items.Equipment;
        }

        public override void IncrementFreeCount()
        {
            //_user.FreeItemSlot++;
        }

        public override void DecrementFreeCount()
        {
            //_user.Free--;
        }
    }

    public class EquipmentSlot : Slot
    {
        public Text NumberText;


    }
}