using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.UI
{
    public delegate void OnSkillObjectEvent(ItemObject obj);


    public class SkillObject : InventoryObject
    {
        [System.NonSerialized]//.ReadOnly]
        public World.Objects.Characters.Actions.SkillPersistence _skill;

        [System.NonSerialized]
        public World.Objects.Characters.Actions.SkillInventoryPersistence _inventory;

        public override Sprite Icon => _skill.Icon;

        public override string Description => _skill.Description;

        public override string Name => _skill.Name;

        public virtual SkillObject Create(
            Slot slot, 
            World.Objects.Characters.Actions.SkillPersistence skill,
            World.Objects.Characters.Actions.SkillInventoryPersistence inventory)//.Objects.Characters.Actions.Ability ability)
        {
            var obj = Instantiate(this, slot.transform).GetComponent<SkillObject>();
            obj.transform.localPosition = Vector3.zero;
            obj._skill = skill;
            obj._icon.sprite = skill.Icon;
            obj._inventory = inventory;
            obj._slot = slot;

            obj._pulseScaleAmountVector = new Vector3(_pulseScaleAmount, _pulseScaleAmount);
            return obj;
        }



        #region Reference

        private SkillObject _source;

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
            //_source.OnQuantityChangedHandler += OnQuantityChanged;
        }


        public override void ClearReferenceCallbacks()
        {
            base.ClearReferenceCallbacks();
            //_source.OnQuantityChangedHandler -= OnQuantityChanged;
        }

        private SkillObject _reference;

        public override InventoryObject Reference
        {
            get
            {
                if (_reference == null)
                {
                    _reference = Instantiate(gameObject, transform.parent).GetComponent<SkillObject>();
                    _source = this;
                    PopulateReferenceCallbacks();
                }

                return _reference;
            }
        }

        #endregion
    }
}
