using UnityEngine;
using System.Collections;
//using Cirrus.ARPG.Players.Controls;

namespace Cirrus.ARPG.Playable.Controls
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private Schema _schema;

        // TODO: Rework ? replace by mult action map

        public Schema.CharacterActions Character { get { return _schema.Character; } }

        public Schema.LevelActions Level { get { return _schema.Level; } }

        private ICharacterActions _characterInputs;

        public void SetInputsEnabled(ICharacterActions input, bool isEnabled = true)
        {
            if (isEnabled) _schema.Character.Enable(); else _schema.Character.Disable();
        }

        /// <summary>
        /// If null is passed, then the callbacks are reset (-= callbacks)
        /// </summary>
        /// <param name="inputs"></param>
        public bool TryRegisterController(ICharacterActions inputs)
        {
            if (_characterInputs != null)
                return false;
                          
            _characterInputs = inputs;
            _schema.Character.SetCallbacks(inputs);

            return true;
        }

        public bool TryUnregisterController(ICharacterActions inputs)
        {
            if (_characterInputs == inputs)
            {
                _schema.Character.SetCallbacks(null);
                _characterInputs = null;
                return true;
            }

            return false;
        }

        private ILevelActions _levelInputs;

        public void SetInputsEnabled(ILevelActions input, bool isEnabled)
        {
            if (isEnabled) _schema.Level.Enable(); else _schema.Level.Disable();
        }

        /// <summary>
        /// If null is passed, then the callbacks are reset (-= callbacks)
        /// </summary>
        /// <param name="inputs"></param>
        public bool TryRegisterController(ILevelActions inputs)
        {
            if (_levelInputs != null)
                return false;

            _levelInputs = inputs;
            _schema.Level.SetCallbacks(inputs);

            return true;
        }

        public bool TryUnregisterController(ILevelActions inputs)
        {
            if (_levelInputs == inputs)
            {
                _schema.Level.SetCallbacks(null);
                _levelInputs = null;
                return true;
            }

            return false;
        }
    }
}