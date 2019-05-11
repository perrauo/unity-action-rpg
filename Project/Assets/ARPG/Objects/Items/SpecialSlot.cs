using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Cirrus.ARPG.Objects.Characters.Actions;

namespace Cirrus.ARPG.Objects.Items
{
    public class VirtualSpecialAbilitySlot : VirtualSlot
    {
        public VirtualSpecialAbilitySlot(Slot slot) : base(slot) { }

        public override bool Accept(IInventoryItem item)
        {
            if (item == null) return true;
            return item is Ability;
        }

        public override void IncrementFreeCount()
        {
            _user.FreeSpecialSlot++;
        }

        public override void DecrementFreeCount()
        {
            _user.FreeSpecialSlot--;
        }
    }

    public class SpecialSlot : AbilitySlot
    {

        public override VirtualSlot CreateVirtualSlot()
        {
            return new VirtualSpecialAbilitySlot(this);
        }

    }
}