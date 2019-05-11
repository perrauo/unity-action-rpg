using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cirrus.ARPG.Objects.Characters.Actions;
//using Cirrus.ARPG.Objects.Characters.Items;

namespace Cirrus.ARPG.Objects.Items
{
    public class InventoryUser : MonoBehaviour
    {
        [SerializeField]
        private InventoryPersistence _persistence;

        [SerializeField]
        private bool _isEnabled = false;

        [SerializeField]
        private List<Ability> _items;

        [SerializeField]
        private GameObject _itemsParent;

        public IEnumerable<IInventoryItem> Items
        {
            get
            {
                return _items;
            }
        }

        [SerializeField]
        private Inventory _inventory;

        [SerializeField]
        private HotBar _hotBar;

        public int FreeItemSlot = 0;

        public int FreeKeySlot = 0;

        public int FreeAbilitySlot = 0;

        public int FreeSpecialSlot = 0;

        private IEnumerable<VirtualSlot> _slots;

        private IEnumerable<VirtualSlot> _hotBarSlots;

        private bool FirstFit(IInventoryItem item, out VirtualSlot slot)
        {
            foreach (var s in _slots)
            {
                if (s.IsEmpty && s.Accept(item))
                {
                    slot = s;
                    return true;
                }
            }

            slot = null;
            return false;
        }

        // TODO
        // Populate Sprite
        // Bind unbind on character switch
        public void BindPhysicalSlots()
        {
            // TODO: null check
            foreach (var vSlot in _slots)
            {
                vSlot.BindPhysicalSlot();
            }

            // TODO: null check
            foreach (var vSlot in _hotBarSlots)
            {
                vSlot.BindPhysicalSlot();
            }
        }

        public void ClearPhysicalSlots()
        {
            foreach (var vSlot in _slots)
            {
                // TODO
                //vSlot.Slot.Bind(vSlot);
                //vSlot.Slot.Store(vSlot.Item);
            }
        }

        public void DoStore(Ability ability)
        {
            if (FirstFit(ability, out VirtualSlot slot))
            {
                Instantiate(ability, _itemsParent.transform);
                slot.Store(ability);
                slot.UpdatePhysicalSlot();
            }
        }

        // TODO: REWORK
        public bool TryStore(Ability ability)
        {
            if (ability is SimpleAbility)
            {
                if (FreeAbilitySlot > 0)
                {
                    DoStore(ability);
                    return true;
                }
            }
            else if (ability is SpecialAbility)
            {
                if (FreeSpecialSlot > 0)
                {
                    DoStore(ability);
                    return true;
                }
            }
            else if (ability is Item || ability is Equipment)
            {
                if (FreeItemSlot > 0)
                {
                    DoStore(ability);
                    return true;
                }
            }
            else if (ability is Key)
            {
                if (FreeKeySlot > 0)
                {
                    DoStore(ability);
                    return true;
                }
            }

            return false;
        }

        private void ResolveDependencies()
        {
            if (_itemsParent == null)
            {
                _itemsParent = _items[0].transform.parent.gameObject;
            }

            if (_inventory == null)
                _inventory = FindObjectOfType<Items.Inventory>();

            if (_hotBar == null)
                _hotBar = FindObjectOfType<Items.HotBar>();

        }


        public void OnValidate()
        {
            ResolveDependencies();
        }


        public void Start()
        {
            if (gameObject == null)
                return;

            // TODO: Handle NPC inventory
            if (!_isEnabled)
                return;

            ResolveDependencies();

            _slots = _inventory.CreateVirtualSlots(this);
            _hotBarSlots = _hotBar.CreateVirtualSlots(this);

            // TODO: Only do for current char
            //: TODO on context switch (char) only
            BindPhysicalSlots();

            // Add starting items
            int i = 1;
            foreach (var a in Items)
            {
                if (FirstFit(a, out VirtualSlot slot))
                {
                    slot.Store(a);

                    // DEFAULT TOOLBAR ITEMS
                    if (i <= 10 && i != 9)
                    {
                        _hotBar.Store(i, a);
                        i++;
                    }
                }
                else
                {
                    Debug.LogWarning("Item named " + a.ToString() + " does not fit.");
                }
            }

        }

    }
}
