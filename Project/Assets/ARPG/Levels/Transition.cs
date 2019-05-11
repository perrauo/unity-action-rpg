using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;
//using Uti

namespace Cirrus.ARPG.Levels
{
    public delegate void OnTransition(IEnumerable<Objects.Characters.Character> characters);

    public class Transition : MonoBehaviour
    {
        [SerializeField]
        private bool _isStart = false;

        [Header("Please make sure to drag a '.unity' scene, I can't really enforce it compile time")]
        [SerializeField]
        private Object _scene;

        [Editor.ReadOnly]
        [SerializeField]
        private string _scenePath = "";

        [Editor.Required]
        [SerializeField]
        public Tags.Tag Tag;

        [SerializeField]
        private List<GameObject> _characters;

        public OnTransition OnTransitionHandler;

        private IEnumerable<Objects.Characters.Character> Characters
        {
            get {
               return _characters.Select(x => x.GetComponentInChildren<Objects.Characters.Character>());
            }
        }

        [SerializeField]
        private float _transitionDetectionTime = 1f;

        private Timer _timer;

        private bool _isDetecting = false;


        // NOTE: Listen calls should be in OnEnable for objects using DontDestroyOnLoad(); to work.
        public void OnEnable()
        {
            _timer = new Timer(_transitionDetectionTime, false, false);
            _timer.OnTimeLimitHandler += OnTimeLimit;
            _timer.Start();

        }

        public void OnTimeLimit() {

            _isDetecting = true;
        }


        public void OnTriggerStay(Collider other)
        {
            if (_isDetecting)
            {
                var character = other.GetComponent<Objects.Characters.Character>();
                if (character != null)
                {
                    if (_scene != null)
                    {
                        Level.Instance.LoadRoom(_scenePath, Tag);
                    }
                }
            }
        }

        public void Kill()
        {
            foreach (var c in Characters)
            {
                // TODO
                Destroy(c.transform.parent.gameObject);
            }
        }

        public bool Init()
        {
            bool transition = true;
            if (Level.Instance.Destination == null || Tag == null)
            {
                transition = false;
            }
            else
            {
                transition = Tag.GetInstanceID() == Level.Instance.Destination.GetInstanceID();
            }

            Objects.Characters.Character focus = null;

            foreach (var c in Characters)
            {
                if (c == null)
                    continue;

                if (_isStart && Level.Instance.CanStart)
                {
                    if (focus == null)
                        focus = c;

                    Level.Instance.CanStart = false;

                    Game.Instance.Persistence.Add(c.Persistence);
                }
                else if (transition)
                {
                    if (Game.Instance.Persistence.TryGetCharacter(c.Persistence.Tag, out var persistence))
                    {
                        if (focus == null)
                            focus = c;

                        c.Persistence.Set(persistence);
                    }
                }
                else
                {
                    // TODO
                    Destroy(c.transform.parent.gameObject);
                    return false;
                }
            }


            OnTransitionHandler?.Invoke(Characters);
            return true;
        }


        public void OnValidate()
        {
            if(_scene != null)
            _scenePath = AssetDatabase.GetAssetPath(_scene.GetInstanceID());
        }

    }

}
