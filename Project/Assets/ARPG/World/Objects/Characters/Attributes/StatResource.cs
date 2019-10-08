using UnityEngine;
using System.Collections;
using UnityEditor;
using Cirrus.ARPG.World.Objects.Conditions;
//using Cirrus.ARPG.Levels.Rooms.Values;
using Cirrus.Tags;
using Cirrus.Numeric;
//using System.Threading;

namespace Cirrus.ARPG.World.Objects.Attributes
{
    public delegate void OnStatEvent(StatResource.StatPersistence stat);

    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/Stat")]
    public class StatResource : ScriptableObject, Cirrus.Numeric.INumber
    {
        [HideInInspector]
        [SerializeField]
        private float _previous = 1;

        [Editor.ReadOnly]
        [SerializeField]
        private float _current = 1;

        [SerializeField]
        [Range(0f, 1f)]
        private float _percent = 1;

        [SerializeField]
        private FlexibleNumber _total;

        [SerializeField]
        private Tag _tag;

        public float Value => _current;

        public void OnValidate()
        {
            if (Cirrus.Utils.Mathf.CloseEnough(_current, _previous))
            {
                _current = _percent * _total.Value;
            }
            else
            {
                _current = Mathf.Clamp(_current, 0, _total.Value);
                _percent = _current / _total.Value;
            }

            _previous = _current;
        }


        [System.Serializable]
        public class StatPersistence : ARPG.Conditions.IConditionedState
        {
            private StatResource _resource;

            private float _prevTotal;

            private StatResource.StatPersistence _totalStat;

            [SerializeField]
            private float _total;
            public float Total { get { return _total; } }
            
            [SerializeField]
            private float _current;
            public float Current { get { return _current; } }

            private float _previous;
            public float Previous { get { return _previous; } }

            public ARPG.Conditions.OnStateChanged OnStateChangedHandler { get; set; }

            public OnStatEvent OnTotalChangedHandler;
            public OnStatEvent OnCurrentChangedHandler;

            private int _typeId = 0;

            public StatPersistence(StatResource attr) /*: base(attr)*/
            {
                _resource = attr;
                _typeId = attr._tag.GetInstanceID();
                _total = attr._total.Value;
                _current = attr._current;
            }

            public void OnTotalUpdated(StatResource.StatPersistence total)
            {
                _total = total.Current;
            }

            public StatPersistence(StatResource attr, StatResource.StatPersistence total) /*: base(attr)*/
            {
                _resource = attr;
                _current = attr._current;

                _total = total.Current;
                _totalStat = total;
                _totalStat.OnCurrentChangedHandler += OnTotalUpdated;
            }


            public void SetCurrent(float val)
            {
                _previous = _current;
                _current = val;
                _current = Mathf.Clamp(_current, 0, _total);               

                OnCurrentChangedHandler?.Invoke(this);
                OnStateChangedHandler?.Invoke(this);
            }

            public int TypeId
            {
                get
                {
                    return _resource._tag.GetInstanceID();
                }
            }

        }
    }



}


