using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Cirrus.ARPG.Objects.Actions;
//using Cirrus.ARPG.Objects.Actors;
//using Cirrus.ARPG.Objects.Actions.Characters;

namespace Cirrus.ARPG.Objects.Items
{
    public class HotBar : MonoBehaviour
    {
        [SerializeField]
        private HotBarSlot[] _slots;

        [SerializeField]
        private float _currentSlotScale = 1.2f;

        [SerializeField]
        private float _currentSlotScaleTime = 1;

        private int _currentSlotIndex = 0;

        public void RegisterActor(Characters.Actions.AbilityUser act)
        {
            //for(int i = 0; i < act.EquippedActionCount; i++)
            //{
            //    _icons[i].SetAction(act.GetEquippedAction(i));
            //}
        }

        public void Cycle(int i)
        {
            iTween.ScaleTo(_slots[_currentSlotIndex].gameObject, Vector3.one, _currentSlotScaleTime);
            _currentSlotIndex = Cirrus.Utils.Mathf.Wrap(_currentSlotIndex + i, 0, _slots.Length);
            _currentSlotIndex = _currentSlotIndex % _slots.Length;
            iTween.ScaleTo(_slots[_currentSlotIndex].gameObject, Vector3.one * _currentSlotScale, _currentSlotScaleTime);
        }

        public void Store(int i, IInventoryItem item)
        {
            if (i == 8)
            {
                Debug.Log("Key 8, 9 not working");
                return;
            }

            if (i <= _slots.Length)
            {
                _slots[i-1].Store(item);
                _slots[i - 1].DoUpdate();
            }
        }

        public Characters.Actions.Ability GetItem(int i)
        {
            if (i <= _slots.Length)
            {
                if (_slots[i - 1].Item != null)
                {

                    // TODO: remove cast
                    return _slots[i - 1].Item as Characters.Actions.Ability;
                }
            }

            return null;
            }


        public IEnumerable<VirtualSlot> CreateVirtualSlots(InventoryUser user)
        {
            List<VirtualSlot> slots = new List<VirtualSlot>();
            foreach (var s in _slots)
            {
                if (s == null) continue;

                var vSlot = s.CreateVirtualSlot();
                vSlot.SetUser(user);

                if (vSlot == null) continue;

                slots.Add(vSlot);
            }

            return slots;
        }

        public void OnValidate()
        {
            int count = 1;
            foreach (var slot in _slots)
            {
                slot.NumberText.text = count.ToString();
                count++;
                count = count % 10; 
            }
        }
    }
}