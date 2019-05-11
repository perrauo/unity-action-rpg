using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Items;
using Cirrus.ARPG.Objects.Characters.Actions;

namespace Cirrus.ARPG.Objects.Items
{
    public class Key : Characters.Actions.Ability, IInventoryItem
    {
        [SerializeField]
        private KeyResource _resource;

        protected override Resource Resource {get {return _resource;} } 

    }
}