using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.Tags;

namespace Cirrus.ARPG.World.Objects.Actions
{
    public interface IActionResource
    {
        ActionProduct Create();
        
        List<Tag> Tags { get; }

        float MaxRange { get; }

        float MinRange { get; }       
    }

    public interface ISimpleAction : IActionResource
    {
        IEnumerable<ARPG.Actions.IEffect> Effects {get;}

        Strategies.Resource Strategy { get; }
    }

    public interface IMultiAction : IActionResource
    {   

        IEnumerable<IActionResource> Actions { get; }
    }


    public abstract class ActionProduct
    {

        public OnEvent OnActionFinishedHandler;

        public IActionResource _resoure;

        protected BaseObject _source;

        public BaseObject Source
        {
            get
            {
                return _source;
            }
        }

        public virtual Vector3 Direction { get; }

        public IEnumerable<Tag> Tags
        {
            get
            {
                return _resoure.Tags;
            }
        }

        public ActionProduct(IActionResource act)//Resource resource, Actor actor)
        {
            _resoure = act;
        }

        public virtual void Use()
        {
            _source = null;
        }

        public virtual void Use(BaseObject source)
        {
            _source = source;
            Use();
        }

        public virtual void Use(Characters.Character source)
        {
            Use(source as BaseObject);
        }

        public virtual void UseAgainst(BaseObject target)
        {
            //OnTargetHitHandler?.Invoke(target);
        }

        public virtual void UseAgainst(BaseObject source, BaseObject target)
        {
            UseAgainst(target);
        }

        public virtual void UseAgainst(Characters.Character source, BaseObject target)
        {
            UseAgainst(source as BaseObject, target);
        }
    }

    public class SimpleActionProduct : ActionProduct
    {
        protected Strategies.Resource.Strategy _strategy;

        protected ISimpleAction _resource;

        public override Vector3 Direction
        {
            get { return _strategy.Direction; }
        }

        public SimpleActionProduct(ISimpleAction resource) : base(resource)//Resource resource, Actor actor)
        {
            _resource = resource;
            _strategy = _resource.Strategy.Create();

        }

        public override void Use()
        {
            _strategy.Use();
        }

        public override void UseAgainst(BaseObject target)
        {
            _source = null;
            _strategy.OnTargetHitHandler += OnTargetHit;
            _strategy.UseAgainst(target);
        }

        public override void UseAgainst(BaseObject source, BaseObject target)
        {
            _source = source;
            _strategy.OnTargetHitHandler += OnTargetHit;
            _strategy.UseAgainst(source, target);
        }

        public override void UseAgainst(Characters.Character source, BaseObject target)
        {
            _source = source;
            _strategy.OnTargetHitFromCharacterHandler += OnTargetHit;
            _strategy.UseAgainst(source, target);
        }


        public void OnTargetHit(BaseObject target)
        {
            _strategy.OnTargetHitHandler -= OnTargetHit;

            foreach (var ef in _resource.Effects)
            {
                target.TryApply(this, ef);
            }

            target.NotifyActionHandled(this);
        }


        public void OnTargetHit(Characters.Character source, BaseObject target)
        {
            _strategy.OnTargetHitFromCharacterHandler -= OnTargetHit;

            foreach (var ef in _resource.Effects)
            {
                target.TryApply(source, this, ef);
            }

            target.NotifyActionHandled(this);
        }


        public void OnTargetHit(BaseObject source, BaseObject target)
        {
            _strategy.OnTargetHitFromObjectHandler -= OnTargetHit;

            foreach (var ef in _resource.Effects)
            {
                target.TryApply(source, this, ef);
            }

            target.NotifyActionHandled(this);
        }

        public void OnStrategyFinished()
        {
            OnActionFinishedHandler?.Invoke();
        }
    }

    public class MultiActionProduct : ActionProduct
    {
        private List<ActionProduct> _actions = new List<ActionProduct>();

        public MultiActionProduct(IMultiAction resource) : base(resource)//Resource resource, Actor actor)
        {
            foreach (var res in resource.Actions)
            {
                _actions.Add(res.Create());
            }
        }

        public override void Use(BaseObject source)
        {
            foreach (var a in _actions)
            {
                a.Use(source);
            }
        }

        public override void Use(Characters.Character source)
        {
            foreach (var a in _actions)
            {
                a.Use(source);
            }
        }


        public override void UseAgainst(BaseObject source, BaseObject target)
        {
            foreach (var a in _actions)
            {
                a.UseAgainst(source, target);
            }
        }

        public override void UseAgainst(Characters.Character source, BaseObject target)
        {
            foreach (var a in _actions)
            {
                a.UseAgainst(source, target);
            }
        }


        public override void UseAgainst(BaseObject target)
        {
            foreach (var a in _actions)
            {
                a.UseAgainst(target);
            }
        }
    }
}