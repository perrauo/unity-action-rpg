using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.ARPG.UI
{

    public class MenuOption : MonoBehaviour
    {
        [SerializeField]
        public UnityEngine.UI.Button _button;

        public OnIntEvent OnSelectedHandler;

        [SerializeField]
        private int index = 0;

        public void OnValidate()
        {
            if (_button == null)
            {
                _button = GetComponent<UnityEngine.UI.Button>();
            }

            index = transform.GetSiblingIndex();

        }

        private bool _init = false;

        // Start is called before the first frame update
        public void OnEnable()
        {
            if (_init)
                return;

            _init = true;
            _button.onClick.AddListener(OnClicked);
        }

        public void OnClicked()
        {
            OnSelectedHandler?.Invoke(index);

        }


        // Update is called once per frame
        void Update()
        {

        }
    }

}