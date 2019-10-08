using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using Cirrus.Extensions;

namespace Cirrus.ARPG.UI
{
    public delegate void OnSlotEvent(Slot slot);

    public delegate void OnSlotObjectEvent(Slot slot, InventoryObject obj);

    public class Slot : MonoBehaviour, 
        IBeginDragHandler, 
        IDragHandler, 
        IEndDragHandler, 
        IDropHandler, 
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerClickHandler
    {
        public InventoryObject _object;

        public InventoryObject Object
        {
            get
            {
                return _object;
            }
        }


        [SerializeField]
        private DragPreview _dragPreviewTemplate;

        private DragPreview _dragPreview;

        [SerializeField]
        private UnityEngine.UI.Image _background;

        [SerializeField]
        private float _selectScale = 1.2f;

        private float _scaleTime = 0.4f;

        protected Vector3 _targetScale;

        [SerializeField]
        protected Color _defaultColor = Color.white.SetA(0.5f);

        private Color _color = Color.white;
               
        public Color Color
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
                _background.color = _color;
            }
        }


        [SerializeField]
        public Color _selectedColor;

        public OnSlotObjectEvent OnObjectBeginDragHandler;

        public OnSlotObjectEvent OnObjectUsed;

        public OnSlotEvent OnObjectEndDragHandler;

        public OnSlotEvent OnInventoryObjectDroppedHandler;// (Slot slot);

        public OnSlotEvent OnPointerEnterHandler;// (Slot slot);

        public OnSlotEvent OnPointerExitHandler;// (Slot slot);


        public int _index = 0;
        
        public int Index
        {
            get
            {
                return _index;
            }
        }

        public bool IsEmpty
        {
            get {
                return _object == null;//sEmpty;
            }
        }

        protected RectTransform canvas;

        public void Awake()
        {
            canvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            _targetScale = _background.rectTransform.localScale;
        }

        public void FixedUpdate()
        {
            _background.rectTransform.localScale = Vector3.Lerp(_background.rectTransform.localScale, _targetScale, _scaleTime);
        }

        public virtual bool Store(InventoryObject obj)
        {
            Color = obj.Color;
            _object = obj;
            _object.OnMovedHandler += OnObjectMoved;
            _object.transform.SetParent(transform);
            _object.transform.localPosition = Vector3.zero;
            _object.transform.localScale = new Vector3(1, 1, 1);
            return true;            
        }

        public virtual void OnObjectMoved(InventoryObject obj)
        {
            Color = _defaultColor;
            _object.OnMovedHandler -= OnObjectMoved;
            _object = null;
        }

        public bool TrySwap(Slot otherSlot)
        {
            if (IsEmpty && !otherSlot.IsEmpty)
            {
                Store(otherSlot._object);
                return true;
            }
            else if (otherSlot.IsEmpty && !IsEmpty)
            {
                otherSlot.Store(_object);
                return true;
            }
            else if (!otherSlot.IsEmpty && !otherSlot.IsEmpty)
            {
                InventoryObject tmp = _object;
                Store(otherSlot._object);
                otherSlot.Store(tmp);
                return true;
            }

            return false;
        }

        public void Select()
        {
            Color = _selectedColor;
            if (_object != null)
                _object.Select(true);

            _targetScale = new Vector3(_selectScale, _selectScale, _selectScale);
        }

        public void Unselect()
        {
            Color = _defaultColor;
            if (_object != null)
                _object.Select(false);

            _targetScale = new Vector3(1, 1, 1);
        }


        #region Mouse Interaction

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            if (canvas == null)
                return;

            if (_object != null)
            {
                _dragPreview = _dragPreviewTemplate.Create(transform, _object);// transform.position);
                _dragPreview.transform.SetAsLastSibling();

                OnObjectBeginDragHandler?.Invoke(this, _object);

                OnDrag(eventData);
            }
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            if (_dragPreview != null)
            {
                var rt = _dragPreview.GetComponent<RectTransform>();
                rt.position = eventData.position;
            }
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            if (_dragPreview != null)
            {
                 Destroy(_dragPreview.gameObject);
                _dragPreview = null;
            }

            OnObjectEndDragHandler?.Invoke(this);
        }

        public virtual void OnDrop(PointerEventData eventData)
        {
            OnInventoryObjectDroppedHandler?.Invoke(this);
        }        

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerEnterHandler?.Invoke(this);
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            OnPointerExitHandler?.Invoke(this);
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.clickCount == 2)
            {
                if (_object != null)
                {
                    OnObjectUsed?.Invoke(this, _object);
                }
            }
        }



        #endregion

    }
}