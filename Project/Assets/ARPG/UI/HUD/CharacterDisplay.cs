using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Attributes;

namespace Cirrus.ARPG.UI
{

    public class CharacterDisplay : MonoBehaviour
    {

        [SerializeField]
        private PlayfulSystems.ProgressBar.ProgressBarPro _health;

        [SerializeField]
        private PlayfulSystems.ProgressBar.ProgressBarPro _energy;

        [SerializeField]
        private PlayfulSystems.ProgressBar.ProgressBarPro _experience;

        [SerializeField]
        public HotBar _hotBar;

        public void OnValidate()
        {
            if (_hotBar == null)
                _hotBar = GetComponentInChildren<HotBar>();
        }

        public void OnHealthChanged(StatResource.StatPersistence ratio)
        {
            _health.SetValue(ratio.Current, ratio.Total);
        }

        public void OnEnergyChanged(StatResource.StatPersistence ratio)
        {
            _energy.SetValue(ratio.Current, ratio.Total);
        }

        public void OnExperienceChanged(StatResource.StatPersistence ratio)
        {
            _experience.SetValue(ratio.Current, ratio.Total);
        }

    }
}