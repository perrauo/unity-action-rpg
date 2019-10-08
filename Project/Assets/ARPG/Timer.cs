using UnityEngine;
using System.Collections;
using System;


namespace Cirrus.DH
{
    [System.Serializable]
    public class Timer
    {
        [SerializeField]
        bool _repeat = false;

        [SerializeField]
        float _limit = -1;

        [SerializeField]
        float _time = 0f;

        bool active = false;
        public bool IsActive
        {
            get
            {
                return active;
            }
        }

        public OnEvent OnTimeLimitHandler;

        public Timer(float limit, bool start = true, bool repeat = false)
        {
            _time = 0;
            _limit = limit;
            _repeat = repeat;

            if (start)
            {
                Start();
            }
        }

        public float Time
        {
            get
            {
                return _time;
            }
        }

        public void Reset(float limit = -1)
        {
            if (limit > 0)
            {
                _limit = limit;
            }

            _time = 0;
        }

        public void Start(float limit = -1)
        {
            Reset(limit);

            if (!active)
            {
                Game.Instance.Clock.OnTickedHandler += OnTicked;
            }

            active = true;
        }

        public void Resume()
        {
            if (!active)
            {
                Game.Instance.Clock.OnTickedHandler += OnTicked;
            }

            active = true;
        }

        public void Stop()
        {
            if (active)
            {
                Game.Instance.Clock.OnTickedHandler -= OnTicked;
            }

            active = false;
        }

        private void OnTicked()
        {
            _time += UnityEngine.Time.deltaTime;
            if (_time >= _limit)
            {
                OnTimeLimitHandler?.Invoke();

                if (_repeat)
                {
                    Reset();
                }
                else
                {
                    Stop();
                }
            }
        }

        ~Timer()
        {
            Stop();
        }

    }
}
