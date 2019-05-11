using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

namespace Cirrus.ARPG.Objects.UI
{
    public class UI : MonoBehaviour
    {
        public GameObject Arrow;

        public void Select()
        {
            Arrow.SetActive(true);

        }

        public void Deselect()
        {
            Arrow.SetActive(false);

        }




    }








}
