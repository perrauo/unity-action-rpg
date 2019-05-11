//using Cirrus.ARPG.Controls;
using Cirrus.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AIController States

namespace Cirrus.ARPG.Objects.Characters.Controls.AI.FSM
{
    public abstract class Resource : Cirrus.FSM.Resource
    {
        override public int Id { get { return -1; } }

        [SerializeField]
        public float RefreshRate = 2f;

        // Raycast to determine if slop, or jump
        [SerializeField]
        public float SlopeRaycastLenght = 2f;

        [SerializeField]
        public float AgentPositionSmooth = 0.8f;

        [SerializeField]
        public float AxesLeftStep = 0.4f;

        [SerializeField]
        public float AxesRightStep = 0.4f;

        //public override
        //    Cirrus.FSM.State Create(object[] context);

    }

    public enum Id
    {
        Human,
        Decide,
        Action,
        UseAction,
        Wander,
        Patrol,
        Observe,
        Follow,
        Decision,
        Idle,
       
    }

    public abstract class State : Cirrus.FSM.State
    {

        new protected virtual Resource Resource { get { return (Resource)resource; } }
        protected virtual Agent Agent { get { return (Agent)context[0]; } }
        protected virtual Controller Controller { get { return (Controller)context[1]; } }
        protected virtual Character Character { get { return (Character)context[2]; } }

        protected Vector2 _targetAxesLeft = Vector2.zero;

        protected Vector2 _targetAxesRight = Vector2.zero;

        protected IEnumerator _calculatePathCoroutine;

        protected BaseObject _target;

        protected Vector3 _sampledPosition = Vector3.zero;

        protected Vector3 _destination;

        public State(object[] context, Resource resource) : base(context, resource)
        {

        }

        // Override if you do not want to reconsider
        public virtual void Addapt(Option option, BaseObject target, params object[] args)
        {
            if (Agent.Decide(option, target, args))
            {
                Controller.FSM.SetState(Agent.Decision.State);
            }
        }

        public virtual void Addapt()
        {
            Agent.Decide();
            Controller.FSM.SetState(Agent.Decision.State);
        }

        public override void Enter(params object[] args)
        {

        }


        public virtual void DoEnter()
        {
            Character.Axes.Left = Vector2.zero;
            _targetAxesLeft = Vector2.zero;

            _calculatePathCoroutine = CalculatePathCoroutine(Resource.RefreshRate);
            Agent.StartCoroutine(_calculatePathCoroutine);
        }


        public override void Exit() { }




        public override void BeginTick()
        {

        }


        public override void EndTick()
        {

        }

        public virtual void Move()
        {
            Agent.NavMeshAgent.transform.position = Vector3.Lerp(Agent.NavMeshAgent.transform.position, Character.transform.position, Resource.AgentPositionSmooth);
            float step = Agent.NavMeshAgent.desiredVelocity.magnitude / Agent.NavMeshAgent.speed;
            Agent.NavMeshAgent.velocity = Character.CharacterController.Motor.Velocity;

            Vector2 dir = new Vector2(Agent.NavMeshAgent.desiredVelocity.x, Agent.NavMeshAgent.desiredVelocity.z).normalized;
            _targetAxesLeft = Vector2.Lerp(Character.Axes.Left, dir, step);

            Debug.DrawRay(Character.transform.position + Vector3.up * 1f, dir, Color.red);
            var ray = new Ray(Character.transform.position + Vector3.up * 1f, dir);
            if (Physics.Raycast(ray, out RaycastHit hit, Resource.SlopeRaycastLenght, Game.Instance.Layers.Layout))
            {
                if (hit.point.y > Character.transform.position.y + 1)
                {
                    Character.Jump();
                }
            }
        }

        public virtual void EndMove()
        {
            Character.Axes.Left = Vector3.Lerp(Character.Axes.Left, _targetAxesLeft, Resource.AxesLeftStep);
            Character.Axes.Right = Vector3.Lerp(Character.Axes.Right, _targetAxesRight, Resource.AxesRightStep);
        }


        protected virtual IEnumerator CalculatePathCoroutine(float waitTime)
        {
            yield return null;
        }

    }
}
