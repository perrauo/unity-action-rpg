using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.ARPG.Objects.Actions
{
    public class CollisionReaction : InteractionReaction
    {
        [SerializeField]
        private ColliderListener _colliderListener;

        public override void Start()
        {
            base.Start();

            _colliderListener.OnCollisionEnterHandler += OnCollisionEnter;

        }

        private void OnCollisionEnter(Collision collision)
        {
            BaseObject other = collision.gameObject.GetComponent<BaseObject>();

            if (other == null)
                return;

            if (_tags.Intersect(other.Tags).Count() != 0)
            {
                OnInteraction(other);
            }
        }


    }
}
