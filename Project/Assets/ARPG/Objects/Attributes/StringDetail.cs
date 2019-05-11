using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Objects.Attributes
{
    [CreateAssetMenu(menuName = "Cirrus/Attributes/Details/StringDetail")]
    public class StringDetail : Attribute
    {
        [SerializeField]
        public string Value;
    }
}