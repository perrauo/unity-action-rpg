//using Cirrus.ARPG.UI.HUD/*ActionDisplay*/;
using Cirrus.ARPG.World.Objects.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DO NOT CURRENTLY UNPLAYABLE IN THE HUD
///

    // TODO remove??


namespace Cirrus.ARPG.UI
{
    public delegate void OnHUDEvent(HUD hud);

    public class HUD : MonoBehaviour
    {
        public static HUD Instance = null;

        public static OnHUDEvent OnHUDStartStaticHandler;

        [SerializeField]
        private Menu _menu;

        [SerializeField]
        private CharacterDisplay _characterDisplay;

        public Menu Menu
        {
            get
            {
                return _menu;
            }
        }

        void Awake()
        {
            if(Instance != null)
            {
                DestroyImmediate(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            World.Room.OnCharacterStartStaticHandler += OnCharacterStart;
        }

        public void Start()
        {
            //Attributes.Health.OnCurrentChangedHandler += OnHealthChanged;
            OnHUDStartStaticHandler?.Invoke(this);
        }


        public void OnCharacterStart(World.Objects.Characters.Character character)
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



    }

}
