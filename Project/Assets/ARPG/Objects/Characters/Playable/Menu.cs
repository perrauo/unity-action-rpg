//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Linq;
//using System;

//namespace Cirrus.ARPG.UI
//{
//    //TODO pick action: key name small in corner of action icon : press escape then key to map the key
//    //

//    public class Menu : MonoBehaviour
//    {
//        //contextually populate
//        private IButtonContext buttonContextCache;
//        private Misc.DataStructures.DoublyLinkedList.List<Icon> buttons;
//        private Misc.DataStructures.DoublyLinkedList.Node<Icon> currentButton;

//        private GameObject cursor;

//        private Actions.Action previousSelected;


//        [SerializeField]
//        private GameObject AbilityIconPrefab;

//        [SerializeField]
//        private GameObject cursorPrefab;


//        [SerializeField]
//        private GameObject navigationButtonPrefab;

//        [SerializeField]
//        private Transform buttonsParent;


//        [SerializeField]
//        private List<GameObject> staticButtons;


//        [SerializeField]
//        public Cirrus.ARPG.Controls.Controller Controller;

//        public bool IsActive = false;

//        private Objects.Characters.Character character;


//        private void Start()
//        {
//            buttons = new Misc.DataStructures.DoublyLinkedList.List<Icon>();
//            Controller.onLeftPressed += OnLeftPressed;
//            Controller.onRightPressed += OnRightPressed;
//            Controller.OnMenuReleasedEvent += OnMenuReleased;
//         }

//        public void OnMenuReleased()
//        {
//            character.ExitActionMenu();
//            Exit();
//        }

//        public void OnLeftPressed()
//        {
//            ScrollHorizontal(-1);
//        }

//        public void OnRightPressed()
//        {
//            ScrollHorizontal(1);
//        }



//        public void ScrollHorizontal(int move)
//        {
//            if (buttons.Empty())
//                return;

//            var previousAbilityIcon = currentButton.Data as AbilityIcon;

//            if (move > 0)
//            {
//                currentButton = currentButton.Next == null ? buttons.Head : currentButton.Next;
//                cursor.transform.SetParent(currentButton.transform, false);
//            }
//            else if (move < 0)
//            {
//                currentButton = currentButton.Previous == null ? buttons.Tail : currentButton.Previous;
//                cursor.transform.SetParent(currentButton.transform, false);    
//            }
//        }


//        public AbilityIcon AddAbilityIcon(Actions.Action action)
//        {
//            GameObject gobj = Instantiate(AbilityIconPrefab, buttonsParent);
//            AbilityIcon AbilityIcon = gobj.GetComponent<AbilityIcon>();
//            //AbilityIcon.action = action;
//            //AbilityIcon.Context = action;

//            //actionBtton.icon = action.Icon .. setrenderer. .. 
//            buttons.PushBack(AbilityIcon);
//            return AbilityIcon;

//        }

//        public void Enter(Actions.Actor actor)
//        {
//            IsActive = true;
//            Controller.Enable();
//            this.character = character;

//            bool cursorPlaced = false;

//            // Add action buttons
//            foreach (var action in actor.Actions)
//            {
//                if (action == null)
//                    continue;

//                var button = AddAbilityIcon(action);
//                // prioritize placing cursor on enabled action
//                if (!cursorPlaced && buttonContextCache == action)
//                {
//                    cursorPlaced = true;
//                    PlaceCursor(button);
//                }


//                if (!action.IsAvailable)
//                {
//                    button.Disable();
//                }


//            }


//            foreach (var gobj in staticButtons)
//            {
//                if (gobj == null)
//                    continue;

//                gobj.transform.SetAsLastSibling(); //push at the end of the list

//                var button = gobj.GetComponent<Icon>();
//                buttons.PushBack(button);
//                button.gameObject.SetActive(true);

//                if (!cursorPlaced && buttonContextCache == button.Context)
//                {
//                    cursorPlaced = true;
//                    PlaceCursor(button);
//                }

//            }


//            // place cursor if none enabled
//            if (!cursorPlaced && !buttons.Empty())
//            {
//                PlaceCursor(buttons.Head.Data);
//            }

//        }

//        public void PlaceCursor(Misc.DataStructures.DoublyLinkedList.Node<Icon> button)
//        {
//            cursor = Instantiate(cursorPrefab, button.gameObject.transform);
//            currentButton = button;

//        }

//        public void PlaceCursor(Icon button)
//        {
//            cursor = Instantiate(cursorPrefab, button.gameObject.transform);
//            for (var b = buttons.Head; b != null; b = b.Next)
//            {
//                if (b.Data == button)
//                {
//                    currentButton = b;
//                    break;
//                }
//            }
//        }

//        public void Exit()
//        {
//            IsActive = false;
//            character = null;


//            if (currentButton != null)
//            {
//                buttonContextCache = currentButton.Context;
//            }


//            if (!buttons.Empty())
//            {
//                for (var i = buttons.Head; i != null; i = i.Next)
//                {
//                    if (i.IsStatic)
//                    {
//                        i.gameObject.SetActive(false);
//                    }
//                    else
//                    {
//                        // Clear tasks arrow
//                        AbilityIcon ab = i.Data as AbilityIcon;
//                        Destroy(i.gameObject);
//                        i.Data = null;                    
//                    }

//                }

//            }

//            if (cursor)
//            {
//                Destroy(cursor);
//            }

//            currentButton = null;
//            buttons.Clear();
//            Controller.Disable();
            
            
 
//        }



//    }

//}