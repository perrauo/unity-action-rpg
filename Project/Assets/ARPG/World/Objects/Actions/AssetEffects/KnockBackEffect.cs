using System.Collections;
using System.Collections.Generic;
//using Cirrus.ARPG.World.Objects.Actions.Goals;
//using Cirrus.ARPG.World.Objects.Actions.Task;
using UnityEngine;
//using Objects.Characters;
using Cirrus.ARPG.Actions;

namespace Cirrus.ARPG.World.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/KnockBack")]
    public class KnockBackEffect : AssetEffect
    {
        [SerializeField]
        private float _distance = 20;

        [SerializeField]
        private float _stepDiscount = 0.9f;

        [SerializeField]
        private float _stepSpeed = 10;

        [SerializeField]
        private float _stepDuration = 0.1f;

        [SerializeField]
        private float _delay;


        protected override void DoApply(Characters.Character source, ActionProduct action, Characters.Character target)
        {
            target.StartCoroutine(Knockback(source, action, target));
        }

        //public override void Apply(BaseObject target)
        //{
        //    target.HandleHealEffect(this, Amount);
        //}
        public IEnumerator Knockback(Characters.Character source, ActionProduct action, Characters.Character target)
        {
            //yield return null;
            yield return new WaitForSeconds(_delay);

            var direction = action.Direction;
            direction.Normalize();

            float i = 0;
            float distance = 0;
            while (distance < _distance)
            {
                var speed = _stepSpeed * Mathf.Pow(_stepDiscount, i);

                if (target.Physic.MoveVelocity.magnitude < speed)
                    target.Physic.MoveVelocity = speed * direction;
                distance += speed;
                i++;

                yield return new WaitForSeconds(_stepDuration);
            }

            yield return null;
        }
    }


}
