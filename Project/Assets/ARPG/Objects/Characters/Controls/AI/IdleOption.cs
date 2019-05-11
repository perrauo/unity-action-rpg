using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.Objects.Actions;
using UnityEngine.AI;

namespace Cirrus.ARPG.Objects.Characters.Controls.AI
{
    public partial class Decision
    {
        //public IdleOption.Data Idle;
    }

    public class IdleOption : Option
    {
        public override Decision CreateDecision(BaseObject target)
        {
            return Decision;
        }

        public static Decision Decision
        {
            get
            {
                return new Decision
                {                   
                    State = FSM.Id.Idle
                };
            }
        }
    }
}
