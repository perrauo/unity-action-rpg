using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPersistence2 : MonoBehaviour
{
    [SerializeField]
    private NewBehaviourScript1 so;

    public void Awake()
    {
        Debug.Log("Awake 2");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            so.Value = 5;
        }


    }
}
