using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

using Cirrus.ARPG.Objects.Attributes;

using Cirrus.ARPG.Objects.Characters.Attributes;

namespace Cirrus.ARPG.Objects.Characters.UI
{
    public class UI : MonoBehaviour
    {
        [SerializeField]
        private Transform _anchor;

        [SerializeField]
        private PlayfulSystems.ProgressBar.ProgressBarPro _health;

        [SerializeField]
        private Character character;


        [SerializeField]
        private bool _isHealthEnabled = false;


        public void Update()
        {
            if(_anchor != null)
            transform.position = _anchor.position;

            //if(Levels.Room.Instance.Camera != null)
            //transform.LookAt(transform.position + Levels.Room.Instance.Camera.transform.rotation * Vector3.back, Levels.Room.Instance.Camera.transform.rotation * Vector3.up);
        }


        public void Start()
        {
            if (_isHealthEnabled)
            {
                character.Persistence.Attributes.Health.OnCurrentChangedHandler += OnHealthChanged;
            }
        }

        //public void OnValidate()
        //{
        //    _isHealthEnabled = _health.gameObject.activeInHierarchy;
        //}


        public void OnHealthChanged(Stat.Product ratio)
        {
            _health.SetValue(ratio.Current, ratio.Total);
        }


    }




}
