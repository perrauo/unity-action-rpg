using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cirrus.Extensions;

namespace Cirrus.ARPG.UI
{

    public class HotBarSlot : Slot
    {

        [SerializeField]
        private Canvas _canvas;

        private bool _isChosen = false;

        [SerializeField]
        protected float _chooseScale = 1.4f;

        public Text NumberText;

        private bool _init = false;

        public void OnEnable()
        {
            if (_init)
                return;

            _init = false;

            //_index = transform.GetSiblingIndex();
        }

        public override bool Store(InventoryObject obj)
        {
            obj.Reference.gameObject.SetActive(true);
            base.Store(obj.Reference);
            return true;
        }


        public virtual void Choose()
        {
            HotBarSlot slot = Instantiate(gameObject, transform.position, Quaternion.identity, transform).GetComponent<HotBarSlot>();

            slot._object.Remove();
            slot.Store(_object.Reference);  
            
            slot.GetComponent<RectTransform>().FitParent();
            slot.transform.SetParent(canvas.transform);
            slot.transform.SetAsLastSibling();
            slot._isChosen = true;

            if (_object != null)
            {
                slot.Color = _object.Color.SetA(1);
                slot._object.Choose(true);
            }
            else
            {
                slot.Color = _defaultColor.SetA(1);
            }

            slot._targetScale = new Vector3(_chooseScale, _chooseScale, _chooseScale);
            
        }

        public virtual void Unchoose()
        {
            Destroy(gameObject);
        }


        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            if (eventData.clickCount == 1)
            {
                if (!_isChosen)
                {
                    Choose();
                }
                else
                {
                    Unchoose();
                }
            }

        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (_isChosen)
                return;

            base.OnPointerExit(eventData);
        }

        //public override void OnPointerEnter(PointerEventData eventData)
        //{
        //    if (_isChosen)
        //        return;

        //    base.OnPointerExit(eventData);
        //}

    }
}