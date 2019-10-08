using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Actions;
using Cirrus.ARPG.World.Objects;
using Cirrus.ARPG.World.Objects.Characters;

namespace Cirrus.ARPG.Items
{
    [System.Serializable]
    public class ItemPersistence : IActiveAbility
    {
        [SerializeField]
        public bool _isEmpty = true;

        public bool IsEmpty
        {
            get
            {
                return _isEmpty;
            }
        }

        [SerializeField]
        private ItemResource _resource;

        [SerializeField]
        private AbilityPersistence _ability;

        [SerializeField]
        private int _quantity = 1;

        public int Quantity
        {
            set
            {
                _quantity = value;
                OnQuantityChangedHandler?.Invoke(value);
            }

            get
            {
                return _quantity;
            }
        }

        public OnIntEvent OnQuantityChangedHandler;

        public AbilityPersistence Ability
        {
            get
            {
                return _ability;
            }
        }

        public Sprite Icon => _ability.Icon;

        public string Description => _ability.Description;

        public string Name => _ability.Name;

        public float CooldownTime => _ability.CooldownTime;

        public float Cooldown => _ability.Cooldown;

        public float SimultaneousTargetsCapacity => _ability.SimultaneousTargetsCapacity;

        public float StartLag => _ability.StartLag;

        public float EndLag => _ability.EndLag;

        public float MinRange => _ability.MinRange;

        public float MaxRange => _ability.MaxRange;

        public OnEvent OnCooldownedHandler { get => _ability.OnCooldownedHandler; set => _ability.OnCooldownedHandler = value; }
        public OnEvent OnAbilityFinishedHandler { get => _ability.OnAbilityFinishedHandler; set => _ability.OnAbilityFinishedHandler = value; }
        public OnEvent OnEndLagFinishedHandler { get => _ability.OnEndLagFinishedHandler; set => _ability.OnEndLagFinishedHandler = value; }

        public ItemPersistence(ItemResource resource)
        {
            _isEmpty = false;
            _resource = resource;
            _quantity = resource.Quantity;
            _ability = new AbilityPersistence(resource._ability);
        }

        public bool TryUseAgainst(Character source, BaseObject target)
        {
            return _ability.TryUseAgainst(source, target);
        }

        public bool TryUse(Character source)
        {
            if(_ability.TryUse(source))
            {
                Quantity--;

                return true;
            }

            return false;
        }
    }

    [CreateAssetMenu(menuName = "Cirrus/Objects/Items/Item")]
    public class ItemResource : ScriptableObject
    {
        public AbilityResource _ability;

        [SerializeField] // TODO
        private bool _isConsumable;

        [SerializeField]        
        public int Quantity = 1;        

        public void OnValidate()
        {
            Quantity = Mathf.Clamp(Quantity, 1, 99);
        }

        public virtual ItemPersistence Create()
        {
            return new ItemPersistence(this);
        }
    }
}