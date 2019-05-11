using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Cirrus.ARPG.Objects.Items
{
    public class VirtualAbilitySlot : VirtualSlot
    {
        public VirtualAbilitySlot(Slot slot) : base(slot) { }

        public override bool Accept(IInventoryItem item)
        {
            if (item == null) return true;
            return item is Characters.Actions.SimpleAbility;
        }

        public override void IncrementFreeCount()
        {
            _user.FreeAbilitySlot++;
        }

        public override void DecrementFreeCount()
        {
            _user.FreeAbilitySlot--;
        }
    }

    public class AbilitySlot : Slot
    {
        public Text NumberText;

        public override VirtualSlot CreateVirtualSlot()
        {
            return new VirtualAbilitySlot(this);
        }

    }
}