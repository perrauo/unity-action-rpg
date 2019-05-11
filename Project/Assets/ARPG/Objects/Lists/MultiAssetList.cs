using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cirrus.ARPG.Objects;
using Cirrus.ARPG.Objects.Characters;
//using Cirrus.ARPG.Objects.Effects;
using Cirrus.ARPG.Objects.Characters.Controls.AI;
using System.Linq;


//THIS IS READONLY

namespace Cirrus.ARPG.Objects
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Lists/Multi List")]
    public class MultiAssetList : AssetList
    {
        [SerializeField]
        private List<SceneList> _lists;

        public override List<BaseObject> List
        {
            get
            {
                return _lists.SelectMany(x => x).ToList();
            }
        }
    }
}
