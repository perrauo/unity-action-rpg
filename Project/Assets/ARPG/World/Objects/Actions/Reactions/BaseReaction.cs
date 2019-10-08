using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects.Actions
{
    public abstract class BaseReaction : MonoBehaviour
    {
        [SerializeField]
        protected BaseObject _source;

        public enum Action
        {
            Asset,
            Scene,
            None
        }

        [SerializeField]
        private Action _action;


        [Editor.ConditionalHide("_action", enumValue =0, isVisible =true)]
        [SerializeField]
        private AssetAction _assetAction;

        [Editor.ConditionalHide("_action", enumValue = 1, isVisible = true)]
        [SerializeField]
        private SceneAction _sceneAction;

        protected ActionProduct _actionFinal;

        public virtual void Awake()
        {
            if (_action == Action.Asset)
            {

                _actionFinal = _assetAction.Create();
            }
            else if(_action == Action.Scene)
            {
                _actionFinal = _sceneAction.Create();
            }
            else
            {
                _actionFinal = null;
            }
        }

        public virtual void Start()
        {

        }

        public virtual void OnValidate()
        {
            if (_source == null)
                _source = GetComponentInParent<BaseObject>();
        }

        public virtual void React()
        {
            if (_actionFinal != null)
                _actionFinal.UseAgainst(_source);
        }

        public virtual void React(BaseObject against)
        {
            if (_actionFinal != null)
                _actionFinal.UseAgainst(against);
        }
    }
}
