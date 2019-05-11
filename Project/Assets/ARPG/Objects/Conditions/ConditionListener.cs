using Cirrus.ARPG.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cirrus.ARPG.Conditions;

namespace Cirrus.ARPG.Objects.Conditions
{
    public class ConditionListener : ObjectListener
    {
        private BaseCondition _condition;
        private BaseObject _object; // Object requesting the condition, not the condition target
        private Characters.Character _character; // Object requesting the condition, not the condition target
        private bool _isSatisfied = false;


        public ConditionListener(BaseObject source, BaseObject target, BaseCondition condition) : base (target)
        {
            _object = source;
            _condition = condition;
            IState state = condition.GetListenedState(target);
            state.OnStateChangedHandler += ObjectOnConditionStateUpdated;
        }

        public ConditionListener(Characters.Character source, BaseObject target, BaseCondition condition) : base(target)
        {
            _character = source;
            _condition = condition;
            IState state = condition.GetListenedState(target);
            state.OnStateChangedHandler += ObjectOnConditionStateUpdated;
        }

        public void ObjectOnConditionStateUpdated(IState state, params object[] args)
        {
            bool prev = _isSatisfied;
            _isSatisfied = _object.Verify(_condition);

            if (prev != _isSatisfied)
            {
                OnObjectListenedHandler?.Invoke(_target, this);
            }
        }

        public void CharacterOnConditionStateUpdatedFromSource(IState state, params object[] args)
        {
            bool prev = _isSatisfied;
            _isSatisfied = _character.Verify(_condition);
 
            if (prev != _isSatisfied)
            {
                OnObjectListenedHandler?.Invoke(_target, this);
            }
        }

    }

}