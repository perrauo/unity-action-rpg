using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    public class AIBehaviour : ScriptableObject
    {
        public virtual void UpdateMovement(Controller ctrl, Agent agent, Character character) { }

        public virtual void UpdateDirection(Controller ctrl, Agent agent, Character character)
        {

        }
    }

     // TODO: raycast from player to navmeshagent

    public class SimpleBehaviour : AIBehaviour
    {
        public override void UpdateDirection(Controller ctrl, Agent agent, Character character)
        {
            Vector2 dir = new Vector2(agent.NavMeshAgent.desiredVelocity.x, agent.NavMeshAgent.desiredVelocity.z).normalized;
            character.TargetAxes.Right = Vector2.Lerp(character.TargetAxes.Right, dir, 0.5f);
        }


        public override void UpdateMovement(Controller ctrl, Agent agent, Character character)
        {
            Vector3 desiredVelocity = agent.NavMeshAgent.desiredVelocity;

            agent.NavMeshAgent.transform.position = character.Transform.position;
            agent.NavMeshAgent.velocity = character.MovementUser.Motor.Velocity;

            float step = desiredVelocity.magnitude / agent.NavMeshAgent.speed;
            Vector2 dir = new Vector2(desiredVelocity.x, desiredVelocity.z).normalized;
            character.TargetAxes.Left = Vector2.Lerp(Vector2.zero, dir, step);

     
            // If intersect wall from character to agent
            // Raycast from character to agent does not work because the agent has the same position
            if (Physics.Raycast(
                character.Transform.position + Vector3.up * 0.5f, 
                desiredVelocity, out RaycastHit hit, 
                ctrl.Resource.LedgeRaycastLenght, 
                Game.Instance.Layers.LayoutFlags))
            {
                character.Jump();
            }
        }

    }
}
