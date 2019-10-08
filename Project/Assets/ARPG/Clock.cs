using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Cirrus.DH
{
    public class Clock : MonoBehaviour
    {
        public OnEvent OnTickedHandler;

        public void Update()
        {
            OnTickedHandler?.Invoke();//
        }
        // TODO: in order to move clock to cirrus.
        //public CreateTimer(float limit, bool start = true, bool repeat = false)
        //{

        //}

    }
}
