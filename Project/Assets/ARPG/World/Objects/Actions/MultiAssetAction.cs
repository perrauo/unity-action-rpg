using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cirrus.Editor;

namespace Cirrus.ARPG.World.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Multi Action")]
    public class MultiAssetAction : AssetAction, IMultiAction
    {
        [SerializeField]
        private List<AssetAction> _actions;

        public override float MaxRange
        {
            get
            {
                return _actions.Max(x => x.MaxRange);
            }
        }

        public override float MinRange
        {
            get
            {
                return _actions.Max(x => x.MinRange);
            }
        }


        public IEnumerable<IActionResource> Actions { get { return _actions; } }

        public override ActionProduct Create()
        {
            return new MultiActionProduct(this);
        }

       
    }
}
