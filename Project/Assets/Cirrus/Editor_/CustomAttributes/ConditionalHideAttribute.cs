using UnityEngine;
using System;
using System.Collections;

namespace Cirrus.Editor
{

    //Original version of the ConditionalHideAttribute created by Brecht Lecluyse (www.brechtos.com)
    //Modified by: Sebastian Lague

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
        AttributeTargets.Class | AttributeTargets.Struct, Inherited = true, AllowMultiple = true)]
    public class ConditionalHideAttribute : PropertyAttribute
    {
        public bool isVisible;
        public bool leaveUnchangedOnFail;
        public string conditionalSourceField;
        public int[] enumIndices;
        public int enumValue = -1;
        public bool isEnumFlags;

        public ConditionalHideAttribute(string boolVariableName, bool isVisible = true, bool leaveUnchangedOnFail = true)
        {
            conditionalSourceField = boolVariableName;
            this.leaveUnchangedOnFail = leaveUnchangedOnFail;
            this.isVisible = isVisible;
        }

        public ConditionalHideAttribute(string enumVariableName, int[] enumIndices)
        {
            conditionalSourceField = enumVariableName;
            this.enumIndices = enumIndices;
            enumValue = -1;
        }

        // TODO
        public ConditionalHideAttribute(string enumVariableName, int enumValue, bool isEnumFlags = false, bool isVisible = true)
        {
            conditionalSourceField = enumVariableName;
            this.enumValue = enumValue;
            this.isEnumFlags = isEnumFlags;
            this.isVisible = isVisible;


        }
    }

}