using UnityEngine;
using System.Collections;
using Cirrus.Editor;
using UnityEditor;

namespace Cirrus.Numeric
{
    [CreateAssetMenu(menuName = "Cirrus/Numeric/Operations/Multiply")]
    public class MultiplyOperation : Operation
    {
        [SerializeField]
        private FlexibleNumber _number;

        [SerializeField]
        private bool _isSubtract = false;
        
        public override float Evaluate(float value, float total)
        {
            return value * _number.Value;
        }

        public void OnValidate()
        {
            _number.OnValidate();
        }
    }
}