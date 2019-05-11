using Cirrus.ARPG.Objects;
using Cirrus.ARPG.Objects.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.ARPG.Conditions
{
    public abstract class BaseCondition : ScriptableObject
    {
        public virtual bool Verify()
        {
            return false;
        }

        public virtual bool Verify(BaseObject source)
        {
            return Verify();
        }

        public virtual bool Verify(BaseObject source, BaseObject target)
        {
            return Verify();
        }

        public virtual bool Verify(BaseObject source, Character target)
        {
            return Verify(source, target as BaseObject);
        }


        public virtual bool Verify(Character subj)
        {
            return Verify((BaseObject)subj);
        }


        public virtual bool Verify(Character source, Character target)
        {
            return Verify(source as BaseObject, target);
        }

        public virtual bool Verify(Character source, BaseObject target)
        {
            return Verify(source as BaseObject, target);
        }



        // Attach no listener
        // TODO: Non object listener
        //public virtual void AttachListener(Objects.Conditions.ObjectListener listener, ITarget target)
        //{

        //}

        public virtual IState GetListenedState(BaseObject target)
        {
            return null;
        }


        // Attach no listener
        public virtual IState GetListenedState(Character target)
        {
            return null;
        }
    }
}