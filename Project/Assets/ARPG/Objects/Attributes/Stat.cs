using UnityEngine;
using System.Collections;
using UnityEditor;
using Cirrus.ARPG.Objects.Conditions;
//using Cirrus.ARPG.Levels.Rooms.Values;
using Cirrus.Tags;

namespace Cirrus.ARPG.Objects.Attributes
{
    public delegate void OnStatChanged(Stat.Product stat);
    public delegate void OnRatioChanged(Stat.Product ratio);

    [CreateAssetMenu(menuName = "Cirrus/Attributes/Stat")]
    public class Stat : Attribute
    {        
        [SerializeField]
        private float _total;

        [SerializeField]
        private bool _isRatio = false;

        [Editor.ConditionalHide("_isRatio", isVisible = true)]
        [SerializeField]
        private float _current = 0;

        [SerializeField]
        private Tag _tag;

        public class Product : AttributeProduct, DH.Conditions.IState
        {
            private Stat _resource;

            private float _prevTotal;
            private float _total;
            public float PreviousTotal { get { return _total; } }
            public float Total { get { return _total; } }

            private float _previous;
            public float Previous { get { return _previous; } }

            private float _current;
            public float Current { get { return _current; } }

            public DH.Conditions.OnStateChanged OnStateChangedHandler { get; set; }

            public OnStatChanged OnTotalChangedHandler;
            public OnRatioChanged OnCurrentChangedHandler;

            public Product(Stat attr) : base(attr)
            {
                _resource = attr;
                _total = attr._total;
                _current = attr._current;
            }

            public void SetTotal(float val)
            {
                _prevTotal = _total;
                _total = val;
                OnTotalChangedHandler?.Invoke(this);
                OnStateChangedHandler?.Invoke(this);
            }

            public void SetCurrent(float val)
            {
                _previous = _current;
                _current = val;

                if (IsRatio)
                {
                    _current = Mathf.Clamp(_current, 0, _total);
                }

                OnCurrentChangedHandler?.Invoke(this);
                OnStateChangedHandler?.Invoke(this);
            }

            public Tag Tag
            {
                get
                {
                    return _resource._tag;
                }
            }

            public bool IsRatio
            {
                get
                {
                    return _resource._isRatio;
                }
            }

        }
    }



}


