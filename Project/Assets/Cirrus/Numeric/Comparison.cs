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
        public FlexibleNumber Reference;

        public bool Verify(float value)
        {
            return DoVerify(value, Reference.Value);
        }

        public bool Verify(float value, float reference)
        {
            return DoVerify(value, reference + Reference.Value);
        }

        private bool DoVerify(float value, float reference)
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
            Reference.OnValidate();
        }




    }
}