using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI
{
    public enum AttitudeType
    {
        Hostility,
        Anxiety,
        Affection,
        Curiosity
    }
    
    [System.Serializable]
    public class Attitude
    {
        [SerializeField]
        public float BaseValue;
    }

    public class AttitudeProduct
    {
        public float BaseValue = -1;

        private AttitudeType _type;
        private Attitude _motivation;
        private Dictionary<int, float> _values;

        public AttitudeProduct(Attitude res, AttitudeType Id)
        {
            this._type = Id;
            this._motivation = res;
            _values = new Dictionary<int, float>();
            BaseValue = res.BaseValue;
        }

        public float GetTowards(BaseObject target)
        {
            float val;
            if (!_values.TryGetValue(target.gameObject.GetInstanceID(), out val))
                val = 0;

            return _motivation.BaseValue + val;
        }

        public void SetTowards(BaseObject target, float val)
        {
            int id = target.GetInstanceID();
            if (_values.ContainsKey(id))
            {
                _values[target.GetInstanceID()] = val;
            }
            else
            {
                _values.Add(target.GetInstanceID(), val);
            }
        }

        public void UpdateTowards(BaseObject target, float amount)
        {
            int id = target.GetInstanceID();
            if (_values.ContainsKey(id))
            {
                _values[target.GetInstanceID()] += amount;
            }
            else
            {
                _values.Add(target.GetInstanceID(), amount);
            }
        }

    }



 }