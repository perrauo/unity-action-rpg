using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cirrus.Editor;
using Cirrus.Tags;

namespace Cirrus.ARPG.World.Objects.Actions
{
    public abstract class AssetAction : ScriptableObject, IActionResource
    {
        public abstract ActionProduct Create();

        [SerializeField]
        public List<Tag> _tags;

        public List<Tag>  Tags {get {return _tags;} }

        public abstract float MinRange { get; }

        public abstract float MaxRange { get; }


    }
}
