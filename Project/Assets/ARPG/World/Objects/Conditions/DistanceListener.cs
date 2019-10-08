using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects.Conditions
{
    // MEMORY LEAKS WHEN OBJECT IS DESTROYED


    // Sample listener not just Object ( Maybe time listener, shoould only be checked once )
    public class DistanceListener : ObjectListener
    {
        private BaseObject _source;

        private bool _previousComparisonResult = false;

        private Numeric.Comparison _comparison;

        private float _sampleRate;

        private float _sampleTolerance;

        Timer _timer;

        private float _previousDistance = Mathf.Infinity;

        public DistanceListener(BaseObject source, BaseObject target, Numeric.Comparison distanceComparison, float sampleRate, float sampleTolerance = 1) : base(target)
        {
            _source = source;
            _sampleRate = sampleRate;
            _sampleTolerance = sampleTolerance;
            _timer = new Timer(_sampleRate, start: true, repeat: true);
            _timer.OnTimeLimitHandler += OnTimeLimit;
            _comparison = distanceComparison;
        }

        public void OnTimeLimit()
        {
            if (_target == null)
                return;

            float distance = (_source.Transform.position - _target.Transform.position).magnitude;
            if (Cirrus.Utils.Mathf.CloseEnough(distance, _previousDistance, _sampleTolerance))
            {
                return;
            }

            _previousDistance = distance;

            if (_comparison == null)
            {
                OnObjectListenedHandler?.Invoke(_target);
                return;
            }
                                 
            bool res = _comparison.Verify(distance);

            // If results are different (veto or satisfied)
            if (_previousComparisonResult != res)
            {
                _previousComparisonResult = res;
                OnObjectListenedHandler?.Invoke(_target);
            }
            // if satisfied, then diff distance yield different result
            else if(!res)
            {
                _previousComparisonResult = res;
                OnObjectListenedHandler?.Invoke(_target);
            }
        }

    }

}