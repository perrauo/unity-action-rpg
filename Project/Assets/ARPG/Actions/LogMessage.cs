using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Actions
{
    public class LogMessage : AssetEffect
    {
        [SerializeField]
        private string _message = "Hello World";

        protected override void DoApply(World.Objects.Actions.ActionProduct action)
        {
            Debug.Log(_message);
        }
    }
}
