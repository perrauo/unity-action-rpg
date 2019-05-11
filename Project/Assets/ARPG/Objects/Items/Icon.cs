using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cirrus.ARPG.Objects.Items
{
    public class Icon : MonoBehaviour
    {
        [SerializeField]
        protected float _alpha = .4f;

        [SerializeField]
        protected Image _background;

        public void SetSprite(Sprite sprite)
        {
            _icon.sprite = sprite;
            _icon.gameObject.SetActive(true);
        }

        public void ClearSprite()
        {
            _icon.gameObject.SetActive(false);
        }


        [SerializeField]
        protected Image _icon;


        [SerializeField]
        protected Image _glow;


        protected bool _isEnabled = true;


        [SerializeField]
        public bool IsStatic = false;
        

        public void Disable()
        {
            _isEnabled = false;
            Cirrus.Utils.Color.SetA(ref _icon, _alpha);
        }

        public void Enable()
        {
            _isEnabled = true;
            Cirrus.Utils.Color.SetA(ref _icon, 1);            

        }


    }

}
