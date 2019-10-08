using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.ARPG.World.Objects.Characters
{
    // TODO move some more stuff in here
    //  Resouce should help spawn the object like a factory

    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/Character")]
    public class Resource : Objects.Resource
    {
        [SerializeField]
        public Character _template;

        //[SerializeField]
        //public Actions.SkillPersistence _skillattributes;

        [SerializeField]
        public Attributes.AttributesResource _attributes;

        [SerializeField]
        public ARPG.Items.ItemInventoryResource _itemInventory;

        [SerializeField]
        public Actions.SkillInventoryResource _skillInventory;


        public override BaseObject Template {
            get
            {
                return _template;
            }
        }

        public Character Create(Room room, Persistence persistence)
        {
            Character chara = Instantiate(
                _template.gameObject,
                persistence._position,
                Quaternion.identity,
                room.transform).GetComponent<Character>();

            chara._room = room;
            chara._persistence = persistence;
            return chara;
        }

        public Persistence CreatePersistence()
        {
            return new Persistence(this, 
                _attributes.CreatePersistence(), 
                _skillInventory.CreatePersistence(), 
                _itemInventory.Persistence);
        }
    }
}