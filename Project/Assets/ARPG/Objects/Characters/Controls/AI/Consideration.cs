using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Actions;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI
{
    public abstract class Consideration : ScriptableObject
    {
        public abstract bool Evaluate(ref float utility, Character  character, BaseObject target);

        public abstract bool Evaluate(ref float utility, Character character, Character target);

        public abstract Objects.Conditions.ObjectListener CreateListener(Character source, BaseObject target);

    }
}