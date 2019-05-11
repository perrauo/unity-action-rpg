using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


//TODO get Cost out of here


// TODO: Actors are not objects necessarily
// e.g Used to determined knockback direction based on Object Position


namespace Cirrus.ARPG.Objects.Characters.Actions
{
    public class AbilityUser : MonoBehaviour
    {
        [SerializeField]
        public BaseObject _source;

        [SerializeField]
        private List<Ability> _abilities;

        [HideInInspector]
        public bool IsLagging = false;

        private float _lagTime = 0;

        private float _lagLimit = 0;

        protected virtual void Awake()
        {

        }

        public void Update()
        {
            if (IsLagging)
            {
                _lagTime += UnityEngine.Time.deltaTime;
                if (_lagTime >= _lagLimit)
                {
                    _lagLimit = 0;
                    _lagTime = 0;
                    IsLagging = false;
                }
            }
        }

        public void StartLag(float lagLimit)
        {
            IsLagging = true;
            _lagTime = 0;
            _lagLimit = lagLimit;
        }


        public Ability GetEquippedAction(int idx)
        {
            return _abilities[idx];
        }

        public int EquippedActionCount
        {
            get
            {
                return _abilities.Count;
            }
        }

        public virtual bool TryUse(Ability action, BaseObject target)
        {
            if (IsLagging)
                return false;

            if (action.TryUseAgainst(target))
            {
                StartLag(action.EndLag);
                return true;
            }

            return false;
        }

        public virtual bool TryUse(Ability action)
        {
            if (IsLagging)
                return false;

           if(action.TryUse())
           {
                StartLag(action.EndLag);
                return true;
                // Play attack animation here
           }

            return false;
                
        }
    }
}