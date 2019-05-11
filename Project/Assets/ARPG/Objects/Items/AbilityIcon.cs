using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cirrus.ARPG.Objects.Actors;
//using Cirrus.ARPG.Objects.Actions;
//using Cirrus.ARPG.Objects.Actions.Goals;
using UnityEngine.UI;
using Cirrus.ARPG.Objects.Characters.Actions;

namespace Cirrus.ARPG.Objects.Items
{
    public class AbilityIcon : Icon
    {
        [SerializeField]
        private Image _cooldown;

        public Characters.Actions.Ability _action;

        [SerializeField]
        private float _pulseScaleAmount = 2f;

        private Vector3 _pulseScaleAmountVector;

        [SerializeField]
        private float _pulseScaleTime = 1.2f;

        public string Name = "";

        public void Start()
        {
            _pulseScaleAmountVector = new Vector3(_pulseScaleAmount, _pulseScaleAmount);
        }

        public void SetAction(Characters.Actions.Ability a)
        {
            _action = a;
            _action.OnUsedHandler += OnUsed;
        }

        private void OnUsed(Characters.Actions.Ability ability)
        {
            iTween.PunchScale(_icon.gameObject, _pulseScaleAmountVector, _pulseScaleTime);
        }

        public void Update()
        {
            if (_action == null)
                return;

            if (_cooldown != null && _action != null)
                _cooldown.fillAmount = _action.Cooldown / _action.MaxCooldown;
        }
    }

}
