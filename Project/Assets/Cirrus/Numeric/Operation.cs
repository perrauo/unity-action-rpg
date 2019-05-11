using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cirrus.Numeric
{
    public abstract class Operation : ScriptableObject
    {
        public float Evaluate(float current)
        {
            return Evaluate(current, current);
        }

        public abstract float Evaluate(float current, float total);
    }
}
