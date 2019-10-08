using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using System;


//TODO get Cost out of here


// TODO: Actors are not objects necessarily
// e.g Used to determined knockback direction based on Object Position


namespace Cirrus.ARPG.World.Objects.Characters.Actions
{
    public class AbilityUser : MonoBehaviour
    {
        [SerializeField]
        public Character _source;

        [HideInInspector]
        public bool IsLagging = false;

        private float _lagTime = 0;

        private float _lagLimit = 0;


        public bool IsFocused { get; private set; }

        private int _currentFocusIndex;


        private List<BaseObject> _targets;

        [SerializeField]
        private float _focusRange = 10;

        private List<BaseObject> _focusTargets;

        private SceneSkill _currentAbility;


        protected virtual void Awake()
        {
            _focusTargets = new List<BaseObject>();
            _targets = new List<BaseObject>();

            //_source.CharacterPersistence.
        }


        public void OnAbilityEndLagFinished()
        {
            IsLagging = false;
        }


        public virtual bool TryUseAgainst(SceneSkill ability, BaseObject target)
        {
            if (IsLagging)
                return false;

            if (ability.TryUseAgainst(target))
            {
                IsLagging = true;
                ability.OnEndLagFinishedHandler += OnAbilityEndLagFinished;
                return true;
            }

            return false;
        }


        public virtual bool TryUse(SceneSkill ability)
        {
            if (IsLagging)
                return false;

            if (_focusTargets.Count != 0)
            {
                return TryUseAgainst(ability, _focusTargets[0]);               
            }
            else
            {
                if (ability.TryUse())
                {
                    IsLagging = true;
                    ability.OnEndLagFinishedHandler += OnAbilityEndLagFinished;
                    return true;

                }
            }

            return false;          
        }




        public void Select(SceneSkill ability)
        {
            _currentAbility = ability;
        }

        public void PopulateFocusTargets()
        {
            if (_focusTargets == null)
                _focusTargets = new List<BaseObject>();

            _focusTargets.Clear();

            if (_targets.Count != 0)
            {
                int count = 0;
                for (int i = _currentFocusIndex; i < _currentFocusIndex + _targets.Count; i++)
                {
                    int j = i % _targets.Count;

                    if (count >= _currentAbility.SimultaneousCapacity)
                    {
                        break;
                    }

                    count++;
                    _focusTargets.Add(_targets[j]);
                    
                }
            }
            
        }

        public void DoCycle()
        {
            if (_focusTargets != null)
            {
                foreach (var f in _focusTargets)
                {
                    f.ObjectUI.EnableCrossHair(false);
                }

                _currentFocusIndex++;
                _currentFocusIndex = Cirrus.Utils.Math.Wrap(_currentFocusIndex, 0, _focusTargets.Count+1);
            }
            else
            {
                _currentFocusIndex = 0;
            }

            PopulateFocusTargets();

            foreach (var f in _focusTargets)
            {
                f.ObjectUI.EnableCrossHair(true);
            }
            
        }

        public void Cycle(ref List<BaseObject> focusTargets)
        {
            _targets = CaptureNearbyTargets(_focusRange);

            DoCycle();

            focusTargets.AddRange(_focusTargets);    
        }

        public void Cycle(Vector3 pos, ref List<BaseObject> focusTargets)
        {
            _targets = CaptureNearbyTargets(_focusRange);

            DoCycle();

            focusTargets.AddRange(_focusTargets);
        }



        public void Unfocus()
        {
            foreach (var f in _focusTargets)
            {
                f.ObjectUI.EnableCrossHair(false);
            }

            _focusTargets.Clear();
        }


        private List<BaseObject> CaptureNearbyTargets(float range)
        {
            // TODO: for now we use closest, other options maybe?
            Collider[] colliders = Physics.OverlapSphere(_source.Transform.position, range);
            var lis = new List<BaseObject>();

            foreach (Collider collider in colliders)
            {
                var tg = collider.GetComponentInParent<BaseObject>();

                if (tg == null)
                    continue;

                // TODO Target self somettimes useful
                if (tg.gameObject == _source.gameObject)
                    continue;

                lis.Add(tg);

            }

            return lis;

        }


        //private List<BaseObject> CaptureNearbyTargets(Vector3 pos, float range)
        //{
        //    // TODO: for now we use closest, other options maybe?
        //    Collider[] colliders = Physics.OverlapSphere(_source.transform.position, range);
        //    var lis = new List<BaseObject>();

        //    foreach (Collider collider in colliders)
        //    {
        //        var tg = collider.GetComponent<BaseObject>();

        //        if (tg == null)
        //            continue;

        //        // TODO Target self somettimes useful
        //        if (tg.gameObject == _source.gameObject)
        //            continue;

        //        lis.Add(tg);

        //    }

        //    return lis;

        //}


    }
}