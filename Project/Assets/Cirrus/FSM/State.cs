using UnityEngine;
using UnityEditor;

namespace Cirrus.FSM
{
    public abstract class State
    {
        public Resource resource;
        public object[] context;

        public int Id { get { return resource.Id; } }

        public State(object[] context, Resource resource)
        {
            this.resource = resource;
            this.context = context;
        }

        public virtual void Enter(params object[] args) { }
        public virtual void Exit() { }
        public virtual void Reenter(params object[] args) { }

        public virtual void BeginTick() { }
        public virtual void EndTick() { }
        virtual public void OnDrawGizmos() { }  
    }

}
