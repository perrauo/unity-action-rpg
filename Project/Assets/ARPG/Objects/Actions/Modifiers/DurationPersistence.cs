using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Objects.Actions.Modifiers
{
    public class DurationPersistence : Persistence
    {
        [SerializeField]
        private float _duration = 2;

        public class Timer
        {
            private float _time;

            private float _duration;

            private Modifier.Product _modifier;

            public Timer(Modifier.Product modifier, float duration)
            {
                _modifier = modifier;
                _time = 0;
                _duration = duration;
                Levels.Room.Instance.Clock.OnTickedHandler += OnTicked;                
            }

            public void OnTicked()
            {
                _time += UnityEngine.Time.deltaTime;
                if (_time >= _duration)
                {
                    _modifier.EndPersistence();
                }
            }
        }

        public override void SetPersistence(Modifier.Product product)
        {
            new Timer(product, _duration);
        }
    }




}