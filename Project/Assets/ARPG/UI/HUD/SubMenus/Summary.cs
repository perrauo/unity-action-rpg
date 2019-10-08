using Cirrus.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.ARPG.UI
{

    public class Summary : MonoBehaviour
    {
        [SerializeField]
        private Color _defaultColor = Color.white.SetA(0.5f);

        [SerializeField]
        private UnityEngine.UI.Image _background;

        [SerializeField]
        private UnityEngine.UI.Image _icon;

        [SerializeField]
        private UnityEngine.UI.Text _name;

        [SerializeField]
        private UnityEngine.UI.Text _text;

        public InventoryObject Object
        {
            set
            {
                _name.text = value.Name;
                _background.color = value.Color;
                _icon.sprite = value.Icon;
                _text.text = value.Description;
            }
        }



    }

}