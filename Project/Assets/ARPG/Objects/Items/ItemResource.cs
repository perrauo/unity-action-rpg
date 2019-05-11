using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Items;
using Cirrus.ARPG.Objects.Characters.Actions;

namespace Cirrus.ARPG.Objects.Items
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Items/Item")]
    public class ItemResource : Resource
    {
        [SerializeField]
        public int Count = 1;
    }
}