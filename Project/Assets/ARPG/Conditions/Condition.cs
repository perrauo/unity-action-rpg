using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects;

namespace Cirrus.ARPG.Conditions
{

    public delegate void OnStateChanged(IConditionedState state, params object[] args);

    public interface IConditionedState
    {
        OnStateChanged OnStateChangedHandler { get; set; }
    }

    public interface ICondition
    {
        bool Verify();
        
        bool Verify(BaseObject source);

        bool Verify(BaseObject source, BaseObject target);


        bool Verify(BaseObject source, World.Objects.Characters.Character target);


        bool Verify(World.Objects.Characters.Character subj);



        bool Verify(World.Objects.Characters.Character source, World.Objects.Characters.Character target);


        bool Verify(World.Objects.Characters.Character source, BaseObject target);


        IConditionedState GetListenedState(BaseObject target);

        // Attach no listener
        IConditionedState GetListenedState(World.Objects.Characters.Character target);
    
    }
}
