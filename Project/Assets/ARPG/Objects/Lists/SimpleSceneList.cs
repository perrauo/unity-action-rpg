using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cirrus.ARPG.Objects.Actions;
using Cirrus.ARPG.Objects.Characters;
using Cirrus.ARPG.Objects.Actions;
using Cirrus.ARPG.Objects.Characters.Controls.AI;
using System.Linq;


//THIS IS READONLY

namespace Cirrus.ARPG.Objects
{
    public class SimpleSceneList : SceneList
    {
        [SerializeField]
        private List<BaseObject> _list;

        public override List<BaseObject> List
        {
            get
            {
                return _list;
            }
        }
    }
}
