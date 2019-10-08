using UnityEngine;
using System.Collections;
using Cirrus.ARPG.World.Objects.Characters;
using Cirrus.ARPG.World.Objects;


// TODO Slime parent and some children attacked
// The parent becomes angry and the children run away

public interface IConsideration
{
    bool Evaluate(Character source, BaseObject target, out float utility);

    bool Evaluate(Character source, out float utility);

    Cirrus.ARPG.World.Objects.Conditions.ObjectListener CreateListener(Character source, BaseObject target);
}
