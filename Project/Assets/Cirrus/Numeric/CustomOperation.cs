using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;

namespace Cirrus.Numeric
{
    [System.Serializable]
    public struct Variable
    {
        public string Name;

        public FlexibleNumber Number;
    }

    [CreateAssetMenu(menuName = "Cirrus/Numeric/Operations/Custom")]
    public class CustomOperation : Operation
    {
        [SerializeField]
        private string _currentVariableName = "CURRENT";

        [SerializeField]
        private string _totalVariableName = "TOTAL";

        [SerializeField]
        private List<Variable> _variables;

        [SerializeField]
        private string _expression = "CURRENT + 2";

        public override float Evaluate(float current, float total)
        {
            string resolved =
            _expression
                .Replace(_currentVariableName, current.ToString())
                .Replace(_totalVariableName, total.ToString());

            foreach (var variable in _variables)
            {
                resolved = resolved.Replace(variable.Name, variable.Number.Value.ToString());
            }

            return (float)Convert.ToDouble(new DataTable().Compute(resolved, null));
        }

    }

}
