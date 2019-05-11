using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Objects.Attributes;
using System.Collections.Generic;
using Cirrus.Tags;

namespace Cirrus.ARPG.Objects.Attributes
{
    public class AttributesPersistence : MonoBehaviour
    {
        [System.Serializable]
        public class StatDisplay
        {
            [Editor.ReadOnly]
            [SerializeField]
            public string Name;

            [SerializeField]
            [Editor.ReadOnly]
            public float Current;

            [SerializeField]
            [Editor.ReadOnly]
            public float Total;

            [SerializeField]
            [Editor.ReadOnly]
            public float Ratio;

            public void OnStatChanged(Stat.Product stat)
            {
                Current = stat.Current;
                Total = stat.Total;
                Name = stat.attribute.name;

                if (stat.Total > 0)
                {
                    Ratio = stat.Current / stat.Total;
                }
            }
        }

        [SerializeField]
        private List<StatDisplay> _displays;

        [Space]
        [SerializeField]
        public StringDetail Name;

        protected Dictionary<int, Stat.Product> stats;

        protected Stat.Product AddStat(Stat stat)
        {
            Debug.Assert(stat != null, "Please dont leave the '{}' stat empty.".Replace("{}", stat.name));
            var repr = new Stat.Product(stat);
            stats.Add(repr.Tag.GetInstanceID(), repr);

            var display = new StatDisplay();
            repr.OnCurrentChangedHandler += display.OnStatChanged;
            repr.OnTotalChangedHandler += display.OnStatChanged;
            _displays.Add(display);
            display.OnStatChanged(repr);

            return repr;
        }

        public virtual void Awake()
        {
            stats = new Dictionary<int, Stat.Product>();
        }
 
        // TODO: GetStat(StatType type)
        public Stat.Product GetStat(Tag stat)
        {
            Stat.Product st;

            if (stats.TryGetValue(stat.GetInstanceID(), out st))
                return st;

            return null;
        }


    }
}
