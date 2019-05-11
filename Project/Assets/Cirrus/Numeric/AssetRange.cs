using UnityEngine;
using System.Collections;

namespace Cirrus.Numeric
{

    [CreateAssetMenu(menuName = "Cirrus/Numeric/Random Range")]
    public class AssetRange : ScriptableObject, IRange
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




        public int Integer
        {
            get
            {
                return Random.Range(_min.Integer, _max.Integer);
            }
        }

    }
}