using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Cirrus.ARPG.UI
{
    public delegate void OnInventoryObjectEvent(InventoryObject obj);

    public abstract class InventoryObject : MonoBehaviour
    {
        protected Actions.IActiveAbility _ability;

        [SerializeField]
        private Color _color;

        public Color Color
        {
            get
            {
                return _color;
            }
        }


        [SerializeField]
        protected float _alpha = .4f;

        [SerializeField]
        protected Image _background;

        [SerializeField]
        protected Image _icon;

        protected Slot _slot;

        [SerializeField]
        private Image _cooldown;

        public OnFloatEvent OnCooldownValueChangedHandler;// (float value)

        public OnInventoryObjectEvent OnMovedHandler;

        public OnInventoryObjectEvent OnUsedHandler;

        public float Cooldown
        {
            set
            {
                _cooldown.fillAmount = value;
                OnCooldownValueChangedHandler?.Invoke(value);
            }
        }

        [SerializeField]
        protected Image _glow;

        protected bool _isEnabled = true;

        [SerializeField]
        public bool IsStatic = false;

        [SerializeField]
        protected float _pulseScaleAmount = 2f;

        protected Vector3 _pulseScaleAmountVector;

        [SerializeField]
        protected float _pulseScaleTime = 1.2f;

        [SerializeField]
        protected float _selectScale = 1.1f;

        [SerializeField]
        protected float _chooseScale = 1.3f;

        [SerializeField]
        protected float _scaleTime = 0.4f;

        protected Vector3 _targetScale = new Vector3(1, 1, 1);

        public abstract Sprite Icon { get; }

        public abstract string Name { get; }

        public abstract string Description { get;  }


        public virtual void FixedUpdate()
        {
            _icon.rectTransform.localScale = Vector3.Lerp(_icon.rectTransform.localScale, _targetScale, _scaleTime);

            if(_ability != null)
                Cooldown = _ability.Cooldown;
        }

        public void OnCooldownChanged(float value)
        {
            Cooldown = value;
        }

        // TODO reference the same persistence item instread of referencing a InventoryObject
        #region Reference

        public abstract InventoryObject Reference { get; }

        public abstract InventoryObject Source { get; }

        protected bool _isReference = false;

        public virtual void PopulateReferenceCallbacks()
        {
            Reference._isReference = true;
            Source.OnCooldownValueChangedHandler += OnCooldownChanged;
        }

        public virtual void ClearReferenceCallbacks()
        {
            Source.OnCooldownValueChangedHandler -= OnCooldownChanged;
        }

        #endregion

        public virtual void Move(Slot slot)
        {
            OnMovedHandler?.Invoke(this);
            _slot = slot;
            slot.Store(this);
        }


        public virtual void Remove()
        {
            if (_isReference)
            {
                ClearReferenceCallbacks();
            }
        }


        public void OnUsed(World.Objects.Characters.Actions.SceneSkill ability)
        {
            iTween.PunchScale(_icon.gameObject, _pulseScaleAmountVector, _pulseScaleTime);
        }

        public void Select(bool select = true)
        {
            if (select)
            {
                _targetScale = new Vector3(_selectScale, _selectScale, _selectScale);
            }
            else
            {
                _targetScale = new Vector3(1, 1, 1);
            }
        }

        public void Choose(bool choose = true)
        {
            if (choose)
            {
                _targetScale = new Vector3(_chooseScale, _chooseScale, _chooseScale);
            }
            else
            {
                _targetScale = new Vector3(1, 1, 1);
            }
        }

        public void Disable()
        {
            _isEnabled = false;
            Utils.Color.SetA(ref _icon, _alpha);
        }

        public void Enable()
        {
            _isEnabled = true;
            Utils.Color.SetA(ref _icon, 1);
        }



        public virtual bool TryUse(World.Objects.Characters.Character source)
        {           

            return true;
        }

    }
}