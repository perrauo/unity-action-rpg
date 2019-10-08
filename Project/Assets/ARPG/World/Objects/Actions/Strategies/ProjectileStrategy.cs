using UnityEngine;
using System.Collections;

using Cirrus.ARPG.World.Objects.Actions;
using Cirrus.ARPG.World.Objects.Characters.Actions;

namespace Cirrus.ARPG.World.Objects.Actions.Strategies
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Strategies/Projectile")]
    public class ProjectileStrategy : Resource
    {
        [SerializeField]
        private Projectile _projectileTemplate;

        public override Resource.Strategy Create()
        {
            return new Strategy(this);
        }

        public class Strategy : Resource.Strategy
        {
            ProjectileStrategy _resource;

            BaseObject _source;

            public Strategy(ProjectileStrategy resource) : base(resource)
            {
                _resource = resource;
            }

            public override void UseAgainst(BaseObject source, BaseObject target)
            {
                _source = source;

                var dir = target.Transform.position - _source.Transform.position;
                dir.Normalize();
                var proj = _resource._projectileTemplate.Create(_source, _source.Transform.position, dir);
                proj.OnTargetHitHandler += OnHit; // TODO: unsub
            }

            // We dont care whihc type of actor
            public override bool Use(BaseObject source)
            {
                _source = source;

                var proj = _resource._projectileTemplate.Create(source, source.Transform.position, source.Transform.forward);
                proj.OnTargetHitHandler += OnHit; // TODO: unsub
                return false;
            }

            public void OnHit(BaseObject target)
            {
                _direction = (target.Transform.position - _source.Transform.position).normalized;
                OnTargetHitHandler?.Invoke(target);
            }


        }
    }

}