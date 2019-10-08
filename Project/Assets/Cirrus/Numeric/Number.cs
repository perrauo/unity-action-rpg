using UnityEngine;
using System.Collections;
using Cirrus.Editor;


namespace Cirrus.Numeric
{
    public interface INumber
    {
        float Value { get; }
    }

    public enum ConversionType
    {
        Ceil,
        Floor,
        Round
    }

    [System.Serializable]
    public class SimpleNumber : INumber
    {


        [SerializeField]
        private float _float;


        public float Value
        {
            get
            {
                return _float;
            }
        }

        public int Integer
        {
            get
            {
                return (int)_float;
            }
        }

    }

    [System.Serializable]
    public class Number : INumber
    {
        [SerializeField]
        private bool _isRange = true;


        [SerializeField]
        [ConditionalHide("_isRange", isVisible = true)]
        private RangeFloat _rangeFloat;


        private INumber Range {
            get {
                return _rangeFloat;
            }
        }

        [SerializeField]
        [HideInInspector]
        private bool _isFloatVisible = false;

        [SerializeField]
        [HideInInspector]
        private bool _isIntVisible = true;

        [SerializeField]
        [ConditionalHide("_isRange", isVisible = false)]
        private float _float;


        public float Value
        {
            get
            {
                return _isRange? Range.Value  :  _float;
            }
        }

        public void OnValidate()
        {

        }
    }


    [System.Serializable]
    public class FlexibleNumber : INumber
    {
        [SerializeField]
        private bool _isResource;

        [SerializeField]
        [ConditionalHide("_isResource", isVisible = true)]
        private Object _resouce;

        private INumber Resource {
            get {
                if (_resouce == null)
                    return null;

                return _resouce as INumber;
            }
        } 

        [ConditionalHide("_isResource", isVisible = false)]
        [SerializeField]
        private Number _value;
      

        private float ResourceValue
        {
            get {
                if (Resource == null)
                    return 0;
                else
                    return Resource.Value;
            }
        }


        public float Value
        {
            get
            {
                return _isResource ? ResourceValue  : _value.Value;
            }
        }

        public void OnValidate()
        {
            //if(_value != null)
            //_value.OnValidate();
        }
    }


}
