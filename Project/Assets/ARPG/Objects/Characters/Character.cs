using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cirrus.ARPG.Objects.Actions;
using Cirrus.ARPG.Objects.Attributes;
using Cirrus.ARPG.Objects.Characters.Controls.AI;
using Cirrus.ARPG.UI.HUD;
//using Cirrus.ARPG.Objects.Characters.Strategies;
using KinematicCharacterController;
using UnityEngine;
using Cirrus.ARPG.Actions;
using UnityEngine.AI;
using Cirrus.ARPG.Conditions;

//using Cirrus.ARPG.Objects.Actions;

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


namespace Cirrus.ARPG.Objects.Characters
{ 
    [System.Serializable]
    public struct Axes
    {
        public Vector2 Left;
        public Vector2 Right;
    }

    public class Character : BaseObject
    {
        [SerializeField]
        public Axes Axes;

        [SerializeField]
        public Persistence Persistence;

        // TODO remove
        public override AttributesPersistence Attributes
        {
            get {
                return Persistence.Attributes;
            }
        }

        [SerializeField]
        public Controls.AI.Agent Agent;

        [Editor.Rename("HUD User")]
        [SerializeField]
        public Playable.HUDUser _hudUser;

        [SerializeField]
        public Items.InventoryUser InventoryUser;

        [SerializeField]
        public Actions.AbilityUser AbilityUser;

        [SerializeField]
        public Animator Animator;

        // TODO: Do not use it here!! (character shouldnt know about how its controlled)
        [SerializeField]
        public Playable.Controls.Controller Controller;

        [SerializeField]
        private KinematicControls.CustomCharacterController _characterController;
        public KinematicControls.CustomCharacterController CharacterController { get { return _characterController; } }


        [SerializeField]
        private Cirrus.FSM.Machine _fsm;
        public Cirrus.FSM.Machine FSM { get { return _fsm; } }
        public FSM.State State { get { return ((FSM.State)FSM.Top); } }


        protected override void Awake()
        {
            base.Awake();
            FSM.SetContext(this, 0);
            FSM.SetContext(_characterController, 1);

            Levels.Room.OnRoomLoadedHandler += OnRoomLoaded;
        }       


        protected void Start()
        {
            //base.Start();
            FSM.Start();
        }

        public void Update()
        {
            FSM.DoUpdate();
        }

        protected void OnDrawGizmos()
        {
            //This is why we need FSM to be a MonoBehaviour of its own (Sorry mom) TODO: change back from class to monobehaviour
            FSM.OnDrawGizmos();
        }

        public void OnRoomLoaded(Levels.Room room)
        {
  
        }

        public void Jump()
        {
            State.Jump();
        }


        #region Action

        public void UseAction(Actions.Ability ac)
        {
            State.UseAction(ac);
        }
 
        public void UseAction(Actions.Ability action, BaseObject target)
        {
            State.UseAction(action, target);           
        }


        public virtual void DoUseAction(Actions.Ability action)
        {
            if (AbilityUser.TryUse(action))
            {
                AnimateAction(action);
            }
        }

        public virtual void DoUseAction(Actions.Ability action, BaseObject target)
        {
            if (AbilityUser.TryUse(action, target))
            {
                AnimateAction(action);
            }
        }




        // TODO: Replace by animation effect
        public virtual void AnimateAction(Actions.Ability action)
        {
            if (Animator != null)
            {
                Animator.Play("Attack");
            }
        }

        #endregion


        #region Condition


         public virtual bool Verify(BaseObject source, BaseCondition condition)
        {
            // TODO more obj
            if (source is Character)
            {
                return condition.Verify((BaseObject)(source as Character), this);
            }
            else
            {
                return condition.Verify(source, this);
            }
        }




        #endregion


        #region Effects


        public override bool TryApply(BaseObject source, BaseEffect effect)
        {
            if (source is Character)
            {
                return effect.TryApply(source as Character, this);
            }
            else
            {
                return effect.TryApply(source, this);
            }
        }


        private void Injure(BaseObject source)
        {
            //State.Injure();
            //Operator.Injure();
        }

        public void Recover(BaseObject source)
        {
            FSM.SetState(Characters.FSM.Id.Grounded);
            //Operator.Recover();

        }

        #endregion


        #region Kinematic Character Controller

        public void AfterCharacterUpdate(float deltaTime)
        {
            State.AfterCharacterUpdate(deltaTime);
        }


        public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
            State.OnGroundHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);
        }

        public void BeforeCharacterUpdate(float deltaTime)
        {
            State.BeforeCharacterUpdate(deltaTime);
        }

        public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
            State.OnMovementHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);
        }

        public void PostGroundingUpdate(float deltaTime)
        {
            State.PostGroundingUpdate(deltaTime);
        }

        public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
        {
            State.ProcessHitStabilityReport(hitCollider, hitNormal, hitPoint, atCharacterPosition, atCharacterRotation, ref hitStabilityReport);
        }

        public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            State.UpdateRotation(ref currentRotation, deltaTime);
        }

        public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
            State.UpdateVelocity(ref currentVelocity, deltaTime);
        }


#endregion

    }

}
