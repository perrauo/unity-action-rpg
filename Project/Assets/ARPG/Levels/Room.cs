

// This is where we handle Goals to lock/unlock doors

using Cirrus.ARPG.Objects;
using System.Collections.Generic;
using UnityEngine;
//using Cirrus.ARPG.Goals;

namespace Cirrus.ARPG.Levels
{
    public delegate void OnRoomLoaded(Room room);


    public class Room : MonoBehaviour
    {
        // TODO : OnEnabled, delegate dont destory on load etc.
        [SerializeField]
        public Clock Clock;

        [SerializeField]
        public Playable.Controls.PlayerLobby Lobby;

        //[SerializeField]
        //public Level Level;

        [SerializeField]
        public RoomPersistence Persistence;

        [SerializeField]
        public List<Transition> _transitions;

        [SerializeField]
        public Cameras.CameraFollow Camera = null;


        public static Room Instance { get; private set; }

        public static OnRoomLoaded OnRoomLoadedHandler;
 
        public void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void Start()
        {
            foreach (var trans in _transitions)
            {
                if (trans == null)
                    continue;

                trans.OnTransitionHandler += OnTransition;
                trans.Init();
            }

            OnRoomLoadedHandler.Invoke(this);
        }


        public void OnTransition(IEnumerable<Objects.Characters.Character> characters)
        {
            foreach (var c in characters)
            {
                InitializePlayer(c);
            }
        }

        public void InitializePlayer(Objects.Characters.Character character)
        {
            Camera.RegisterTarget(character);
            character.Controller.SetEnabled();
        }

    }
}