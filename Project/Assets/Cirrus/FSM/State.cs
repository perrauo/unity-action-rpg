using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Cirrus.FSM
{
    enum DefaultState
    {
        Idle = -1,
    }

    public interface IResource
    {
        int Id { get ; }
        IState PopulateState(object[] context);

        bool IsStart { get; }
    }
    public interface IState
    {
        //public Resource resource;        //public Resource resource;
        //public object[] context;

        string Name { get; }

        int Id { get; }// { return resource.Id; } }

        void Enter(params object[] args);
        void Exit();
        void Reenter(params object[] args);

        void BeginUpdate();
        void EndUpdate();
        void UpdateDrawGizmos();
    }

    public abstract class AssetState : ScriptableObject, IResource
    {
        virtual public int Id { get { return -1; } }
        public abstract IState PopulateState(object[] context);

        [SerializeField]
        private bool _isStart = false;

        public bool IsStart { get { return _isStart;  } }
    }

    public abstract class State : IState
    {
        public AssetState Resource;
        public object[] Context;

        public int Id { get { return Resource.Id; } }

        public State(object[] context, AssetState resource)
        {
            this.Resource = resource;
            this.Context = context;
        }

        public virtual string Name
        {
            get
            {
                return Resource.name;
            }
        }

        public virtual void Enter(params object[] args) { }
        public virtual void Exit() { }
        public virtual void Reenter(params object[] args) { }

        public virtual void BeginUpdate() { }
        public virtual void EndUpdate() { }

        public virtual void BeginFixedUpdate() { }
        public virtual void EndFixedUpdate() { }

        virtual public void UpdateDrawGizmos() { }

        //[SerializeField]
        //public List<Transition> Transitions;
    }

    public abstract class SceneState : MonoBehaviour, IResource, IState
    {
        public virtual string Name
        {
            get
            {
                return name;
            }
        }

        [SerializeField]
        private bool _isStart = false;

        public bool IsStart { get { return _isStart; } }

        virtual public int Id { get { return -1; } }
        public abstract IState PopulateState(object[] context);

        public virtual void Enter(params object[] args) { }
        public virtual void Exit() { }
        public virtual void Reenter(params object[] args) { }

        public virtual void BeginUpdate() { }
        public virtual void EndUpdate() { }

        public virtual void BeginFixedUpdate() { }
        public virtual void EndFixedUpdate() { }

        virtual public void UpdateDrawGizmos() { }
    }



}
