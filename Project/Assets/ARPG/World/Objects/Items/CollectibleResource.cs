using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.ARPG.World.Objects.Items.Collectibles
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Items/Collectible")]
    public class CollectibleResource : Resource
    {
        [SerializeField]
        private Collectible _template;

        public override BaseObject Template
        {
            get
            {
                return _template;
            }
        }

        [SerializeField]
        public Actions.AssetAction Action;

        [SerializeField]
        public float LimitIdle = 2f;

        [SerializeField]
        public float RotateSpeed = 10;

        // Speed in units per sec.
        [SerializeField]
        public float ChaseSpeed = 10;

        public Collectible Create(Room room, CollectiblePersistence persistence)
        {
            Collectible col = Instantiate(
                _template.gameObject,
                persistence._position,
                Quaternion.identity,
                room.transform).GetComponent<Collectible>();

            col._persistence = persistence;
            return col;
        }
    }
}
