using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Actions
{
    public class LogMessage : BaseEffect
    {
        [SerializeField]
        private string _message = "Hello World";

        protected override void DoApply()
        {
            Debug.Log(_message);
        }
    }
}
