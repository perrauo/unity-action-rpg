using UnityEngine;
using System.Collections;

namespace Cirrus.DH
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField]
        private Game _game;

        [SerializeField]
        public World.Level _level;

        //[SerializeField]
        //public UI.HUD _hud;

        public void Awake()
        {
            if (Game.Instance == null)
                Instantiate(_game.gameObject);

            if(World.Level.Instance == null)
                Instantiate(_level.gameObject);

            //if (UI.HUD.Instance == null)
            //    Instantiate(_hud.gameObject);
        }

    }
}
