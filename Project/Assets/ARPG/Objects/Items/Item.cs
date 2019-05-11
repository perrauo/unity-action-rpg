using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Items;
using Cirrus.ARPG.Objects.Characters.Actions;

namespace Cirrus.ARPG.Objects.Items
{
    public class Item : Ability, IInventoryItem
    {
        [SerializeField]
        private ItemResource _resource;

        protected override Resource Resource { get { return _resource; } }
    }
}