using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cirrus.ARPG.World.Objects.Characters.Actions;
using Cirrus.ARPG.UI;
using Cirrus.ARPG.Items;
using Cirrus.ARPG.World;
using Cirrus.ARPG.World.Objects;
using Cirrus.ARPG.World.Objects.Characters;

//using Cirrus.ARPG.World.Objects.Characters.Items;

namespace Cirrus.ARPG.Items
{
    public class InventoryUser : MonoBehaviour
    {
        [SerializeField]
        private ItemInventoryPersistence _persistence;

        [SerializeField]
        private bool _isEnabled = false;

        [SerializeField]
        private List<SceneSkill> _items;

        [SerializeField]
        private GameObject _itemsParent;

        [SerializeField]
        private ItemInventoryMenu _inventory;

        [SerializeField]
        private HotBar _hotBar;

        [SerializeField]
        public int _itemSlotCount = 40;

        [SerializeField]
        public int _keySlotCount = 20;

        [SerializeField]
        public int _abilitySlotCount = 20;

        [SerializeField]
        public int _specialSlotCount = 20;

        [SerializeField]
        public int _hotBarSlotCount = 10;


        private List<VirtualSlot> _slots;

        private List<VirtualSlot> _hotBarSlots;
        
        
        // TODO : cache where we last placed to accelarate finding a new place
        // TODO : Concurrent access??
        private bool FirstFit(World.Objects.Characters.Actions.SceneSkill ability, out VirtualSlot slot)
        {
            foreach (var s in _slots)
            {
                if (s.IsEmpty)
                {
                    slot = s;
                    return true;
                }
            }

            slot = null;
            return false;
        }

        private bool BestFit(World.Objects.Characters.Actions.SceneSkill ability, out VirtualSlot slot)
        {
            foreach (var s in _slots)
            {
                if (s.IsEmpty && s.Preference == ability.Type)
                {
                    slot = s;
                    return true;
                }
            }

            slot = null;
            return false;
        }


        public bool TryStore(SceneSkill ability)
        {
            if (!_isEnabled) // TODO NPC
                return false;

            // TODO: why are we putting hearts in our inventory?
            if (ability == null)
                return false;

            VirtualSlot slot;

            if (BestFit(ability, out slot))
            {
                slot.Store(ability);
                return true;
            }
            else if (FirstFit(ability, out slot))
            {
                slot.Store(ability);
                return true;
            }

            return false;
        }


        public void CreateVirtualSlots()
        {
            _slots = new List<VirtualSlot>();
            _hotBarSlots = new List<VirtualSlot>();
            
            for (int i = 0; i < _itemSlotCount; i++)
            {
                _slots.Add(new VirtualSlot(AbilityType.Item));
            }

            for (int i = 0; i < _abilitySlotCount; i++)
            {
                _slots.Add(new VirtualSlot(AbilityType.Simple));
            }

            for (int i = 0; i < _keySlotCount; i++)
            {
                _slots.Add(new VirtualSlot(AbilityType.Key));
            }

            for (int i = 0; i < _specialSlotCount; i++)
            {
                _slots.Add(new VirtualSlot(AbilityType.Special));
            }

            for (int i = 0; i < _hotBarSlotCount; i++)
            {
                _hotBarSlots.Add(new VirtualSlot(AbilityType.Unknown));
            }
        }


        public void PopulateVirtualSlots()
        {
            int count = 0;
            List<SceneSkill> missed = new List<SceneSkill>();
            foreach(var ab in _items)
            {
                if (BestFit(ab, out VirtualSlot slot))
                {
                    slot.Store(ab);

                    if (count < _hotBarSlotCount)
                    {
                        _hotBarSlots[count].Store(ab);
                    }

                    count++;

                }
                else {
                    missed.Add(ab);
                }
            }

            foreach (var ab in missed)
            {
                if (FirstFit(ab, out VirtualSlot slot))
                {
                    slot.Store(ab);

                    if (count < _hotBarSlotCount)
                    {
                        _hotBarSlots[count].Store(ab);
                    }

                    count++;
                }
                else
                {
                    missed.Add(ab);
                }
            }
        }
        
        //// On character switch
        //public void PopulateHotbarSlots()
        //{
        //    foreach (var vslot in _hotBarSlots)
        //    {
        //        //var slot = _hotBar.AddSlot(vslot);
        //        if (slot != null)
        //        {
        //            if (!vslot.IsEmpty)
        //            {
        //                _inventory.AddItem(slot, vslot.Ability);

        //            }
        //        }
        //    }
        //}

        public void Start()
        {
            if (gameObject == null)
                return;

            // TODO: Handle NPC inventory
            if (!_isEnabled)
                return;

            ResolveDependencies();
        
            CreateVirtualSlots();

            PopulateVirtualSlots();

            //PopulateHotbarSlots();

            _hotBar.OnAbilitySelectedHandler += OnAbilitySelected;

            //_hotBar.SetNumbers();

            _hotBar.Select(1);
        }

        public void Open()
        {
           // PopulateInventorySlots();
        }


        public OnSceneSkillEvent OnAbilitySelectedHandler;
        // TODO remove and controller here directly
        public void OnAbilitySelected(SceneSkill ability)
        {
            OnAbilitySelectedHandler?.Invoke(ability);
        }

   
        /////////////////////////
        ///

        private void ResolveDependencies()
        {
            if (_itemsParent == null)
            {
                _itemsParent = _items[0].transform.parent.gameObject;
            }

            if (_inventory == null)
                _inventory = FindObjectOfType<ItemInventoryMenu>();

            if (_hotBar == null)
                _hotBar = FindObjectOfType<HotBar>();

        }

        public void OnValidate()
        {
            if (_itemsParent == null)
                return;

            ResolveDependencies();

            _items.Clear();

            foreach (var item in _itemsParent.GetComponentsInChildren<SceneSkill>())
            {
                _items.Add(item);
            }
        }

    }
}
