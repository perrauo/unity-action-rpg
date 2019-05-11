using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Objects.Attributes
{
    [CreateAssetMenu(menuName = "Cirrus/Attributes/Details/NumericDetail")]
    public class NumericDetail : Attribute
    {
        [SerializeField]
        public int Value;
    }
}