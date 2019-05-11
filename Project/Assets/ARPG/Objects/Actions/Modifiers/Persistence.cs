using UnityEngine;
using System.Collections;

// TODO handle same effect persistent twice (Stack?)


namespace Cirrus.ARPG.Objects.Actions.Modifiers
{
    public delegate void OnPersistenceEnded();

    [System.Serializable]
    public abstract class Persistence : ScriptableObject
    {
         public abstract void SetPersistence(Modifier.Product product);
    }
}