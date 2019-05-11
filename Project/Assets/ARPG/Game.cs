using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


namespace Cirrus.ARPG
{
    public class Layers
    {
        public int Objects = 1 << LayerMask.NameToLayer("Objects");
        public int Layout = 1 << LayerMask.NameToLayer("Layout");
    }

    public class Game : MonoBehaviour
    {
        public static Game Instance;

        public Layers Layers;


        [RuntimeInitializeOnLoadMethod] // Will exec, even if no GObjs
        static void OnRuntimeMethodLoad()
        {

        }

        [SerializeField]
        public Persistence Persistence;

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Layers = new Layers();
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }


        



        public void OnValidate()
        {
            if (Persistence == null)
            {
                Persistence = GetComponentInChildren<Persistence>();
            }

            //if (Clock == null)
            //{
            //    Clock = GetComponentInChildren<Time.Clock>();
            //}
        }



    }
}
