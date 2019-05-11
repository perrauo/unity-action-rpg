using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Cirrus.UI
{
    public class Counter : MonoBehaviour
    {
        public delegate void OnFloatUpdated(float newValue);

        public delegate void OnIntUpdated(int newValue);

        [SerializeField]
        private string _message = "";


        [SerializeField]
        private Text _text;

        public void Awake()
        {
            if (!_text.text.Equals(""))
            {
                _message = _text.text;
            }

            _text.text = _message + $"{0}";         
        }

        public void UpdateValue(int newValue)
        {
            _text.text = _message + $"{newValue}";
        }


        public void UpdateValue(float newValue)
        {
            _text.text = _message + $"{newValue}";
        }
    }
}
