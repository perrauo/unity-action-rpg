using UnityEngine;
using System.Collections;

namespace Cirrus.Numeric
{
    [CreateAssetMenu(menuName = "Cirrus/Numeric/Number")]
    public class AssetNumber : ScriptableObject, INumber
    {
        [SerializeField]
        private Number _value;

        public float Value => ((INumber)_value).Value;

        public void OnValidate()
        {
            _value.OnValidate();
        }
    }
}
