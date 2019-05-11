using Cirrus.ARPG.Objects.Characters.Controls.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Objects.Characters;
using Cirrus.ARPG.Actions;
using Cirrus.ARPG.Objects.Attributes;
using Cirrus.ARPG.Objects.Characters;
using Cirrus.Tags;

namespace Cirrus.ARPG.Objects.Actions
{
    [CreateAssetMenu(menuName = "Cirrus/Objects/Actions/Effects/Update Inventory")]
    public class UpdateInventoryEffect : BaseEffect
    {
        [SerializeField]
        private bool _isItemTransfer = false;

        [Editor.ConditionalHide("_isItemTransfer", isVisible = true)]
        [SerializeField]
        private bool _isAllOrNothing;

        [Editor.ConditionalHide("_isItemTransfer", isVisible = true)]
        [SerializeField]
        public List<Tag> _tags;

        [Editor.ConditionalHide("_isItemTransfer", isVisible = false)]
        [SerializeField]
        public List<Characters.Actions.Ability> _items;

        private void DoApply2(Character target)
        {
            foreach (var item in _items)
            {
                target.InventoryUser.TryStore(item);
            }
        }

        // TODO: Handle not destroying the object if condition not satisfied

        // TRANSFER THE ITEM IF EXISTS IN FIRST GUY's inv
        protected override void DoApply(Character source, Character target)
        {
            if (_isItemTransfer)
            {
                // TODO Give item to other character
            }
            else
            {
                DoApply2(target);
            }
        }

        // JUST GIVE THE ITEM
        protected override void DoApply(Character target)
        {
            if (_isItemTransfer)
                return;

            DoApply2(target);
        }

    }
}