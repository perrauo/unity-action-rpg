using UnityEngine;
using System.Collections;


namespace Cirrus.ARPG.Conditions
{
    public delegate void OnStateChanged(IState state, params object[] args);

    public interface IState
    {
        OnStateChanged OnStateChangedHandler { get; set; }
    }
}