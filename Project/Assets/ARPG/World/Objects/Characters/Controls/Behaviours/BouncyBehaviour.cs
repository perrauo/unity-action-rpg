using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    public class BouncyBehaviour : AIBehaviour
    {
        public override void UpdateMovement(Controller ctrl, Agent agent, Character character)
        {
            agent.NavMeshAgent.transform.position = character.Transform.position;
            agent.NavMeshAgent.velocity = character.MovementUser.Motor.Velocity;

            float step = agent.NavMeshAgent.desiredVelocity.magnitude / agent.NavMeshAgent.speed;
            Vector2 dir = new Vector2(agent.NavMeshAgent.desiredVelocity.x, agent.NavMeshAgent.desiredVelocity.z).normalized;
            character.TargetAxes.Left = Vector2.Lerp(Vector2.zero, dir, step);

            character.Jump();                
            
        }

    }
}
