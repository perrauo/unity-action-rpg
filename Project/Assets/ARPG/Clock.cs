using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Cirrus.ARPG
{
    public class Clock : MonoBehaviour
    {
        public delegate void OnTick();
        public OnTick OnTickedHandler;

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
