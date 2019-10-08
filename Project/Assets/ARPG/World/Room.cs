

// This is where we handle Goals to lock/unlock doors

using Cirrus.ARPG.World.Objects;
using Cirrus.Tags;
using System;
using System.Collections.Generic;
using UnityEngine;
//using Cirrus.ARPG.Goals;

namespace Cirrus.ARPG.World
{
    public delegate void OnRoomEvent(Room room);

    public class Room : MonoBehaviour
    {
        [SerializeField]
        public Tag Tag;

        [SerializeField]
        private Transform _objectsParent;
        
        public RoomPersistence _persistence;

        [SerializeField]
        public RoomTransition[] _transitions;

        [SerializeField]
        public Cameras.CameraWrapper Camera = null;

        [SerializeField]
        private RoomStart _roomStart;

        public static Room Instance { get; private set; }

        public static OnRoomEvent OnRoomStartStaticHandler;

        public static OnRoomEvent OnRoomAwakeStaticHandler;

        public static World.Objects.Characters.OnCharacterEvent OnCharacterDiesStaticHandler;

        public static World.Objects.Characters.OnCharacterEvent OnCharacterStartStaticHandler;
        
        public void OnValidate()
        {
            if (_roomStart == null)
            {
                _roomStart = FindObjectOfType<RoomStart>();
            }

            if (_transitions.Length == 0)
            {
                _transitions = GetComponentsInChildren<RoomTransition>();
            }

            if (Camera == null)
            {
                Camera = FindObjectOfType<Cameras.CameraWrapper>();
            }

        }

        private bool _isRegistering = false;

        public bool IsRegistering
        {
            get
            {
                return _isRegistering;
            }
        }

        public void Register(BaseObject obj)
        {
            _persistence.Add(obj.Persistence);
        }

        public void Unregister(BaseObject obj)
        {
            _persistence.Remove(obj.Persistence);            
        }

        public RoomTransition TransitionDestination
        {
            get
            {
                foreach (RoomTransition transition in _transitions)
                {
                    if (transition.Tag.GetInstanceID() == Level.Destination.GetInstanceID())
                        return transition;
                }

                return null;
            }
        }

        public void Awake()
        {
            Instance = this;

            if (!Level.Instance.TryGetPersistence(this, out _persistence))
            {
                _persistence = new RoomPersistence(Tag);// (_persistenceTemplate);
                Level.Instance.Add(_persistence);
                _isRegistering = true;
            }
            else
            {                
                DestroyImmediate(_objectsParent.gameObject);
                _persistence.LoadContent(this);
                _isRegistering = false;
            }

            OnRoomAwakeStaticHandler?.Invoke(this);
        }

        public void Start()
        {
            OnRoomStartStaticHandler?.Invoke(this);
        }

        public bool TryGet(Tags.Tag tag, out BaseObject obj)
        {
            obj = null;
            return false;      
        }
    }
}