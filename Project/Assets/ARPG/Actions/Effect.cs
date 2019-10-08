using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.Conditions;
using System.Linq;
using Cirrus.ARPG.World.Objects;
using Cirrus.ARPG.World.Objects.Characters;

namespace Cirrus.ARPG.Actions
{
    public interface IEffect
    {
        IEnumerable<ICondition> GlobalConditions { get; }

        IEnumerable<ICondition> SourceConditions { get; }

        IEnumerable<ICondition> TargetConditions { get; }

        bool TryApply(World.Objects.Actions.ActionProduct action);

        bool TryApply(World.Objects.Actions.ActionProduct action, BaseObject target);

        bool TryApply(World.Objects.Actions.ActionProduct action, Character target);

        bool TryApply(BaseObject source, World.Objects.Actions.ActionProduct action, BaseObject target);

        bool TryApply(Character source, World.Objects.Actions.ActionProduct action, BaseObject target);

        bool TryApply(Character source, World.Objects.Actions.ActionProduct action, Character target);

        bool TryApply(BaseObject source, World.Objects.Actions.ActionProduct action, Character target);
    }
    
}

