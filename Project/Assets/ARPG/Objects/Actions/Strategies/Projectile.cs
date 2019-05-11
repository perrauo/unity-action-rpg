//using UnityEngine;
//using System.Collections;

//namespace Cirrus.ARPG.Objects.Actions.AttemptStrategies
//{
//    public enum ColliderType
//    {
//        Duration,
//        OnHit
//    }

//    public class ColliderOverlap : Resource
//    {
//        public override AttemptStrategy Create()
//        {
//            return new Strategy(this);
//        }


//        public class Strategy : AttemptStrategy
//        {
//            public Strategy(Resource resource) : base(resource) { }

//            public override void Use(Action action)
//            {
//                throw new System.NotImplementedException();
//            }

//            public override void Perform(Action action, Target target)
//            {
//                throw new System.NotImplementedException();
//            }
//        }
//    }

//}