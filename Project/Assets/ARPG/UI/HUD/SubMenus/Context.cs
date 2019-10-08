using UnityEngine;
using System.Collections;


namespace Cirrus.ARPG.UI
{
    public class Context : MonoBehaviour
    {
        [SerializeField]
        public World.Objects.Characters.Character _character;

        // TODO whole party??
        public World.Objects.Characters.Character Character
        {
            get
            {
                return _character;
            }
        }


        [SerializeField]
        private InventoryObject _draggedObject;

        public InventoryObject DraggedObject
        {
            get
            {
                return _draggedObject;
            }
        }

        [SerializeField]
        private Slot _draggedSlot;

        public void Awake()
        {
            World.Room.OnCharacterStartStaticHandler += OnCharacterStart;   
        }

        public void OnCharacterStart(World.Objects.Characters.Character character)
        {
            _character = character;
        }


        public Slot DraggedObjectSource
        {
            get
            {
                return _draggedSlot;
            }
        }

        public void OnObjectBeginDrag(Slot slot, InventoryObject obj)
        {
            _draggedSlot = slot;
            _draggedObject = obj;
        }

        public void OnInventoryObjectDragEnd(Slot slot)
        {
            _draggedObject = null;
            _draggedSlot = null;
        }
    }
}