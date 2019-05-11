using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.ARPG
{
    public class Persistence : MonoBehaviour
    {
        Dictionary<int, Objects.Characters.Persistence> _dict;
        public Dictionary<int, Objects.Characters.Persistence> Characters
        {
            get
            {
                if(_dict == null)
                _dict = new Dictionary<int, Objects.Characters.Persistence>();
                return _dict;
            }
        }

         public void Add(Objects.Characters.Persistence persistence) {
            persistence.transform.SetParent(this.transform);
            Characters.Add(persistence.Tag.GetInstanceID(), persistence);
        }

        public bool TryGetCharacter(Tags.Tag tag, out Objects.Characters.Persistence persistences)
        {
            if (Characters.TryGetValue(tag.GetInstanceID(), out persistences))
            {
                return true;
            }

            else return false;
        }

    }
}
