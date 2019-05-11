//using System;
//using System.Collections.Generic;
//using UnityEngine;

//namespace Cirrus.ARPG.Actions
//{
//    [CreateAssetMenu(menuName = "Cirrus/Objects/Actors/Actions/Prepare/Instant")]
//    public class Instant : PrepateResource
//    {
//        public override PrepareStrategy Create(Action act)
//        {
//            return new Strategy(this, act);
//        }
//    }

//    public class Strategy : PrepareStrategy
//    {
//        public Strategy(Resource resource, Action act) : base(resource, act) { }


//        public override void Prepare(Actor actor, Action action)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
