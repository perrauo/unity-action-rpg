using Cirrus.ARPG.World.Objects.Actions.Strategies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.ARPG.World.Objects.Actions
{
    // TODO: Pool
    // Spread ( Scatter etc)

    public class Projectile : MonoBehaviour
    {
        private BaseObject _source = null;

        [SerializeField]
        private bool _isPhysicsObject = true;

        [SerializeField]
        private Vector3 _positionOffset = Vector3.zero;

        ////
        ///
        private Vector3 _velocity;

        [Editor.ConditionalHide("_isPhysicsObject", isVisible = true)]
        [SerializeField]
        private Rigidbody _rigidBody;

        [Editor.ConditionalHide("_isPhysicsObject", isVisible = true)]
        [SerializeField]
        private float _startSpeed = 0.5f;

        [Editor.ConditionalHide("_isPhysicsObject", isVisible = true)]
        [SerializeField]
        public float _acceleration = 0.0f;

        [Editor.ConditionalHide("_isPhysicsObject", isVisible = true)]
        [SerializeField]
        public float _gravity = 1.0f;
        ////

        [Editor.ConditionalHide("_isPhysicsObject", isVisible =false)]
        [SerializeField]
        private float _speed;

        [Editor.ConditionalHide("_isPhysicsObject", isVisible = false)]
        [SerializeField]
        private AnimationCurve _curve;

        private float _animationTime = 0;

        ////

        public OnObjectEvent OnTargetHitHandler;

        void Start()
        {
            _rigidBody.velocity = _velocity;
        }

        public void Update()
        {
            Vector3 acceleration = _rigidBody.velocity.normalized * _acceleration * Time.deltaTime;
            _velocity += acceleration;            
        }

        // gravity and drag.
        public void FixedUpdate()
        {
            _rigidBody.AddForce(Physics.gravity * _gravity * _rigidBody.mass);
        }

        public Projectile Create(BaseObject source, Vector3 position, Vector3 direction)
        {
            Projectile p = Instantiate(this.gameObject, position + _positionOffset, Quaternion.identity).GetComponent<Projectile>();
            Quaternion rotation = Quaternion.LookRotation(direction.normalized);
            p._velocity = direction * _startSpeed;
            p._source = source;
            return p;
        }

        public void OnTriggerEnter(Collider other)
        {
            var obj = other.gameObject.GetComponentInParent<BaseObject>();
            if (obj != null)
            {
                if (obj != _source)
                {
                    OnTargetHitHandler?.Invoke(obj);
                    Destroy(gameObject, 0.002f);
                }
            }            
        }


    }
}
