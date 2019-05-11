using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Items;
using Cirrus.ARPG.Objects.Characters.Actions;


namespace Cirrus.ARPG.Objects.Items
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Items/Key Item")]
    public class KeyResource : Resource
    {
        [SerializeField]
        private Sprite _icon;
    }
}