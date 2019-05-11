using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.ARPG.Objects.Items.Collectibles
{
    public delegate void OnCollected(Collectible collectible);

    public class Collectible : MonoBehaviour
    {
        [SerializeField]
        public CollectibleResource _resource;

        private Characters.Character _character = null;

        private float _timeIdle = 0f;

        [SerializeField]
        private GameObject _visual;    


        public void Update()
        {
            if(_visual != null)
                _visual.transform.Rotate(Vector3.right * UnityEngine.Time.deltaTime * _resource.RotateSpeed);

            if (_timeIdle >= _resource.LimitIdle)
            {
                if (_character != null)
                {
                    float step = _resource.ChaseSpeed * UnityEngine.Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, _character.transform.position, step);
                    if (Cirrus.Utils.Vectors.CloseEnough(transform.position, _character.transform.position))
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
            foreach (var ef in _resource.Effects)
            {
                ef.TryApply(_character);
            }

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


