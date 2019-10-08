using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects.Attributes
{
    public enum ModifierId
    {
        Poisoned,
    }

    public abstract class Modifier : ScriptableObject
    {

        public enum ModeEnum
        {
            Add,
            Multiply,
            Percent         
        }

        [SerializeField]
        private ModeEnum _mode;


        [Header("Negative duration is infinite.")]
        [SerializeField]
        private float _duration = -1;

        [SerializeField]
        private float _modifier = 1;


        public float ApplyModifier(float statValue)
        {
            switch (_mode)
            {
                case ModeEnum.Add:
                        return (statValue + _modifier);               

                case ModeEnum.Multiply:
                        return (statValue * _modifier);

                case ModeEnum.Percent:
                        return (statValue * _modifier);

                default:
                        return statValue;
            }

        }

    }

}
