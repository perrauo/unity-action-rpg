using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryUser : MonoBehaviour
{
    [SerializeField]
    iFactory thisWontSerialize;
    [SerializeField]
    MonoBehaviour Factory;
    iFactory factory { get { return Factory as iFactory; } }

    public void OnValidate()
    {
        if (!(Factory is iFactory))
        {
            Debug.LogError("Wrong reference type");
            Factory = null;
        }
    }

    public void Start()
    {
        object[] parameters = new object[1];
        parameters[0] = 2;
        factory.FactoryMethod(parameters);
    }
}
