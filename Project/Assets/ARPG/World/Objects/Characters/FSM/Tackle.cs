using UnityEngine;
using UnityEditor;
using System;
using KinematicCharacterController;
using Cirrus.FSM;
using Cirrus.FSM;
using System.Collections;

namespace Cirrus.ARPG.World.Objects.Characters.FSM
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/FSM/Tackle")]
    public class Tackle : Resource
    {
        override public int Id { get { return (int)FSM.Id.Tackle; } }

        public override IState PopulateState(object[] context)
        {
            return new State(context, this);
        }

        new public class State : FSM.State
        {
            public State(object[] context, Cirrus.FSM.AssetState resource) : base(context, resource)
            {
                _timer = new Timer(2, start:false, repeat:false);
                _timer.OnTimeLimitHandler += OnTimeOut;
            }

            private BaseObject _target;

            private Objects.Actions.Strategies.TackleStrategy.Strategy _strategy;

            private Vector3 _direction;

            private Timer _timer;

            private Vector3 _initialPosition;

            private Vector3 _withdrawPosition;

            private bool _targetHit = false;

            private float _distance = 0;

            private bool _isOnHitSubscribed = false;

            private IEnumerator _tackleCoroutine;

            private IEnumerator _withdrawCoroutine;

            public override void Enter(params object[] args)
            {
                _initialPosition = Character.Transform.position;

                _distance = 0;

                _strategy = (Objects.Actions.Strategies.TackleStrategy.Strategy)args[0];
                if (args.Length == 2)
                {
                    _target = (BaseObject)args[1];
                    _direction = _target.Transform.position - Character.Transform.position;
                    _distance = _direction.magnitude;
                }
                else
                {
                    _direction = Character.Transform.forward;
                    _distance = _strategy._resource.MaxRange;
                }

                _direction = _direction.normalized;

                _strategy._direction = _direction;

                _targetHit = false;
                _isOnHitSubscribed = false;
                SubscribeOnHit();

                _timer.Start(_strategy._resource._timeoutTime);

                _tackleCoroutine = TackleCoroutine();
                Character.StartCoroutine(_tackleCoroutine);
            }

            public override void Reenter(params object[] args)
            {
                _initialPosition = Character.Transform.position;

                _distance = 0;

                _targetHit = false;

                _strategy = (Objects.Actions.Strategies.TackleStrategy.Strategy)args[0];
                if (args.Length == 2)
                {
                    _target = (BaseObject)args[1];
                    _direction = _target.Transform.position - Character.Transform.position;
                    _distance = _direction.magnitude;
                }
                else
                {
                    _direction = Character.Transform.forward;
                    _distance = _strategy._resource.MaxRange;
                }

                _direction = _direction.normalized;

                _strategy._direction = _direction;

                _timer.Start(_strategy._resource._timeoutTime);

                //_strategy = _direction;

                Exit();

                _targetHit = false;
                _isOnHitSubscribed = false;
                SubscribeOnHit();

                _tackleCoroutine = TackleCoroutine();
                Character.StartCoroutine(_tackleCoroutine);
            }


            public void SubscribeOnHit(bool subscribe = true)
            {
                if (subscribe)
                {
                    if (!_isOnHitSubscribed)
                    {
                        _isOnHitSubscribed = true;
                        Character.OnObjectCollidedHandler += OnHit;
                    }
                }
                else
                {               
                    _isOnHitSubscribed = false;
                    Character.OnObjectCollidedHandler -= OnHit;                    
                }
            }


            public override void Exit()
            {
                SubscribeOnHit(false);

                if(_tackleCoroutine != null)
                    Character.StopCoroutine(_tackleCoroutine);

                if(_withdrawCoroutine != null)
                    Character.StopCoroutine(_withdrawCoroutine);
            }

            public IEnumerator TackleCoroutine()
            {
                float i = 0;
                while ((_initialPosition - Character.Transform.position).magnitude < _distance)
                {
                    if (_targetHit)
                        break;                    
                    
                    Character.Physic.PushVelocity = 
                        _direction * 
                            _strategy._resource._stepSpeed * 
                            Mathf.Pow(_strategy._resource._withdrawStepDiscount, ++i);
                                       
                    yield return new WaitForSeconds(_strategy._resource._stepDuration);
                }

                _withdrawCoroutine =  WithdrawCoroutine();
                Character.StartCoroutine(_withdrawCoroutine);
            }

            public IEnumerator WithdrawCoroutine()
            {
                _withdrawPosition = Character.Transform.position;

                while ((_withdrawPosition - Character.Transform.position).magnitude < _strategy._resource.MinRange)
                {
                    var dir = (_initialPosition - Character.Transform.position).normalized;

                    Character.Physic.PushVelocity = dir * _strategy._resource._withdrawStepSpeed;

                    yield return new WaitForSeconds(_strategy._resource._stepDuration);
                }

                Character.Physic.PushVelocity = Vector3.zero;
                Character.FSM.TrySetState(FSM.Id.Default);
            }


            public void OnTimeOut()
            {
                _timer.Stop();
                SubscribeOnHit(false);
                Character.Physic.PushVelocity = Vector3.zero;                
                Character.FSM.TrySetState(FSM.Id.Default);

            }

            public void OnHit(BaseObject target)
            {     
                Character.Physic.PushVelocity = Vector3.zero;

                _targetHit = true;
                SubscribeOnHit(false);

                _strategy.OnTargetHitHandler?.Invoke(target);
                _strategy.OnTargetHitFromCharacterHandler?.Invoke(Character, target);
                _strategy.OnTargetHitFromObjectHandler?.Invoke(Character, target);
            }
        }
    }

}