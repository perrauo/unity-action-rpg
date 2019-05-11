using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cirrus.Utils;
using Cirrus.Editor;
using Cirrus.ARPG.Objects.Items;

namespace Cirrus.ARPG.Objects.Characters.Actions
{
    public class SimpleAbility : Ability, IInventoryItem
    {
        [SerializeField]
        private SimpleResource _resource;

        protected override Resource Resource { get { return _resource; } }
    }

}
