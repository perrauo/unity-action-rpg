using UnityEngine;
using System.Collections;
using Cirrus.Editor;

namespace Cirrus.ARPG.Objects.Characters.Actions
{
    public class Resource : ScriptableObject
    {
        [SerializeField]
        public Sprite Icon;

        [Header("Do not write here for now. Probably will get lost.")]
        [TextArea]
        public string Description;

        [SerializeField]
        public Objects.Actions.Action Action;

        [SerializeField]
        public bool IsConditional = false;

        [ConditionalHide("IsConditional", isVisible =true)]
        [SerializeField]
        public DH.Conditions.BaseCondition Condition;

        [SerializeField]
        public float MaxCooldown = 5;

        //  Refers to the period of time between an action being inputted and the action having an effect.
        [SerializeField]
        public float StartLag = 2;

        // Refers to the period of time between an action's effect finishing and the player being able to input another action
        [SerializeField]
        public float EndLag = 2;
    }
}
