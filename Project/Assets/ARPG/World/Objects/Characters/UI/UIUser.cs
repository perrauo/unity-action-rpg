using System;

using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using UnityEditor;

using Cirrus.ARPG.World.Objects.Attributes;

using Cirrus.ARPG.World.Objects.Characters.Attributes;

namespace Cirrus.ARPG.World.Objects.Characters.UI
{
    public class UIUser : Objects.UI.UIUser
    {
        [SerializeField]
        public PlayfulSystems.ProgressBar.ProgressBarPro Health;

        // TODO dispatch the proper health handlign to either player health object or enemy
        [SerializeField]
        private bool _enableHealth = true;

        [SerializeField]
        private float _showTime;

        public void Show()
        {
            if(_enableHealth)
            StartCoroutine(ShowCoroutine(_showTime));
        }

        public IEnumerator ShowCoroutine(float waitTime)
        {
            Health.gameObject.SetActive(true);

            yield return new WaitForSeconds(waitTime);

            Health.gameObject.SetActive(false);

            yield return null;
        }

    }



}
