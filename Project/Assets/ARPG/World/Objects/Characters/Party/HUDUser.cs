using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects.Characters.Playable
{
    public class HUDUser : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

        [SerializeField]
        private Profile _profile;

        // TODO
        public void Awake()
        {
            if (_profile == null)
            {
                var res = GameObject.Find("Profile.SheepGirl");
                if (res != null)
                {
                    _profile = res.GetComponent<Profile>();
                }
            }
        }

        public void Start()
        {
            if (_profile == null)
                return;

            _character.Attributes.Health.OnCurrentChangedHandler += OnHealthChanged;
            _character.Attributes.Energy.OnCurrentChangedHandler += OnEnergyChanged;
            OnHealthChanged(_character.Attributes.Health);
            OnEnergyChanged(_character.Attributes.Energy);
        }


        public void OnHealthChanged(World.Objects.Attributes.StatResource.StatPersistence ratio)
        {
            _profile.OnHealthChanged(ratio);
        }

        public void OnEnergyChanged(World.Objects.Attributes.StatResource.StatPersistence ratio)
        {
            _profile.OnEnergyChanged(ratio);
        }

    }
}