using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Characters.Actions;

namespace Cirrus.ARPG.Objects.Items
{
    [System.Serializable]
    public class InventoryItem
    {
        [SerializeField]
        public Resource _ability;
    }

    public interface IInventoryItem
    {
        Sprite Icon { get; }

        string Description { get; }
    }
}