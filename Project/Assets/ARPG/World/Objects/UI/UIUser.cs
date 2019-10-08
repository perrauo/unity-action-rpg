using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

namespace Cirrus.ARPG.World.Objects.UI
{
    public class UIUser : MonoBehaviour
    {
        [SerializeField]
        private GameObject _crosshair;

        public void EnableCrossHair(bool enable)
        {
            _crosshair.SetActive(enable);
        }
    }








}
