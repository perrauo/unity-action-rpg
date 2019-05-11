using UnityEngine;
using System.Collections;
using Cirrus.Editor;

namespace Cirrus.ARPG.Objects
{
    // TODO move in the conditions

    public delegate void OnCollisionEnter(Collision other);
    public delegate void OnTriggerEnter(Collider other);
    public delegate void OnTriggerStay(Collider other);
    public delegate void OnCollisionStay(Collision other);


    public class ColliderListener : MonoBehaviour
    {
        [SerializeField]
        private bool _isProxy = false;

        [ConditionalHide("_isProxy", true)]
        [Header("Real subject if 'this' is a proxy")]
        [SerializeField]
        private ColliderListener _source;

        public OnCollisionEnter OnCollisionEnterHandler;
        public OnTriggerEnter OnTriggerEnterHandler;
        public OnTriggerStay OnTriggerStayHandler;
        public OnCollisionStay OnCollisionStayHandler;



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
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterHandler?.Invoke(other);
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
