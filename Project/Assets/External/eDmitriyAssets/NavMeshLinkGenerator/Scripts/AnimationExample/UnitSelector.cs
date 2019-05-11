using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class UnitSelector : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;




    void Update()
    {
        if(UnityEngine.Input.GetMouseButtonDown( 0 ) )
        {
            Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition );
            RaycastHit hit;

            if(Physics.Raycast( ray, out hit ) )
            {
                if(navMeshAgent != null )
                {
                    navMeshAgent.SetDestination( hit.point );
                    //navMeshAgent.GetComponent< Agent >().LookAtPos = hit.point;
                }
            }
        }
    }


}
