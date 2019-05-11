using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Objects.Characters.Playable
{
    public class HUDUser : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

        [SerializeField]
        private Profile _profile;


        public void Start()
        {
            if (_profile == null)
                return;

            _character.Persistence.Attributes.Health.OnCurrentChangedHandler += OnHealthChanged;
            _character.Persistence.Attributes.Energy.OnCurrentChangedHandler += OnEnergyChanged;
            OnHealthChanged(_character.Persistence.Attributes.Health);
            OnEnergyChanged(_character.Persistence.Attributes.Energy);
        }

        public void OnValidate()
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


        public void OnHealthChanged(Objects.Attributes.Stat.Product ratio)
        {
            _profile.OnHealthChanged(ratio);
        }

        public void OnEnergyChanged(Objects.Attributes.Stat.Product ratio)
        {
            _profile.OnEnergyChanged(ratio);
        }

    }
}