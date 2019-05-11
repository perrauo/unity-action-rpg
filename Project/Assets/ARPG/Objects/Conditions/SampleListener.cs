using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Objects.Conditions
{ 
    // Sample listener not just Object ( Maybe time listener, shoould only be checked once )
    public class SampleListener : ObjectListener
    {
        private float _sampleRate;

        private Timer _timer;

        public SampleListener(BaseObject target, float sampleRate) : base(target)
        {
            _sampleRate = sampleRate;
            _timer = new Timer(_sampleRate, start: true, repeat: true);
            _timer.OnTimeLimitHandler += OnTimeLimit;
        }

        public void OnTimeLimit()
        {
            OnObjectListenedHandler?.Invoke(_target);
        }

    }

}