using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.World.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Cirrus.ARPG.UI
{
    public delegate void OnItemInventoryObjectEvent(ItemObject obj);

    public class ItemObject : InventoryObject
    {
        [System.NonSerialized]
        public Items.ItemPersistence _item;

        [System.NonSerialized]
        public Items.ItemInventoryPersistence _inventory;

        public override Sprite Icon => _item.Icon;

        public override string Description => _item.Description;

        public override string Name => _item.Name;

        [SerializeField]
        private Text _quantity;

        public OnIntEvent OnQuantityChangedHandler;

        public int Quantity
        {
            set
            {
                _quantity.text = value.ToString();
                OnQuantityChangedHandler?.Invoke(value);
            }
        }

        public virtual ItemObject Create(Slot slot, Items.ItemPersistence item, Items.ItemInventoryPersistence inventory)
        {
            var obj = Instantiate(this, slot.transform).GetComponent<ItemObject>();
            obj.transform.localPosition = Vector3.zero;

            obj._slot = slot;
            obj._item = item;
            obj._ability = item;
            obj._inventory = inventory;
            
            obj._icon.sprite = item.Icon;
            obj.Quantity = item.Quantity;

            obj.Cooldown = 0;
            obj._item.OnCooldownedHandler += obj.OnCooldowned;
            obj._item.OnQuantityChangedHandler += obj.OnQuantityChanged;

            obj._pulseScaleAmountVector = new Vector3(_pulseScaleAmount, _pulseScaleAmount);
            return obj;
        }

        public override void Move(Slot slot)
        {
            _inventory.Clear(_slot.Index);//, _item);

            base.Move(slot);
                        
            _inventory.Store(slot.Index, _item);
        }

        #region Reference

        private ItemObject _source;

        public override InventoryObject Source
        {
            get
            {
                return _source;
            }
        }


        public override void PopulateReferenceCallbacks()
        {
            base.PopulateReferenceCallbacks();
            _source.OnQuantityChangedHandler += OnQuantityChanged;
        }


        public override void ClearReferenceCallbacks()
        {
            base.ClearReferenceCallbacks();
            _source.OnQuantityChangedHandler -= OnQuantityChanged ;
        }

        private ItemObject _reference;

        public override InventoryObject Reference
        {
            get
            {
                if (_reference == null)
                {
                    _reference = Instantiate(gameObject, transform.parent).GetComponent<ItemObject>();
                    _source = this;
                    PopulateReferenceCallbacks();               
                }

                return _reference;
            }
        }

        #endregion

        public void OnCooldowned()
        {
            // play ready anim;
        }

        public void OnQuantityChanged(int quant)
        {
            Quantity = quant;
        }

        public override void Remove()
        {
            base.Remove();

            if (!_reference)
            {
                _inventory.Clear(_slot.Index);
            }

            OnMovedHandler?.Invoke(this);
            Destroy(gameObject);
        }

        public override bool TryUse(World.Objects.Characters.Character source)
        {
            if (_item.TryUse(source))
            {
                if (_item.Quantity == 0)
                {
                    Remove();
                }

                return true;
            }

            return false;
        }

    }

}
