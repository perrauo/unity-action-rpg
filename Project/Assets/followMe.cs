using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMe : MonoBehaviour
{
    [SerializeField]
    private Transform trans;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = trans.position;
    }
}
