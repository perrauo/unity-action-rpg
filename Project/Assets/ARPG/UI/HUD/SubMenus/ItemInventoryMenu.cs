using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using System.Threading;
using Cirrus.Extensions;
using System;

namespace Cirrus.ARPG.UI
{
    // TODO: Reinstate Sections (Tab menu, Hotbar etc..), we need it to handle divergin dimensions

    public class ItemInventoryMenu : SubMenu
    {
        private ARPG.Items.ItemInventoryPersistence _inventory;

        [SerializeField]
        private Context _context;

        [SerializeField]
        private int _width = 8;

        private int _height = 8;

        private ItemSlot _swapAnchorSlot;

        private ItemSlot _currentSlot;

        private Vector2Int _cursorPosition;

        [SerializeField]
        public bool IsEnabled = false;

        [SerializeField]
        private HotBar _hotBar;

        //[SerializeField]
        private ItemSlot[] _slots;

        [SerializeField]
        private ItemSlot _slotTemplate;

        [SerializeField]
        private ItemObject _objectTemplate;

        [SerializeField]
        private Transform _slotsParent;

        private Mutex _mutex;

        [SerializeField]
        private Summary _summary;

        //private World.Objects.Characters.Character _character;

        private void OnValidate()
        {
            if (_context == null)
                _context = FindObjectOfType<Context>();

            if (_summary != null)
            {
                _summary = GetComponentInChildren<Summary>();
            }
        }

        private bool _init = false;

        public void OnEnable()
        {
            if (_init)
                return;

            _init = true;

            _mutex = new Mutex();

        }

        public override void HandleAction(int idx)
        {
            Map(idx);
        }

        private void OnObjectUsed(Slot slot, InventoryObject obj)
        {
            obj.TryUse(_context.Character); // If empty remove object
        }
        
        public void OnObjectBeginDrag(Slot slot, InventoryObject obj)
        {
            if (_context.DraggedObject == null)
                return;

            _context.DraggedObject.gameObject.SetActive(false);
        }


        public void OnObjectEndDrag(Slot slot)
        {
            if (_context.DraggedObject == null)
                return;

            _context.DraggedObject.gameObject.SetActive(true);
        }

        public void OnSlotPointerEnter(Slot slot)
        {
            SelectSlot(slot);      
        }

        public void OnSlotPointerExit(Slot slot)
        {
            slot.Unselect();// (slot);
        }

        public void SelectSlot(Slot slot)
        {
            if (_currentSlot != null)
            {
                _currentSlot.Unselect();
            }

            if (_currentSlot.Object != null)
            {
                _summary.Object = _currentSlot.Object;
            }

            _cursorPosition.x = slot._index.Mod(_width);
            _cursorPosition.y = slot._index / _width;
            _currentSlot = (ItemSlot)slot;

            _currentSlot.Select();
        }


        public void SelectSlot(int idx)
        {
            if (_currentSlot != null)
            {
                _currentSlot.Unselect();
            }

            _currentSlot = _slots[idx];
            _currentSlot.Select();
        }

        public void OnObjectDropped(Slot slot)
        {
            if (_context.DraggedObject == null)
                return;

            if (slot.IsEmpty)
            {
                _context.DraggedObject.Move(slot);
            }
        }

        private void PlaceSwapAnchor()
        {
            //_swapAnchor = Instantiate(_swapAnchorTemplate, _currentSlot.transform).GetComponent<Cursor>();
            //_swapAnchor.transform.localPosition = Vector3.zero;
            _swapAnchorSlot = _currentSlot;
        }

        private void CancelSwap()
        {
            //Destroy(_swapAnchor.gameObject);
            //_swapAnchor = null;
            _swapAnchorSlot = null;
            _swapAnchorSlot = null;
        }

        private void DoSwap()
        {
            _currentSlot.TrySwap(_swapAnchorSlot);    
            CancelSwap();            
        }

        public void Map(int i)
        {          
            //if (_currentSlot.Item != null)
            //{
            //    _hotBar.Store(i, _currentSlot.Item);
            //}
        }

        public void Swap()
        {
            if (_swapAnchorSlot == null)
            {
                PlaceSwapAnchor();
            }
            else
            {
                DoSwap();
            }
        }

        public void Clear()
        {
            var old = GetComponentsInChildren<Slot>();

            foreach (Slot slot in old)
            {
                if (slot != null)
                {
                    Destroy(slot.gameObject);
                }
            }
        }
        
        public override void Open()
        {            
            if (_inventory == _context.Character.CharacterPersistence.Items)
                return;

            _inventory = _context.Character.CharacterPersistence.Items;

            Clear();

            _slots = new ItemSlot[_inventory.Items.Length];
            for (int i = 0; i < _inventory.Items.Length; i++) // in _inventory.Items)
            {
                _slots[i] = _slotTemplate.Create(_slotsParent, i);//, vslot);

                _slots[i].OnObjectBeginDragHandler += _context.OnObjectBeginDrag;
                _slots[i].OnObjectBeginDragHandler += OnObjectBeginDrag;


                _slots[i].OnObjectEndDragHandler += OnObjectEndDrag;
                _slots[i].OnObjectEndDragHandler += _context.OnInventoryObjectDragEnd;

                _slots[i].OnObjectUsed += OnObjectUsed;

                _slots[i].OnInventoryObjectDroppedHandler += OnObjectDropped;

                _slots[i].OnPointerEnterHandler += OnSlotPointerEnter;
                _slots[i].OnPointerExitHandler += OnSlotPointerExit;
                

                if (_inventory.Items[i] != null && !_inventory.Items[i].IsEmpty)
                {
                    var obj = _objectTemplate.Create(_slots[i], _inventory.Items[i], _inventory);
                    _slots[i].Store(obj);
                }
            }

            _height = _slots.Length / _width;

            if (_currentSlot == null)
            {
                SelectSlot(0);
            }

        }



        public override void Close()
        {
            //_display.gameObject.SetActive(false);
            IsEnabled = false;
           
        }

        // TODO add slots for larget inventory

        public override void Move(Vector2Int movement)
        {
            _mutex.WaitOne();

            movement.y *= -1;
            _cursorPosition += movement;

            //calculate the according index i in 1D space

            int i = _cursorPosition.x + _width * _cursorPosition.y;

            i = Utils.Math.Wrap(i, 0, _slots.Length);

            i = Mathf.Clamp(i, 0, _slots.Length);

            SelectSlot(i);

            _mutex.ReleaseMutex();
        }
                             
    }
}
