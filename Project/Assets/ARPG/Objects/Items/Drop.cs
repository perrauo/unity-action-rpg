using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cirrus.ARPG.Objects.Items.Collectibles
{
    public class Drop : MonoBehaviour
    {
        public struct Dropped
        {
            public Collectibles.Collectible Collect;
            public Vector3 Dest;
        }

        [System.Serializable]
        public class RandomDrop
        {
            [SerializeField]
            public Numeric.Chance Chance;

            [SerializeField]
            public Numeric.RangeInt Count;

            [SerializeField]
            public bool _isRepeated = true;

            [SerializeField]
            public Collectible[] _choices;

            private Collectible _choice;

            public Collectible Choose()
            {
                if (_choice == null || !_isRepeated)
                {
                    int min = 0;
                    int max = _choices.Length - 1;
                    _choice = _choices[Random.Range(min, max)];
                }

                return _choice;      
            }
        }

        [SerializeField]
        private List<RandomDrop> _randomDrops;

        [SerializeField]
        private  Numeric.RangeInt _radiusRange;

        [SerializeField]
        private AnimationCurve _curve;

        private float _animationTime = 0;

        private Vector3 _startPos;

        private List<Dropped> _collectibles;

        private int _finished = 0;

        public void Start()
        {
            if (_randomDrops.Count == 0)
                return;

            _startPos = transform.position;
            _collectibles = new List<Dropped>();

            foreach (var randomDrop in _randomDrops)
            {        
                for (int i = 0; i < randomDrop.Count.Value; i++)
                {
                    DoDrop(randomDrop.Choose());
                }
            }           
        }

        public void DoDrop(Collectible prefab)
        {
            var newcol = Instantiate(prefab, _startPos, Quaternion.identity);
            Dropped s = new Dropped();
            var v = Random.insideUnitCircle * _radiusRange.Value;
            s.Dest = new Vector3(_startPos.x + v.x, _startPos.y, _startPos.z +  v.y);
            s.Collect = newcol;
            _collectibles.Add(s);
        }

        public void Update()
        {
            if (_finished == _collectibles.Count)
            {
                Destroy(gameObject);
                return;
            }

            _animationTime += UnityEngine.Time.deltaTime;
            foreach (var s in _collectibles)
            {
                if (s.Collect == null)
                    continue;

                float value = _curve.Evaluate(_animationTime);
                s.Collect.transform.position = Vector3.Lerp(_startPos, s.Dest, value);

                if (Cirrus.Utils.Vectors.CloseEnough(s.Collect.transform.position, s.Dest))
                {
                    _finished++;
                }
            }

        }


        public void OnValidate()
        {
            _randomDrops = _randomDrops.OrderBy(x => -x.Chance.Probability).ToList();
        }
    }
}
