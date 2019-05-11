using UnityEngine;
using System.Collections;


namespace Cirrus.ARPG.Objects.Characters.Controls
{
    public abstract class Controller : MonoBehaviour
    {
        [SerializeField]
        protected Character _character;

        [SerializeField]
        public Configuration Config;
    }
}