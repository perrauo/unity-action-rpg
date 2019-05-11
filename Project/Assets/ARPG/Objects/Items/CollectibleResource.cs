using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.ARPG.Objects.Items.Collectibles
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Items/Collectible")]
    public class CollectibleResource : ScriptableObject
    {
        [SerializeField]
        public List<DH.Actions.BaseEffect> Effects;

        [SerializeField]
        public float LimitIdle = 2f;

        [SerializeField]
        public float RotateSpeed = 10;

        // Speed in units per sec.
        [SerializeField]
        public float ChaseSpeed = 10;

    }
}
