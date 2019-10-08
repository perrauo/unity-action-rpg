using UnityEngine;
using System.Collections.Generic;
using Cirrus.ARPG.World.Objects;
using Cirrus.ARPG.World.Objects.Actions;
using System.Linq;
using System;
using Cirrus.ARPG.World.Objects.Characters;

namespace Cirrus.ARPG.Actions
{
    public class UpdateSceneListEffect : SceneEffect
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
            SceneList,
            AssetList,

            Object,

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
            private SceneList _sceneList;

            [Editor.ConditionalHide("_mode", enumValue=3, isVisible=true)]
            [SerializeField]
            private AssetList _assetList;


            [Editor.ConditionalHide("_mode", enumValue=4, isVisible=true)]
            [SerializeField]
            private BaseObject _object;

            private bool _withSource = false;

            private bool _withTarget = false;

            public void Perform(SceneList list, BaseObject source=null, BaseObject target=null)
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

                    case Mode.Object:
                        if(_object != null)
                            if(_operator == Operator.Add)
                                list.Add(_object);
                            else
                                list.Remove(_object);
                        break;

                    case Mode.SceneList:
                        if(_sceneList != null)
                            if(_operator == Operator.Add)
                                list.AddRange(_sceneList);
                            else
                                list.RemoveRange(_sceneList);
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
        private SceneList _list;

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
