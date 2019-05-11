using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Objects.Elements
{
    /// <summary>
    /// Elemental type may impact damage (more damage on opposite type, also healing more healing on same type)
    /// </summary>
    public enum Element
    {
        Fire, 
        Water,
        Grass,
        Electricity
    }

    public class Elemental : MonoBehaviour
    {

    }

}