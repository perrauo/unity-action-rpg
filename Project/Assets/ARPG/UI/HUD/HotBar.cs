using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
//using Cirrus.ARPG.World.Objects.Actions;
//using Cirrus.ARPG.World.Objects.Actors;
//using Cirrus.ARPG.World.Objects.Actions.Characters;

namespace Cirrus.ARPG.UI
{
    public class HotBar : MonoBehaviour
    {
        [SerializeField]
        private Context _context;

        [SerializeField]
        private float _currentSlotScale = 1.2f;

        [SerializeField]
        private float _currentSlotScaleTime = 1;

        private HotBarSlot _currentSlot;

        private int _currentSlotIndex = 0;


        public World.Objects.Characters.Actions.SceneSkill CurrentAbility
        {
            get {

                return null;//return _slots[_currentSlotIndex].Item.Ability;
            }
        }

        [SerializeField]
        private HotBarSlot[] _slots;

        public World.Objects.Characters.Actions.OnSceneSkillEvent OnAbilitySelectedHandler;

        public void OnValidate()
        {
            if (_context == null)
                _context = FindObjectOfType<Context>();

            if (_slots.Length == 0)
                _slots = GetComponentsInChildren<HotBarSlot>();

            for (int i = 0; i < _slots.Length; i++) ///HotBarSlot sl in _slots)
            {
                _slots[i].NumberText.text = i.ToString();
            }
        }

        private bool _init = false;

        public void OnEnable()
        {
            if (_init)
                return;

            _init = true;

            for(int i = 0; i < _slots.Length; i++)// HotBarSlot slot in _slots)
            {
                _slots[i]._index = i;
                _slots[i].OnPointerEnterHandler += OnPointerEnter;
                _slots[i].OnPointerExitHandler += OnPointerExit;
                _slots[i].OnInventoryObjectDroppedHandler += OnInventoryObjectDropped;
            }
        }

        public void OnPointerEnter(Slot slot)
        {
            SelectSlot(slot);
        }

        public void OnPointerExit(Slot slot)
        {
            slot.Unselect();
        }

        public void SelectSlot(Slot slot)
        {
            if (_currentSlot != null && _currentSlot != slot)
            {
                _currentSlot.Unselect();
            }

            _currentSlot = (HotBarSlot) slot; // TODO add dedicated event
            _currentSlotIndex = _currentSlot.Index;

            _currentSlot.Select();

            //Select(_currentSlotIndex);
        }


        public void Cycle(int i)
        {
            iTween.ScaleTo(_slots[_currentSlotIndex].gameObject, Vector3.one, _currentSlotScaleTime);
            _currentSlotIndex = Utils.Math.Wrap(_currentSlotIndex + i, 0, _slots.Length);
            _currentSlotIndex = _currentSlotIndex % _slots.Length;
            iTween.ScaleTo(_slots[_currentSlotIndex].gameObject, Vector3.one * _currentSlotScale, _currentSlotScaleTime);

            //OnAbilitySelectedHandler?.Invoke(_slots[_currentSlotIndex].Item.Ability);
        }

        public void Select(int i)
        {
            //iTween.ScaleTo(_slots[_currentSlotIndex].gameObject, Vector3.one, _currentSlotScaleTime);
            //_currentSlotIndex = i - 1;
            //_currentSlotIndex = _currentSlotIndex % _slots.Length;
            //iTween.ScaleTo(_slots[_currentSlotIndex].gameObject, Vector3.one * _currentSlotScale, _currentSlotScaleTime);

            ////OnAbilitySelectedHandler?.Invoke(_slots[_currentSlotIndex].Item.Ability);
        }



        public void OnInventoryObjectDropped(Slot slot)
        {
            if (_context.DraggedObject == null)
                return;

            if (slot.IsEmpty)
            {
                // TODO create a reference

                slot.Store(_context.DraggedObject);

                //_inventory.Clear(_context.DraggedObjectSource._index);
                //_inventory.Store(slot._index, _context.DraggedObject._item);

                //SelectSlot(slot);
            }
        }

        public void Store(int i, ItemObject item)
        {
            if (i == 8)
            {
                Debug.Log("Key 8, 9 not working");
                return;
            }

            if (i <= _slots.Length)
            {
                _slots[i - 1].Store(item);
            }
        }

        public World.Objects.Characters.Actions.SceneSkill GetItem(int i)
        {
            if (i <= _slots.Length)
            {
                //if (_slots[i - 1].Item != null)
                //{

                //    // TODO: remove cast
                //    return _slots[i - 1].Item.Ability;// as Characters.Actions.Ability;
                //}
            }

            return null;
        }
    }
}