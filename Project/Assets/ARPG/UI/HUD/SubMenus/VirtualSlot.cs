using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Items;

namespace Cirrus.ARPG.UI
{

    public class VirtualSlot
    {
        public World.Objects.Characters.Actions.SceneSkill Ability;

        public World.Objects.Characters.Actions.AbilityType Preference;

        protected InventoryUser _user;

        public bool IsEmpty
        {
            get
            {
                return Ability == null;
            }
        }


        public virtual void SetUser(InventoryUser user)
        {
            _user = user;
        }


        public VirtualSlot(World.Objects.Characters.Actions.AbilityType preference= World.Objects.Characters.Actions.AbilityType.Unknown)
        {
            Preference = preference;
        }

        public virtual void Store(World.Objects.Characters.Actions.SceneSkill item)
        {
            Ability = item;
        }

        public virtual void Clear()
        {
            Ability = null;
        }
    }

}