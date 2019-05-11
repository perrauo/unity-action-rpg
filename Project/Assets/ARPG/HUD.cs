//using Cirrus.ARPG.UI.HUD/*ActionDisplay*/;
using Cirrus.ARPG.Objects.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DO NOT CURRENTLY UNPLAYABLE IN THE HUD
///


namespace Cirrus.ARPG.UI.HUD
{
    public class HUD : MonoBehaviour
    {
        public static HUD Instance = null;

        [SerializeField]
        public Objects.Items.HotBar ActionDisplay; // TODO hide

        [SerializeField]
        private PlayfulSystems.ProgressBar.ProgressBarPro _health;

        [SerializeField]
        private PlayfulSystems.ProgressBar.ProgressBarPro _energy;

        [SerializeField]
        private PlayfulSystems.ProgressBar.ProgressBarPro _experience;


        // Start is called before the first frame update
        void Awake()
        {
            Instance = this;
        }

        public void Start()
        {
            //Attributes.Health.OnCurrentChangedHandler += OnHealthChanged;
        }


        public void Register(Objects.Characters.Character character)
        {
            //character.CharacterAttributes.Health.OnCurrentChangedHandler += OnHealthChanged;
            //OnHealthChanged(character.CharacterAttributes.Health);

            //character.CharacterAttributes.Energy.OnCurrentChangedHandler += OnEnergyChanged;
            //OnEnergyChanged(character.CharacterAttributes.Energy);

            //character.CharacterAttributes.Experience.OnCurrentChangedHandler += OnExperienceChanged;
            //OnExperienceChanged(character.CharacterAttributes.Experience);


            //ActionDisplay.RegisterActor(character.Actor);
        }

        public void UnregisterCurrent()
        {

        }

        public void OnHealthChanged(Stat.Product ratio)
        {
            _health.SetValue(ratio.Current, ratio.Total);
        }

        public void OnEnergyChanged(Stat.Product ratio)
        {
            _energy.SetValue(ratio.Current, ratio.Total);
        }

        public void OnExperienceChanged(Stat.Product ratio)
        {
            _experience.SetValue(ratio.Current, ratio.Total);
        }

    }

}
