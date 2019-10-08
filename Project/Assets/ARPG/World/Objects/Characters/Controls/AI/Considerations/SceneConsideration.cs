using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Actions;

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    public abstract class SceneConsideration : MonoBehaviour, IConsideration
    {
        public abstract bool Evaluate(Character source, BaseObject target, out float utility);

        public abstract bool Evaluate(Character source, out float utility);

        //public abstract bool Evaluate(Character character, Character target, out float utility);

        public abstract Objects.Conditions.ObjectListener CreateListener(Character source, BaseObject target);

    }
}