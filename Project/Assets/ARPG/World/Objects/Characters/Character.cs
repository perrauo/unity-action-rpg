using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cirrus.ARPG.World.Objects.Actions;
using Cirrus.ARPG.World.Objects.Attributes;
using Cirrus.ARPG.World.Objects.Characters.Controls;
//using Cirrus.ARPG.UI.HUD;
//using Cirrus.ARPG.World.Objects.Characters.Strategies;
using KinematicCharacterController;
using UnityEngine;
using Cirrus.ARPG.Actions;
using UnityEngine.AI;
using Cirrus.ARPG.Conditions;
using System;

//using Cirrus.ARPG.World.Objects.Actions;

// TODO some adventurer you have to beat up twice before they run away or forfeit
// TODO some half human adventurer will more likely to show sympathy for the healer's cause

/*
TODO: 
    The reason for composition of BaseObject by Character
 
This could be useful:

I have a parent prefab, and it has a monobehaviour attached to it with all the needed references.

Now I want to create a variant of this prefab, that adds new parts to the prefab. I also create a child 
class of the monobehaviour, 
that adds references to some of these new objects.

It would be awesome if the improved prefab workflow would allow the prefab variant to replace the parent's 
monobehaviour with the child one, and keep all the references. Then if I change the parent monobehaviour 
and parent prefab, including references, those changes will be applied to all variants of the prefab without
having to assign the references one by one in every variant. 

 */

[System.Serializable]
public struct Axes
{
    public Vector2 Left;
    public Vector2 Right;
}

namespace Cirrus.ARPG.World.Objects.Characters
{
    public delegate void OnCharacterEvent(Character obj);

    public class Character : BaseObject, ICharacterController
    {
        [SerializeField]
        private Resource _resource;

        [SerializeField]
        public Persistence _persistence;

        public override Objects.Persistence Persistence
        {
            get
            {
                return _persistence;
            }
        }

        public virtual Persistence CharacterPersistence
        {
            get
            {
                return _persistence;
            }
        }

        public override Attributes.AttributesPersistence Attributes
        {
            get
            {
                return _persistence.Attributes;
            }
        }


        public ARPG.Items.ItemInventoryPersistence Items
        {
            get
            {
                return _persistence.Items;
            }
        }

        public Actions.SkillInventoryPersistence Skills
        {
            get
            {
                return _persistence.Skills;
            }
        }


        [SerializeField]
        public Controller Controller;

        [SerializeField]
        public Controls.Agent Agent;

        [SerializeField]
        public Playable.HUDUser _hudUser;

        [SerializeField]
        public ARPG.Items.InventoryUser InventoryUser;

        [SerializeField]
        public Actions.AbilityUser AbilityUser;

        [SerializeField]
        public Animator Animator;

        [SerializeField]
        public UI.UIUser UI;

        [SerializeField]
        private Movements.MovementUser _movementUser;
        public Movements.MovementUser MovementUser { get { return _movementUser; } }

        [SerializeField]
        private Cirrus.FSM.Machine _fsm;
        public Cirrus.FSM.Machine FSM { get { return _fsm; } }
        public FSM.State State { get { return ((FSM.State)FSM.Top); } }

        public bool IsHuman
        {
            get
            {
                return Controller.State == null ?
                    false :
                    Controller.State.Id == (int)Id.Human;
            }
        }

        protected override void PopulatePersistence()
        {
            _persistence = _resource.CreatePersistence();
        }

        #region Unity Engine

        public override void Awake()
        {
            base.Awake();

            InventoryUser.OnAbilitySelectedHandler += OnAbilitySelected;
        }      

        public override void Start()
        {
            base.Start();
        }

        public void Update()
        {
            //FSM.DoUpdate();

            var health = Attributes.Health;

            if (health.Current / health.Total < .1)
            {
                Animator.SetBool("IsWeak", true);
            }
            else if (health.Current / health.Total < 0)
            {
                Animator.SetBool("IsInjured", true);
            }
        }

        protected void OnDrawGizmos()
        {
            //This is why we need FSM to be a MonoBehaviour of its own (Sorry mom) TODO: change back from class to monobehaviour
            //FSM.OnDrawGizmos();
        }

        #endregion


        #region Strategies

        public virtual void Tackle(
            Objects.Actions.Strategies.TackleStrategy.Strategy strategy)
        {
            if (!IsMovementInputEnabled)
                return;

            FSM.TrySetState(Characters.FSM.Id.Tackle, strategy);
        }

        public virtual void TackleTarget(
            Objects.Actions.Strategies.TackleStrategy.Strategy strategy,
            BaseObject target)
        {
            if (!IsMovementInputEnabled)
                return;

            FSM.TrySetState(Characters.FSM.Id.Tackle, strategy, target);
        }

        #endregion


        #region Ability


        public virtual bool TryUseAbility(Actions.SceneSkill ability)
        {
            if (!IsMovementInputEnabled)
                return false;

            if (AbilityUser.TryUse(ability))
            {
                AnimateAbility(ability);
                return true;
            }

            return false;
        }

        public virtual bool TryUseAbilityAgainst(Actions.SceneSkill ability, BaseObject target)
        {
            if (!IsMovementInputEnabled)
                return false;

            if (AbilityUser.TryUseAgainst(ability, target))
            {
                AnimateAbility(ability);
                return true;
            }

            return false;
        }


        // TODO: Replace by animation effect
        public virtual void AnimateAbility(Actions.SceneSkill action)
        {
            if (Animator != null)
            {
                //Animator.Play("Attack");
            }
        }

        #endregion


        #region Ability

        public List<BaseObject> FocusTargets;

        public List<BaseObject> _cameraFocusTargets;

        //TODO handle in states
        public void OnAbilitySelected(Actions.SceneSkill ability)
        {
            AbilityUser.Select(ability);
        }

        public void FocusCycle(bool focus)
        {
            if (focus)
            {
                if(_cameraFocusTargets == null)
                    _cameraFocusTargets = new List<BaseObject>();

                _cameraFocusTargets.Clear();

                if (FocusTargets == null)
                    FocusTargets = new List<BaseObject>();

                FocusTargets.Clear();

                AbilityUser.Cycle(ref FocusTargets);

                if (FocusTargets.Count != 0)
                {
                    _cameraFocusTargets.AddRange(FocusTargets);
                    _cameraFocusTargets.Add(this);
                    Room.Instance.Camera.TryChangeState(Cameras.State.Focus, _cameraFocusTargets);
                }
            }
            else
            {
                AbilityUser.Unfocus();
                Room.Instance.Camera.TryChangeState(Cameras.State.Follow, this);
                FocusTargets.Clear();
                _cameraFocusTargets.Clear();
            }
        }

        #endregion

        #region Condition

        public override bool Verify(ICondition condition)
        {
            return condition.Verify(this);
        }

        public override bool DispatchVerify(BaseObject target, ICondition condition)
        {
            return target.Verify(this, condition);
        }


        public override bool Verify(BaseObject source, ICondition condition)
        {
            return condition.Verify(source, this);
        }

        public override bool Verify(Character source, ICondition condition)
        {
            return condition.Verify(source, this);  
        }

        #endregion


        #region Effects

        public void Dash()// DashData, ...
        {

        }

        public override bool DispatchTryApply(Objects.Actions.ActionProduct action, IEffect effect, BaseObject target)
        {
            return target.TryApply(this, action, effect);
        }

        public override bool TryApply(Objects.Actions.ActionProduct action, IEffect effect)
        {
            return effect.TryApply(action, this);
        }


        public override bool TryApply(Character source, Objects.Actions.ActionProduct action, IEffect effect)
        {
            return effect.TryApply(source, action, this);
        }

        public override bool TryApply(BaseObject source, Objects.Actions.ActionProduct action, IEffect effect)
        {
            return effect.TryApply(source, action, this);   
        }


        public void Injure()
        {
            Animator.Play("Injured");
            FSM.TrySetState(Characters.FSM.Id.Injured);

            Controller.Injure();
        }

        public void Kill()
        {
            if (Animator != null)
            {
                Animator.Play("Dead");
            }
        }

        public void Recover()
        {

            if (Animator != null)
            {
                Animator.Play("Healed");
            }
        }



        //////



        #endregion


        #region Controls

        [SerializeField]
        public Axes Axes;

        [HideInInspector]
        public Axes TargetAxes;

        #endregion

        #region Movements


        [SerializeField]
        private bool _isGrounded = false;

        public bool IsGrounded
        {
            get
            {
                return _isGrounded;
            }

            set
            {
                _isGrounded = value;

                if (_isGrounded)
                {
                    Physic.BaseVelocity.y = 0;
                }
            }
        }

        public virtual void Jump()
        {
            if (IsGrounded)
            {
                if (!IsMovementInputEnabled)
                    return;

                Physic.BaseVelocity.y += MovementUser.Resource.JumpSpeed;
                MovementUser.Motor.ForceUnground();
                IsGrounded = false;
            }
        }

        protected virtual bool IsMovementInputEnabled { get { return true; } }

        private Vector3 _targetDirection = Vector3.zero;
        private Vector3 _direction = Vector3.zero;



        public virtual void BeforeCharacterUpdate(float deltaTime)
        {
            if (!IsMovementInputEnabled)
                return;

            Vector2 a =
                Axes.Left *
                MovementUser.Resource.MaxSpeed;

            Vector3 b = new Vector3(a.x, 0, a.y);

            Physic.MoveVelocity = Vector3.Lerp(Physic.MoveVelocity, b, MovementUser.Resource.SpeedSmooth);

            if (!IsGrounded)
                Physic.BaseVelocity.y -= Physic.Gravity;
        }

        public virtual void AfterCharacterUpdate(float deltaTime) { }

        public virtual void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            if (!IsMovementInputEnabled)
                return;

            int count = 0;
            if (FocusTargets != null && FocusTargets.Count != 0)
            {
                count = FocusTargets.Count;
            }

            if (count > 0)
            {
                Vector3 total = FocusTargets.Aggregate(Vector3.zero, (sum, next) => sum + next.transform.position);
                Vector3 avg = total / count;

                _targetDirection = avg - Transform.position;
                _targetDirection.y = 0;

                _direction = Vector3.Lerp(_direction, _targetDirection, MovementUser.Resource.RotationSpeed).normalized;

                currentRotation = Quaternion.LookRotation(_direction);

            }
            else if (!Cirrus.Utils.Mathf.CloseEnough(Axes.Right.magnitude, 0))
            {
                // Smoothly interpolate from current to target look direction               
                _targetDirection = new Vector3(Axes.Right.x, 0.0f, Axes.Right.y);

                _direction = Vector3.Lerp(_direction, _targetDirection, MovementUser.Resource.RotationSpeed).normalized;

                if (_direction.magnitude > 0.01f)
                    currentRotation = Quaternion.LookRotation(_direction, Transform.up);
            }
            else
            {
                // Smoothly interpolate from current to target look direction  
                _targetDirection = new Vector3(Axes.Left.x, 0.0f, Axes.Left.y);
                _direction = Vector3.Lerp(_direction, _targetDirection, MovementUser.Resource.RotationSpeed).normalized;


                if (_direction != Vector3.zero)
                    currentRotation = Quaternion.LookRotation(_direction, Transform.up);
            }
        }

        public virtual void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
            currentVelocity = Physic.TotalVelocity;
        }

        public void PostGroundingUpdate(float deltaTime)
        {
            if (!MovementUser.Motor.GroundingStatus.IsStableOnGround)
            {
                IsGrounded = false;//.FSM.TrySetState((int)FSM.Id.Airborne);
                return;
            }
        }


        public bool IsColliderValidForCollisions(Collider coll)
        {
            return true;
        }


        public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
            IsGrounded = true;
        }

        public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
            
        }

        public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
        {
            
        }

        public void OnDiscreteCollisionDetected(Collider hitCollider)
        {
            
        }

        #endregion

    }

}
