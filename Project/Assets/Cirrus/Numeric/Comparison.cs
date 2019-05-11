using UnityEngine;
using System.Collections;
using Cirrus.Editor;

namespace Cirrus.Numeric
{
    public enum ComparisonOperator
    {
        GreaterThan,
        GreaterThanEqual,
        LesserThan,
        LesserThanEqual,
        Equal
    }

    [System.Serializable]
    public class Comparison
    {
        [SerializeField]
        private ComparisonOperator _operator;

        [SerializeField]
        private Numeric.FlexibleNumber _reference;

        public bool Check(float value)
        {
            return Check(value, _reference.Value);
        }

        public bool Check(float value, float reference)
        {
            switch (_operator)
            {
                case ComparisonOperator.LesserThan:
                    return value < reference;

                case ComparisonOperator.GreaterThan:
                    return value > reference;

                case ComparisonOperator.Equal:
                    return Utils.Mathf.CloseEnough(value, reference);

                case ComparisonOperator.LesserThanEqual:
                    return value < reference || Utils.Mathf.CloseEnough(value, reference);

                case ComparisonOperator.GreaterThanEqual:
                    return value > reference || Utils.Mathf.CloseEnough(value, reference);


                default:
                    return false;
            }
        }

        public void OnValidate()
        {
            _reference.OnValidate();
        }




    }
}