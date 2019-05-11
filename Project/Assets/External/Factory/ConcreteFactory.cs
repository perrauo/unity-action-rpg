using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteFactory : MonoBehaviour, iFactory
{
    [SerializeField]
    GameObject mainPrefab;
    [SerializeField]
    GameObject childPrefab;

    public GameObject FactoryMethod(object[] parameters)
    {
        GameObject mainObject = Instantiate(mainPrefab);
        int amount = (int)parameters[0];
        for (int i = 0; i < amount; i++)
        {
            GameObject childObject = Instantiate(childPrefab);
            childObject.transform.parent = mainObject.transform;
        }
        return mainObject;
    }
}
