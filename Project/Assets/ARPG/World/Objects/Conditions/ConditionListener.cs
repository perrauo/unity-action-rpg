using Cirrus.ARPG.World.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cirrus.ARPG.Conditions;

namespace Cirrus.ARPG.World.Objects.Conditions
{
    public class ConditionListener : ObjectListener
    {
        private ICondition _condition;
        private BaseObject _object; // Object requesting the condition, not the condition target
        private Characters.Character _character; // Object requesting the condition, not the condition target
        private bool _isSatisfied = false;
        private IConditionedState _state;

        public ConditionListener(BaseObject source, BaseObject target, ICondition condition) : base (target)
        {
            _object = source;
            _condition = condition;
            _state = condition.GetListenedState(target);

            if (_state != null)
            {
                _state.OnStateChangedHandler += ObjectOnConditionStateUpdated;
            }
        }

        public void ObjectOnConditionStateUpdated(IConditionedState state, params object[] args)
        {
            bool prev = _isSatisfied;
            _isSatisfied = _object.Verify(_condition);

            if (prev != _isSatisfied)
            {
                OnObjectListenedHandler?.Invoke(_target, this);
            }
        }

    }

}