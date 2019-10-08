using UnityEngine;
using System.Collections;
using System;
using Cirrus.ARPG.World.Objects.Characters;

namespace Cirrus.ARPG.UI
{
    public abstract class SubMenu : MonoBehaviour
    {
        protected bool _enable = false;

        public bool Enabled
        {
            get
            {
                return _enable;
                //gameObject.SetActive()
            }

            set
            {
                _enable = value;
                gameObject.SetActive(_enable);
            }
        }

        public virtual void HandleAction(int idx) { }

        public virtual  void Move(Vector2Int movement)
        {

        }

        public virtual void Open()
        {

        }

        public virtual void Close()
        {

        }
    }

    public class Menu : MonoBehaviour
    {
        protected bool _enabled = false;

        public bool Enabled
        {
            get
            {
                return _enabled;
            }

            set
            {
                _enabled = value;
                gameObject.SetActive(_enabled);
            }
        }


        [SerializeField]
        private MenuOption[] _options;

        [SerializeField]
        private SubMenu[] _subMenus;

        [SerializeField]
        private SubMenu _activeMenu;

        public void OnValidate()
        {
            if (_options.Length == 0)
                _options = GetComponentsInChildren<MenuOption>();

            if (_subMenus.Length == 0)
                _subMenus = GetComponentsInChildren<SubMenu>();
        }

        private bool _init = false;

        public void Awake()
        {
            Enabled = false;
        }

        public virtual void OnEnable()
        {
            if (_init)
                return;

            _init = true;

            foreach (MenuOption opt in _options)
            {
                opt.OnSelectedHandler += OnMenuSelected;
            }


            foreach (SubMenu m in _subMenus)
            {
                m.Enabled = false;//.OnSelectedHandler += OnMenuSelected;
            }
        }

        public void Open()
        {
            if (_activeMenu == null)
            {
                OnMenuSelected(0);
            }
            else
            {

                _activeMenu.Open();
            }
        }

        public void CycleSubmenus(int direction)
        {
            
        }

        public void Move(Vector2Int movement)
        {
            if (_activeMenu == null)
                OnMenuSelected(0);

            _activeMenu.Move(movement);
        }


        public void OnMenuSelected(int idx)
        {
            if (_subMenus.Length == 0)
                return;

            if (_activeMenu != null)
            {
                _activeMenu.Close();
                _activeMenu.Enabled = false;                
            }

            _activeMenu = _subMenus[idx];
            _activeMenu.Enabled = true;
            _activeMenu.Open();
        }


        public void HandleAction(int idx)
        {
            _activeMenu.HandleAction(idx);
            
        }
    }
}