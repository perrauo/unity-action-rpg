using UnityEngine;
using System.Collections;

namespace Cirrus.Numeric
{

    public interface IRange : INumber
    {
        float Min { get; }

        float Max { get; }

    }


    [System.Serializable]
    public class RangeInt : IRange
    {
        [SerializeField]
        private int _min;

        [SerializeField]
        private int _max;

        public float Value
        {
            get
            {
                return Random.Range(_min, _max);

            }
        }

        public float Max
        {
            get
            {
                return _max; ;
            }
        }

        public float Min
        {
            get
            {
                return _min; ;
            }
        }
    }

    [System.Serializable]
    public class RangeFloat : IRange
    {
        [SerializeField]
        private FloatNumber _min;

        public float Min
        {
            get
            {
                return _min.Value;
            }
        }

        [SerializeField]
        private FloatNumber _max;

        public float Max
        {
            get
            {
                return _max.Value;
            }
        }


        public float Value
        {
            get
            {
                return Random.Range(_min.Value, _max.Value);

            }
        }
    }

    [System.Serializable]
    public class Range : IRange
    {
        [SerializeField]
        private SimpleNumber _min;

        [SerializeField]
        private SimpleNumber _max;

        public float Value
        {
            get
            {
                return Random.Range(_min.Value, _max.Value);

            }
        }

        public float Min
        {
            get
            {
                return _min.Value;
            }
        }

        public float Max
        {
            get
            {
                return _max.Value;
            }
        }
    }
}