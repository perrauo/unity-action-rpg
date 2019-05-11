using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cirrus.Tags;

namespace Cirrus.ARPG.Objects.Characters.Playable
{ 
    public class Profile : MonoBehaviour, ITagged
    {
        [SerializeField]
        private List<Tag> _tags;
        public IEnumerable<Tag> Tags => _tags;

        [SerializeField]
        private PlayfulSystems.ProgressBar.ProgressBarPro _health;

        [SerializeField]
        private PlayfulSystems.ProgressBar.ProgressBarPro _energy;

        [SerializeField]
        private PlayfulSystems.ProgressBar.ProgressBarPro _experience;


        public void OnHealthChanged(Objects.Attributes.Stat.Product ratio)
        {
            _health.SetValue(ratio.Current, ratio.Total);
        }

        public void OnEnergyChanged(Objects.Attributes.Stat.Product ratio)
        {
            _energy.SetValue(ratio.Current, ratio.Total);
        }


    }
}