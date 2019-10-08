using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TestPersistenceCtrl : MonoBehaviour
{
    [SerializeField]
    private NewBehaviourScript1 so;

    private void Awake()
    {
        Debug.Log("Awake 1");

        DestroyImmediate(transform.GetChild(0).gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        so = Instantiate(so);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("New Scene");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(so.Value);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            so.Value = 15;
            //Debug.Log(so.Value);
        }
    }
}
