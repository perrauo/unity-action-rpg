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
        private bool _isFloat = false;

        [ConditionalHide("_isFloat", isVisible = true)]
        [SerializeField]
        private float _float;

        [ConditionalHide("_isFloat", isVisible = true)]
        [SerializeField]
        private ConversionType _conversion;

        [ConditionalHide("_isFloat", isVisible = false)]
        [SerializeField]
        private int _int;

        public float Value
        {
            get
            {
                return  (_isFloat ? _float : _int);
            }
        }

        public int Integer
        {
            get
            {
                if (!_isFloat)
                    return _int;

                switch (_conversion)
                {
                    case ConversionType.Ceil:
                        return Mathf.CeilToInt(_float);


                    case ConversionType.Floor:
                        return Mathf.FloorToInt(_float);


                    case ConversionType.Round:
                        return Mathf.RoundToInt(_float);

                    default:
                        return 0;
                }
            }
        }

    }

    [System.Serializable]
    public class FloatNumber : INumber
    {
        [SerializeField]
        private float _float;

        public float Value
        {
            get { return _float; }
        }

        [ConditionalHide("_isFloatVisible", isVisible = true)]
        [SerializeField]
        private ConversionType _intConversion;

        public int Integer
        {
            get
            {
                switch (_intConversion)
                {
                    case ConversionType.Ceil:
                        return Mathf.CeilToInt(_float);


                    case ConversionType.Floor:
                        return Mathf.FloorToInt(_float);


                    case ConversionType.Round:
                        return Mathf.RoundToInt(_float);

                    default:
                        return 0;
                }
            }
        }
    }


    [System.Serializable]
    public class Number : INumber
    {
        [SerializeField]
        private bool _isRange = true;

        [SerializeField]
        private bool _isFloat = false;


        [SerializeField]
        [HideInInspector]
        private bool _isRangeIntVisible = false;

        [SerializeField]
        [HideInInspector]
        private bool _isRangeFloatVisible = true;


        [SerializeField]
        [ConditionalHide("_isRangeFloatVisible", isVisible = true)]
        private RangeFloat _rangeFloat;

        [SerializeField]
        [ConditionalHide("_isRangeIntVisible", isVisible = true)]
        private RangeInt _rangeInt;

        private INumber Range {
            get {

                if (_isFloat)
                    return _rangeFloat;
                else
                    return _rangeInt;
            }
        }

        [SerializeField]
        [HideInInspector]
        private bool _isFloatVisible = false;

        [SerializeField]
        [HideInInspector]
        private bool _isIntVisible = true;

        [ConditionalHide("_isFloatVisible", isVisible = true)]
        [SerializeField]
        private FloatNumber _float;

        [ConditionalHide("_isIntVisible", isVisible = true)]
        [SerializeField]
        private int _int;

        public float Value
        {
            get
            {
                return _isRange? Range.Value  : (_isFloat ? _float.Value : _int);
            }
        }


        public void OnValidate()
        {
            if (_isRange)
            {
                _isFloatVisible = false;
                _isIntVisible = false;
                _isRangeFloatVisible = _isFloat;
                _isRangeIntVisible = !_isFloat;
            }
            else if (_isFloat)
            {
                _isRangeFloatVisible = false;
                _isRangeIntVisible = false;

                _isFloatVisible = true;
                _isIntVisible = false;
            }
            else
            {
                _isRangeFloatVisible = false;
                _isRangeIntVisible = false;

                _isFloatVisible = false;
                _isIntVisible = true;
            }
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
                return _resouce as INumber;
            }
        } 

        [ConditionalHide("_isResource", isVisible = false)]
        [SerializeField]
        private Number _value;
      
        public float Value
        {
            get
            {
                return _isResource ? Resource.Value : _value.Value;
            }
        }

        public void OnValidate()
        {
            if(_value != null)
            _value.OnValidate();
        }
    }


}
