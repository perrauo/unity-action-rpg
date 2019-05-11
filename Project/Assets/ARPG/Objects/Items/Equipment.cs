using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Items;
using Cirrus.ARPG.Objects.Characters.Actions;

namespace Cirrus.ARPG.Objects.Items
{
    public class Equipment : Ability, IInventoryItem
    {
        [SerializeField]
        private EquipmentResource _resource;

        protected override Resource Resource { get { return _resource; } }
    }
}