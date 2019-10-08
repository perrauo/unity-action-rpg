using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
//using ARPG/*.*/Objects;
using Cirrus.ARPG.World.Objects;

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    public class Sensor : MonoBehaviour
    {
        HashSet<BaseObject> _targets = new HashSet<BaseObject>();

        public HashSet<BaseObject> Targets
        {
            get
            {
                /* Remove any MovementAIRigidbodies that have been destroyed */
                _targets.RemoveWhere(IsNull);
                return _targets;
            }
        }

        static bool IsNull(BaseObject r)
        {
            return (r == null || r.Equals(null));
        }

        void TryToAdd(Component other)
        {
            BaseObject rb = other.GetComponentInParent<BaseObject>();
            if (rb != null)
            {
                _targets.Add(rb);
            }
        }

        void TryToRemove(Component other)
        {
            BaseObject rb = other.GetComponentInParent<BaseObject>();
            if (rb != null)
            {
                _targets.Remove(rb);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            TryToAdd(other);
        }

        void OnTriggerExit(Collider other)
        {
            TryToRemove(other);
        }
    } 
}
