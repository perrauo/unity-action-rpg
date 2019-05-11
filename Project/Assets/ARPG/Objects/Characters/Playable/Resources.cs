using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Objects.Characters.Playable
{
    public class Resources : MonoBehaviour
    {
        [SerializeField]
        public Character PlayerCharacter;

        [SerializeField]
        public Controls.Controller PlayerController;
    }
}
