//using System;
//using System.Collections.Generic;
//using UnityEngine;

//namespace Cirrus.ARPG.World.Objects.Actions
//{
//    public delegate void OnReady();


//    public abstract class PrepareResource : ScriptableObject
//    {
//        public abstract PrepareStrategy Create(Action act);
//    }

//    public abstract class PrepareStrategy
//    {
//        public OnReady OnReadyHandler;

//        public Resource Resource;

//        public Action Action;

//        public PrepareStrategy(Resource resource, Action action)
//        {
//            this.Resource = resource;
//            this.Action  = action;

//            OnReadyHandler += action.OnReady;
            
//        }

//        public abstract void Prepare(Actor actor, Action action);

//    }
//}
