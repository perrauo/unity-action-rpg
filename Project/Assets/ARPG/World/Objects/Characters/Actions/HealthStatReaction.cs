using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.ARPG.World.Objects.Characters.Actions
{
    // TODO segregate into multible reactions
    // Which may or may not be exhibited by a given agent

    // e.g pop up does not apply to all stats
    // fix that


    // THIS IS GOOD :)
    // Health hardcoded
    // Do not extent StatResposne if it exists

    public class HealthStatReaction : CharacterReaction
    {
        [SerializeField]
        private StatPopup _popupTemplateRemove;

        [SerializeField]
        private StatPopup _popupTemplateAdd;

               
        public override void Awake()
        {
            base.Awake();

            
        }

        public override void Start()
        {
            base.Start();

            _character.Attributes.Health.OnCurrentChangedHandler += OnStatUpdated;
        }

        public void OnStatUpdated(Objects.Attributes.StatResource.StatPersistence stat)
        {
            float delta = stat.Current - stat.Previous;

            if (delta < 0)
            {
                _popupTemplateRemove.Create(_character, delta);
            }
            else
            {
                _popupTemplateAdd.Create(_character, delta);
            }

            _character.UI.Show();
            _character.UI.Health.SetValue(
                _character.Attributes.Health.Current,
                _character.Attributes.Health.Total);
        }
        
    }
}
