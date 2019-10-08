using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cirrus.Extensions;

namespace Cirrus.ARPG.UI
{
    public class WorldScreenUI : MonoBehaviour
    {
        [SerializeField]
        private Transform _anchor;

        private Vector3 _target;

        private Vector3 _candidate;

        [SerializeField]
        private float _smooth = 0.9f;

        private const float _dist = 10f;

        private bool _first = true;

        private RectTransform rect;
        private Rigidbody rb;

        private void Awake()
        {
            _first = true;
            rect = GetComponent<RectTransform>();
            rb = _anchor.GetComponent<Rigidbody>();
        }


        private void OnEnable()
        {
            _first = true;
        }

        void LateUpdate()
        {
            World.Room.Instance.Camera.Camera.ResetWorldToCameraMatrix(); // Force camera matrix to be updated

            _candidate.x = Mathf.Round(rb.position.x * 100f) / 100f;
            _candidate.y = Mathf.Round(rb.position.y * 100f) / 100f;
            _candidate.z = Mathf.Round(rb.position.z * 100f) / 100f;
            _candidate = Camera.main.WorldToScreenPoint(_candidate);
            //_candidate.y = Screen.height - _candidate.y;
            _candidate = _candidate.Round();// Utils.Vectors.Round(_candidate); // Pixel snapping
            _candidate.z = 0;
            rect.position = _candidate;



      


        }
    }
}