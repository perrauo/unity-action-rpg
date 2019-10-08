using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cirrus.Editor;

namespace Cirrus.ARPG.World.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Action")]
    public class SimpleAssetAction : AssetAction, ISimpleAction
    {
        [SerializeField]
        private List<ARPG.Actions.AssetEffect> _effects;

        public IEnumerable<ARPG.Actions.IEffect> Effects { get { return _effects; } }

        [Required]
        [SerializeField]
        private Strategies.Resource _strategy;

        public Strategies.Resource Strategy { get { return _strategy; } }

        public override float MinRange
        {
            get {
                return _strategy.MinRange;
            }
        }

        public override float MaxRange
        {
            get
            {
                return _strategy.MaxRange;
            }
        }

        public override ActionProduct Create()
        {
            return new SimpleActionProduct(this);
        }

        
    }
}
