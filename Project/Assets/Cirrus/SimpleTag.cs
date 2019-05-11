using UnityEngine;
using System.Collections;

namespace Cirrus.Tags
{
    [CreateAssetMenu(menuName="Cirrus/Tag")]
    public class SimpleTag : Tag
    {
        [SerializeField]
        [Editor.EnumFlag]
        public Cirrus.Utils.Flag _flags;

        public override int Flags {
            get
            {
                return (int) _flags;
            }
        }
    }
}
