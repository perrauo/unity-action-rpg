using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Objects.Items
{
    public class VirtualSlot
    {
        public IInventoryItem Item;

        protected InventoryUser _user;

        // TODO: Handle for users without physical inventory
        protected Slot _physicalSlot;

        public bool IsEmpty
        {
            get
            {
                return Item == null;
            }
        }


        public virtual void SetUser(InventoryUser user)
        {
            _user = user;
        }

        public virtual void IncrementFreeCount()
        {
            
        }

        public virtual void DecrementFreeCount()
        {

        }


        public VirtualSlot(Slot slot)
        {
            _physicalSlot = slot;
        }

        // NPC
        public VirtualSlot()
        {
            _physicalSlot = null;
        }

        public bool TrySwap(VirtualSlot otherSlot)
        {
            if (IsEmpty && Accept(otherSlot.Item))
            {
                Store(otherSlot.Item);
                otherSlot.Clear();
                return true;
            }
            else if (otherSlot.IsEmpty && otherSlot.Accept(Item))
            {
                otherSlot.Store(Item);
                Clear();
                return true;
            }
            else if (Accept(otherSlot.Item) && otherSlot.Accept(Item))
            {
                IInventoryItem tmp = Item;
                Store(otherSlot.Item);
                otherSlot.Store(tmp);
                return true;
            }

            return false;
        }

        public virtual void BindPhysicalSlot()
        {
            if (_physicalSlot)
            {
                _physicalSlot.Bind(this);
            }
        }

        public virtual void UpdatePhysicalSlot()
        {
            if (_physicalSlot != null)
            {
                _physicalSlot.DoUpdate();
            }
        }

        public virtual void Store(IInventoryItem item)
        {
            BindPhysicalSlot();
            DecrementFreeCount();
            Item = item;
        }

        public virtual void Clear()
        {
            _physicalSlot.Free();
            IncrementFreeCount();
            Item = null;
        }

        public virtual bool Accept(IInventoryItem item)
        {
            return false;
        }
    }

    public abstract class Slot : MonoBehaviour
    {
        [SerializeField]
        protected Icon _icon;

        protected VirtualSlot _vSlot;

        public IInventoryItem Item
        {
            get
            {
                return _vSlot.Item;
            }
        }
 
        public virtual VirtualSlot CreateVirtualSlot()
        {
            return new VirtualSlot(this);
        }

        public void Bind(VirtualSlot virtualSlot)
        {
            _vSlot = virtualSlot;
        }


        public void DoUpdate()
        {
            if (Item != null)
            {
                _icon.SetSprite(Item.Icon);
            }
        }

        public void Store(IInventoryItem item)
        {
            _vSlot.Store(item);
        }

        public void Free()
        {
            _icon.ClearSprite();
        }

        public bool TrySwap(Slot otherSlot)
        {
            return _vSlot.TrySwap(otherSlot._vSlot);
        }


    }
}