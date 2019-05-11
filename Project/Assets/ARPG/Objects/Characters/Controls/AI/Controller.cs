
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.AI;
using Cirrus.ARPG.Objects.Characters.Actions;
//using Cirrus.ARPG.Controls;


// Controls Navmesh Navigation


namespace Cirrus.ARPG.Objects.Characters.Controls.AI
{
    public class Controller : Controls.Controller
    { 
        [SerializeField]
        private Agent _agent;

        [SerializeField]
        public Cirrus.FSM.Machine FSM;

        public FSM.State State { get {
                return (FSM.State)FSM.Top;
            } }


        public void Start()
        {
            _agent.OnEnvironmentChangedHandler += OnEnvironmentChanged;

            FSM.SetContext(_agent, 0);
            FSM.SetContext(this, 1);
            FSM.SetContext(_character, 2);
            FSM.Start();
            State.Addapt();
        }

        public void Update()
        {
            FSM.DoUpdate();
        }

        public void OnEnvironmentChanged(Option option, BaseObject target, params object[] args)
        {
            State.Addapt(option, target, args);
        }

        public void OnDrawGizmos()
        {
            FSM.OnDrawGizmos();
        }


    }
}