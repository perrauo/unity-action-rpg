//using Cirrus.ARPG.Controls;
using Cirrus.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
// AIController States

namespace Cirrus.ARPG.World.Objects.Characters.Controls
{
    public interface IControllerState : IState
    {
        Vector2 AxesLeft { get; set; }
        Vector2 AxesRight { get; set; }

        // These are Only for option (TODO remove)
        void Adapt(Option option, BaseObject target, params object[] args);

        void Adapt();

        void Jump();
        void ToggleMenu();
        void MenuMove(Vector2Int movement);
        void CycleSubmenus(int direction);
    }


    public abstract class StateResource : AssetState, IResource
    {
        override public int Id { get { return (int)Controls.Id.Human; } }

    }

    public abstract class State : Cirrus.FSM.State, IState, IControllerState
    {
        public Controller Controller { get { return (Controller)Context[0]; } }

        public virtual Vector2 AxesLeft
        {
            get
            {
                return Vector2.zero;
            }

            set
            {

            }

        }

        public virtual Vector2 AxesRight
        {
            get
            {
                return Vector2.zero;
            }

            set
            {

            }
        }

        public virtual void ToggleMenu()
        {
            ARPG.UI.HUD.Instance.Menu.Enabled = !ARPG.UI.HUD.Instance.Menu.Enabled;
        }

        //public virtual TryEnterMenu()


        public virtual void MenuMove(Vector2Int movement)
        {
            //ARPG.UI.HUD.Instance.Menu.Move(movement);
        }

        public virtual void CycleSubmenus(int direction)
        {
            //ARPG.UI.HUD.Instance.Menu.CycleSubmenus(direction);
        }


        public State(object[] context, StateResource resource) : base(context, resource)
        {

        }

        public override void Enter(params object[] args)
        {

        }

        public override void Reenter(params object[] args)
        {

        }

        public override void Exit()
        {

        }


        public override void BeginUpdate()
        {

        }

        public override void EndUpdate()
        {

        }

        public virtual void UpdateMovement()
        {
            
        }

        public virtual void UpdateDirection()
        {

        }

        public override void UpdateDrawGizmos()
        {        

        }

        public virtual void Adapt(Option option, BaseObject target, params object[] args)
        {
            //throw new System.NotImplementedException();
        }

        public virtual void Adapt()
        {
            //throw new System.NotImplementedExcepti/*o*/n();
        }

        public virtual void Jump()
        {
            //throw new System.NotImplementedException();
        }


    }
}
