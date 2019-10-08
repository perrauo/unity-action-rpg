using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


namespace Cirrus.DH
{
    public class Layers
    {
        //public int 
        public int ObjectsFlags = 1 << LayerMask.NameToLayer("Objects");
        public int LayoutFlags = 1 << LayerMask.NameToLayer("Layout");
        public int Objects = LayerMask.NameToLayer("Objects");
        public int Layout = LayerMask.NameToLayer("Layout");
    }

    public class Game : MonoBehaviour
    {
        private static Game _instance;

        public static Game Instance;

        public Layers Layers;

        [SerializeField]
        public Clock Clock;

        [SerializeField]
        public Controls.PlayerLobby Lobby;

        [SerializeField]
        public Controls.Player Player;

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

        public void Start()
        {

            Player.Enable();         
            
        }


        public void OnValidate()
        {

        }



    }
}
