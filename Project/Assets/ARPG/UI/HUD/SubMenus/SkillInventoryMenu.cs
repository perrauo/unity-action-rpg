using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Characters;
using System.Collections.Generic;

using System.Linq;

namespace Cirrus.ARPG.UI
{
    public class SkillInventoryMenu : SubMenu
    {
        [SerializeField]
        private Context _context;

        private SkillSlot _currentSlot;

        private Vector2Int _cursorPosition;

        [SerializeField]
        private SkillObject _basicObjectTemplate;// _basicSlotsParent;

        [SerializeField]
        private SkillObject _activeObjectTemplate;// _basicSlotsParent;

        [SerializeField]
        private SkillObject _passiveObjectTemplate;// _basicSlotsParent;

        [SerializeField]
        private Transform _basicSlotsParent;

        [SerializeField]
        private SkillSlot _basicSlotTemplate;
        
        private SkillSlot[] _basicSlots;

        [SerializeField]
        private Transform _activeSlotsParent;

        [SerializeField]
        private SkillSlot _activeSlotTemplate;
                
        private SkillSlot[] _activeSlots;

        [SerializeField]
        private Transform _passiveSlotsParent;

        [SerializeField]
        private SkillSlot _passiveSlotTemplate;
        
        private SkillSlot[] _passiveSlots;

        private List<SkillSlot> _slots;

        [SerializeField]
        private Summary _summary;

        private World.Objects.Characters.Actions.SkillInventoryPersistence _inventory;

        public void OnValidate()
        {
            if (_summary == null)
            {
                _summary = GetComponentInChildren<Summary>();
            }

            if (_context == null)
            {
                _context = FindObjectOfType<Context>();
            }
        }

        private bool _init = false;

        public void OnEnable()
        {
            if (_init)
                return;

            _init = true;

        }

        public void Clear()
        {
            var old = GetComponentsInChildren<SkillSlot>();

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
            base.Open();

            if (_inventory == _context.Character.CharacterPersistence.Skills)
                return;

            _inventory = _context.Character.CharacterPersistence.Skills;

            Clear();

            _slots = new List<SkillSlot>();

            int index = 0;

            #region Basic Slots

            _basicSlots = new SkillSlot[_inventory.Basics.Count];
            for (int i = 0; i < _inventory.Basics.Count; i++) // in _inventory.Items)
            {
                _basicSlots[i] = _basicSlotTemplate.Create(_basicSlotsParent, index);//, vslot);

                _basicSlots[i].OnObjectBeginDragHandler += _context.OnObjectBeginDrag;
                _basicSlots[i].OnObjectBeginDragHandler += OnObjectBeginDrag;

                _basicSlots[i].OnObjectEndDragHandler += OnObjectEndDrag;
                _basicSlots[i].OnObjectEndDragHandler += _context.OnInventoryObjectDragEnd;

                _basicSlots[i].OnInventoryObjectDroppedHandler += OnObjectDropped;

                _basicSlots[i].OnPointerEnterHandler += OnSlotPointerEnter;
                _basicSlots[i].OnPointerExitHandler += OnSlotPointerExit;


                var obj = _basicObjectTemplate.Create(_basicSlots[i], _inventory.Basics[i], _inventory);
                _basicSlots[i].Store(obj);

                _slots.Add(_basicSlots[i]);

                index++;
            }

            #endregion

            #region Active Slots

            _activeSlots = new SkillSlot[_inventory.Actives.Count];
            for (int i = 0; i < _inventory.Actives.Count; i++) // in _inventory.Items)
            {
                _activeSlots[i] = _activeSlotTemplate.Create(_activeSlotsParent, index);//, vslot);

                _activeSlots[i].OnObjectBeginDragHandler += _context.OnObjectBeginDrag;
                _activeSlots[i].OnObjectBeginDragHandler += OnObjectBeginDrag;

                _activeSlots[i].OnObjectEndDragHandler += OnObjectEndDrag;
                _activeSlots[i].OnObjectEndDragHandler += _context.OnInventoryObjectDragEnd;

                _activeSlots[i].OnInventoryObjectDroppedHandler += OnObjectDropped;

                _activeSlots[i].OnPointerEnterHandler += OnSlotPointerEnter;
                _activeSlots[i].OnPointerExitHandler += OnSlotPointerExit;

                var obj = _activeObjectTemplate.Create(_activeSlots[i], _inventory.Actives[i], _inventory);
                _activeSlots[i].Store(obj);
                _slots.Add(_activeSlots[i]);

                index++;
            }

            #endregion

            #region Passive Slots

            _passiveSlots = new SkillSlot[_inventory.Passives.Count];
            for (int i = 0; i < _inventory.Passives.Count; i++) // in _inventory.Items)
            {
                _passiveSlots[i] = _passiveSlotTemplate.Create(_passiveSlotsParent, index);//, vslot);
                _passiveSlots[i].OnPointerEnterHandler += OnSlotPointerEnter;
                _passiveSlots[i].OnPointerExitHandler += OnSlotPointerExit;

                var obj = _passiveObjectTemplate.Create(_passiveSlots[i], _inventory.Passives[i], _inventory);
                _passiveSlots[i].Store(obj);

                index++;
            }

            #endregion

            //_height = _slots.Length / _width;

            if (_currentSlot == null)
                SelectSlot(0);
        }

        public void OnObjectBeginDrag(Slot slot, InventoryObject obj)
        {
            //_context.DraggedObject.gameObject.SetActive(false);
        }


        public void OnObjectEndDrag(Slot slot)
        {
            //_context.DraggedObject.gameObject.SetActive(true);
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
            if (slot.Object != null)
            {
                _summary.Object = slot.Object;
            }

            if (_currentSlot != null)
            {
                _currentSlot.Unselect();
            }

            //_cursorPosition.x = slot._index.Mod(_width);
            //_cursorPosition.y = slot._index / _width;
            _currentSlot = (SkillSlot)slot;

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



    }
}
