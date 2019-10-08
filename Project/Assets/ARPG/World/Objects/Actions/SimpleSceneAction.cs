using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cirrus.Editor;

namespace Cirrus.ARPG.World.Objects.Actions
{
    public class SimpleSceneAction : SceneAction, ISimpleAction
    {
        [SerializeField]
        private List<ARPG.Actions.AssetEffect> _assetEffects;

        [SerializeField]
        private List<ARPG.Actions.SceneEffect> _sceneEffects;

        public IEnumerable<ARPG.Actions.IEffect> Effects { get { return _assetEffects; } }

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
