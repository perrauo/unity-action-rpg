//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using Cirrus.ARPG.World.Objects.Actions;
//using UnityEngine.AI;

//namespace Cirrus.ARPG.World.Objects.Characters.Controls
//{

//    public partial class Decision
//    {
//        public PatrolOption Patrol;
//    }

//    public class PatrolOption : Option
//    {
//        public IEnumerable<Vector3> WayPoints;

//        [SerializeField]
//        private bool _isFromStartPosition;

//        [SerializeField]
//        private float _range = 10.0f;


//        // TODO
//        public override Decision CreateDecision(IEnumerable<BaseObject> targets)
//        {
//            return new Decision
//            {
//                Option = this,
//                Target = target,
//                State = FSM.Id.Wander,

//                Patrol = this

//            };
//        }
//    }
//}
