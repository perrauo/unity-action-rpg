using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.World.Objects.Attributes;
using Cirrus.Extensions;
using UnityEngine;

namespace Cirrus.ARPG.World.Objects.Items.Collectibles
{
    public delegate void OnCollectibleEvent(Collectible collectible);

    public class Collectible : BaseObject
    {
        private Actions.ActionProduct _action = null;

        private Characters.Character _character = null;

        private float _timeIdle = 0f;

        [SerializeField]
        private GameObject _visual;

        [SerializeField]
        public CollectibleResource _resource;

        public CollectiblePersistence _persistence;

        public override Persistence Persistence
        {
            get
            {
                return _persistence;
            }
        }

        public override Characters.Attributes.AttributesPersistence Attributes => throw new System.NotImplementedException();        

        protected override void PopulatePersistence()
        {
            _persistence = new CollectiblePersistence(_resource);
        }

        public override void Awake()
        {
            base.Awake();
        }

        public void Update()
        {
            if(_visual != null)
                _visual.transform.Rotate(Vector3.right * Time.deltaTime * _resource.RotateSpeed);

            if (_timeIdle >= _resource.LimitIdle)
            {
                if (_character != null)
                {

                    if (_resource.Action != null && _action == null)
                    {
                        _action = _resource.Action.Create();
                    }

                    float step = _resource.ChaseSpeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, _character.Transform.position, step);
                    if (transform.position.IsCloseEnough(_character.Transform.position))
                    {
                        OnCollect();
                    }
                }
            }
            else
            {
                _timeIdle += UnityEngine.Time.deltaTime;
            }
        }

        public void OnCollect()
        {
            if(_action != null)
                _action.UseAgainst(_character);

            Destroy(gameObject);
        }
         
        public void OnTriggerEnter(Collider other)
        {
            if (_character == null)
            {
                _character = other.GetComponent<Characters.Character>();
            }
        }
    }
}


