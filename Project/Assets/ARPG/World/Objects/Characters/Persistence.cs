using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects.Characters
{
    [System.Serializable]
    public class Persistence : Objects.Persistence
    {
        private Resource _resource;

        [SerializeField]
        [Editor.ReadOnly]
        private Attributes.AttributesPersistence _attributes;

        [SerializeField]
        [Editor.ReadOnly]
        private ARPG.Items.ItemInventoryPersistence _items;

        [SerializeField]
        [Editor.ReadOnly]
        private Actions.SkillInventoryPersistence _skills;


        public Persistence(
                Resource resource,
                Attributes.AttributesPersistence attributes,
                Actions.SkillInventoryPersistence skills,
                ARPG.Items.ItemInventoryPersistence items) : base(resource)
        {
            _resource = resource;
            _attributes = attributes;
            _skills = skills;
            _items = items;

        }


        public Attributes.AttributesPersistence Attributes
        {
            get
            {
                return _attributes;
            }
        }


        public ARPG.Items.ItemInventoryPersistence Items
        {
            get
            {
                return _items;
            }
        }

        public Actions.SkillInventoryPersistence Skills
        {
            get
            {
                return _skills;
            }
        }


        public void OnTransitionStatic(Room room)
        {
            Room.OnRoomStartStaticHandler -= OnTransitionStatic;
            _position = room.TransitionDestination.transform.position;
            Character chara = _resource.Create(room, this);
            room.Register(chara);

            Room.OnCharacterStartStaticHandler?.Invoke(chara);
        }

        public override void OnLoadRoomContent(Room room)
        {
            _resource.Create(room, this);
        }

    }


}