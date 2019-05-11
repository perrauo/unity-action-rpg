using UnityEngine;
using System.Collections;


namespace Cirrus.ARPG.Objects.Conditions.Relations
{
    public abstract class Relation : ScriptableObject
    {
        public virtual bool Check(BaseObject first, BaseObject second)
        {
            return false;
        }

        public virtual bool Check(Characters.Character first, BaseObject second)
        {
            return Check((BaseObject)first, second);
        }
    }
}