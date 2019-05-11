using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.Objects;
using Cirrus.ARPG.Objects.Characters;
using Cirrus.ARPG.Conditions;

namespace Cirrus.ARPG.Actions
{
    public abstract class BaseEffect : ScriptableObject
    {
        //////////////////////////////////////////////
        //////////////////////////////////////////////

        [System.Serializable]
        public enum Conditions
        {
            Global = 1 << 0,
            Source = 1 << 1,
            Target = 1 << 2
        }

        [Editor.EnumFlag]
        [SerializeField]
        protected Conditions _conditionFlags = 0x00;


        //////////////////////////////////////////////
        //////////////////////////////////////////////


        [SerializeField]
        [Editor.ConditionalHide("_conditionFlags", (int)Conditions.Global, isVisible = true, isEnumFlags =true)]
        protected BaseCondition _globalCondition;

        [SerializeField]
        [Editor.ConditionalHide("_conditionFlags", (int)Conditions.Source, isVisible = true, isEnumFlags =true)]
        protected BaseCondition _sourceCondition;

        [SerializeField]
        [Editor.ConditionalHide("_conditionFlags", enumValue: (int) Conditions.Target, isVisible = true, isEnumFlags =true)]
        protected BaseCondition _targetCondition;



        private bool Check(BaseCondition condition, BaseObject target)
        {
            if (_conditionFlags == 0)
                return true;

            return target.Verify(condition);
        }

        private bool Check(BaseCondition condition, Character target)
        {
            if (_conditionFlags == 0)
                return true;

            return target.Verify(condition);
        }

        //////////////////////////////////////////////



        //// 

        public bool TryApply()
        {
            if (_globalCondition.Verify())
            {
                DoApply();
                return true;
            }

            return false;
        }

        protected virtual void DoApply()
        {

        }


        ////

                   
        public bool TryApply(BaseObject target)
        {
            if (Check(_targetCondition, target))
            {
                DoApply(target);
                return true;
            }

            return false;
        }


        protected virtual void DoApply(BaseObject target)
        {
            DoApply();
        }


        ////

        public bool TryApply(Character target)
        {
            if (Check(_targetCondition, target))
            {
                DoApply(target);
                return true;
            }

            return false;
        }

        protected virtual void DoApply(Character target)
        {
            DoApply(target as BaseObject);
        }

        ////


        public virtual bool TryApply(BaseObject source, BaseObject target)
        {
            if (Check(_sourceCondition, source) && Check(_targetCondition, target))
            {
                DoApply(source, target);
                return true;

            }

            return false;
        }

        protected virtual void DoApply(BaseObject source, BaseObject target)
        {
             DoApply(target as BaseObject);
        }

        ////

        public virtual bool TryApply(Character source, BaseObject target)
        {
            if (Check(_sourceCondition, source) && Check(_targetCondition, target))
            {
                DoApply(source as BaseObject, target);
                return true;
            }

            return false;
        }

        protected virtual void DoApply(Character source, BaseObject target)
        {
            DoApply(source as BaseObject, target);
        }


        ////


        public virtual bool TryApply(Character source, Character target)
        {
            if (Check(_sourceCondition, source) & Check(_targetCondition, target))
            {
                DoApply(source, target);
                return true;
            }

            return false;
        }

        protected virtual void DoApply(Character source, Character target)
        {
            DoApply(source as BaseObject, target);
        }

        ////


        public virtual bool TryApply(BaseObject source, Character target)
        {
            if (Check(_sourceCondition, source) & Check(_targetCondition, target))
            {
                DoApply(source, target);
                return true;
            }

            return false;
        }

        protected virtual void DoApply(BaseObject source, Character target)
        {
            DoApply(source, target as BaseObject);
        }




    }
}
