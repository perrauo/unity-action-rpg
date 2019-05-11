using UnityEngine;
using System.Collections;
using Cirrus.Editor;
using UnityEditor;

namespace Cirrus.Numeric
{
    [CreateAssetMenu(menuName = "Cirrus/Numeric/Operations/Add")]
    public class AddOperation : Operation
    {
        [SerializeField]
        private FlexibleNumber _number;

        [SerializeField]
        private bool _isSubtract = false;
        
        public override float Evaluate(float value, float total)
        {
            return _isSubtract ?  value - _number.Value : value + _number.Value;
        }

        public void OnValidate()
        {
            _number.OnValidate();
        }
    }
}