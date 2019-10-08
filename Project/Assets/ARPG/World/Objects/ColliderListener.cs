using UnityEngine;
using System.Collections;
using Cirrus.Editor;
using System.Collections.Generic;

namespace Cirrus.ARPG.World.Objects
{
    // TODO move in the conditions

    public delegate void OnCollisionEvent(Collision other);
    public delegate void OnColliderEvent(Collider other);

    public class ColliderListener : MonoBehaviour
    {
        [SerializeField]
        private bool _isProxy = false;

        [SerializeField]
        private bool _cacheCollisions = false;

        [ConditionalHide("_isProxy", true)]
        [Header("Real subject if 'this' is a proxy")]
        [SerializeField]
        private ColliderListener _source;

        public OnCollisionEvent OnCollisionEnterHandler;
        public OnColliderEvent OnTriggerEnterHandler;
        public OnCollisionEvent OnCollisionExitHandler;
        public OnColliderEvent OnTriggerExitHandler;
        public OnColliderEvent OnTriggerStayHandler;
        public OnCollisionEvent OnCollisionStayHandler;

        private List<Collider> _colliders;

        public IEnumerable<Collider> Colliders
        {
            get
            {
                return _colliders;
            }
        }

        private List<Collision> _collisions;

        public IEnumerable<Collision> Collisions
        {
            get
            {
                return _collisions;
            }
        }

        public void Start()
        {
            if (!_isProxy || _source == null) return;

            // TODO: check if we can just += the handles.
            _source.OnCollisionEnterHandler += OnCollisionEnter;
            _source.OnTriggerEnterHandler += OnTriggerEnter;
            _source.OnTriggerStayHandler += OnTriggerStay;
            _source.OnCollisionStayHandler += OnCollisionStay;
        }


        private void OnCollisionEnter(Collision collision)
        {
            OnCollisionEnterHandler?.Invoke(collision);
            if(_cacheCollisions)
                _collisions.Add(collision);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterHandler?.Invoke(other);
            if (_cacheCollisions)
                _colliders.Add(other);
        }

        private void OnCollisionExit(Collision collision)
        {
            OnCollisionExitHandler?.Invoke(collision);
            if (_cacheCollisions)
                _collisions.Remove(collision);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExitHandler?.Invoke(other);
            if (_cacheCollisions)
                _colliders.Remove(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerStayHandler?.Invoke(other);
        }

        private void OnCollisionStay(Collision collision)
        {
            OnCollisionStayHandler?.Invoke(collision);
        }


    }

}
