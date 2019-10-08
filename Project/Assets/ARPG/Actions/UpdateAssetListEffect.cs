using UnityEngine;
using System.Collections.Generic;
using Cirrus.ARPG.World.Objects;
using Cirrus.ARPG.World.Objects.Actions;
using System.Linq;
using System;
using Cirrus.ARPG.World.Objects.Characters;

namespace Cirrus.ARPG.Actions
{
    public class UpdateAssetListEffect : AssetEffect
    {
        [System.Serializable]
        public enum Operator
        {
            Add,
            Remove
        }

        public enum Mode{
            Source,
            Target,
            AssetList,
        }

        [System.Serializable]
        public class Operation
        {
            [SerializeField]
            private Operator _operator;

            [SerializeField]
            private Mode _mode;


            [Editor.ConditionalHide("_mode", enumValue=2, isVisible=true)]
            [SerializeField]
            private AssetList _assetList;

            public void Perform(AssetList list, BaseObject source=null, BaseObject target=null)
            {
                switch(_mode)
                {
                    case Mode.Source:
                        if(source != null)
                            if(_operator == Operator.Add)
                                list.Add(source);
                            else
                                list.Remove(source);
                        break;

                    case Mode.Target:
                        if(target != null)
                            if(_operator == Operator.Add)
                                list.Add(target);
                            else
                                list.Remove(target);
                        break;

                    case Mode.AssetList:
                        if(_assetList != null)
                            if(_operator == Operator.Add)
                                list.AddRange(_assetList);
                            else
                                list.RemoveRange(_assetList);
                        break;
                }                
            }
        }

        [SerializeField]
        private AssetList _list;

        [SerializeField]
        private Operation[] _operations;

        protected override void DoApply(ActionProduct action, BaseObject target)
        {
            foreach (Operation op in _operations)
            {
                op.Perform(_list, target);
            }
        }

        protected override void DoApply(Character source, ActionProduct action, BaseObject target)
        {
            foreach (Operation op in _operations)
            {
                op.Perform(_list, source, target);
            }
        }

        protected override void DoApply(ActionProduct action)
        {
            foreach (Operation op in _operations)
            {
                op.Perform(_list);
            }
        }
    }
}
