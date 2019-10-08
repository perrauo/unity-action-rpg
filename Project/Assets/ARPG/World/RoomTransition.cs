using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;
//using Uti

namespace Cirrus.ARPG.World
{
    public delegate void OnTransition(IEnumerable<Objects.Characters.Character> characters);

    public class RoomTransition : MonoBehaviour
    {
        [Editor.Required]
        [SerializeField]
        public Tags.Tag Tag;

        [SerializeField]
        private Room _room;

        [Header("Please make sure to drag a '.unity' scene, I can't really enforce it compile time")]
        [SerializeField]
        private Object _scene;

        [Editor.ReadOnly]
        [SerializeField]
        private string _scenePath = "";

        [SerializeField]
        private List<Objects.Characters.Character> _detected;

        [SerializeField]
        private Objects.ColliderListener _colliderListener;

        public OnTransition OnTransitionHandler;

        [SerializeField]
        private float _detectionDelay = 5f;

        private Timer _timer;

        private bool _isDetecting = false;


        public void OnValidate()
        {
#if UNITY_EDITOR
            if (_scene != null)
            {
                _scenePath = AssetDatabase.GetAssetPath(_scene.GetInstanceID());
            }
#endif

            if (_room == null)
            {
                _room = FindObjectOfType<Room>();
            }
        }



        public void Awake()
        {
            _timer = new Timer(_detectionDelay, false, false);
            _timer.OnTimeLimitHandler += OnTimeLimit;
            _timer.Start();

            _colliderListener.OnTriggerEnterHandler += OnListenerTriggerEnter;
            _colliderListener.OnTriggerExitHandler += OnListenerTriggerExit;
        }

        public void OnTimeLimit() {

            _isDetecting = true;
        }

        public void Update()
        {
            if (_isDetecting)
            {
                if (_detected.Count != 0)
                {
                    foreach (Objects.Characters.Character character in _detected)
                    {
                        _room.Unregister(character);

                        Room.OnRoomStartStaticHandler += 
                            character.CharacterPersistence.OnTransitionStatic;
                    }

                    Level.Instance.LoadRoom(_scenePath, Tag);
                }
            }
        }

        public void OnListenerTriggerEnter(Collider other)
        {
            var character = other.GetComponentInParent<Objects.Characters.Character>();
            if (character != null)
            {
                if (character.IsHuman)
                {
                    _detected.Add(character);
                }
            }
        }

        public void OnListenerTriggerExit(Collider other)
        {
            var character = other.GetComponentInParent<Objects.Characters.Character>();
            if (character != null)
            {
                if (character.IsHuman)
                {
                    _detected.Remove(character);
                }
            }
        }

    }

}
