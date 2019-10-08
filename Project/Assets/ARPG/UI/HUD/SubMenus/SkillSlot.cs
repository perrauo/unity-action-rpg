using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Cirrus.ARPG.UI
{
    public class SkillSlot : Slot
    {
        public Text NumberText;

        [SerializeField]
        private bool _isPassive = false;

        private bool _init = false;

        public int Index
        {
            get
            {
                return _index;
            }

        }

        public void OnEnable()
        {
            if (_init)
                return;

            _init = false;
        }

        public SkillSlot Create(Transform parent, int index)
        {
            _index = index;
            SkillSlot slot = Instantiate(this, parent).GetComponent<SkillSlot>();
            return slot;
        }

        public override void OnObjectMoved(InventoryObject obj)
        {
            //_object.OnMovedHandler -= OnObjectMoved;
            //_object = null;
        }


        public override void OnDrag(PointerEventData eventData)
        {
            if (!_isPassive)
            {
                base.OnDrag(eventData);
            }
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            if (!_isPassive)
            {
                base.OnBeginDrag(eventData);
            }
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            if (!_isPassive)
            {
                base.OnEndDrag(eventData);
            }
        }

        public override void OnDrop(PointerEventData eventData)
        {
            if (!_isPassive)
            {
                base.OnDrop(eventData);
            }
        }
    }
}
