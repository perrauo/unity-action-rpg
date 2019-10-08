using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.ARPG.World.Objects.Characters.Actions
{
    // TODO : pool
    public class StatPopup : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _positionOffset;

        [SerializeField]
        private Numeric.RangeFloat _randomOffsetX;

        [SerializeField]
        private Numeric.RangeFloat _randomOffsetY;

        [SerializeField]
        private TMPro.TextMeshPro _text;

        [SerializeField]
        public float _timeLimit;

        private Timer _timer;

        public void Awake()
        {
            _timer = new Timer(_timeLimit, true);
            _timer.OnTimeLimitHandler += OnTimeLimit;
        }

        //public RectTransform rect
        //{
        //    get
        //    {
        //        return GetComponent<RectTransform>();
        //    }
        //}

        public void Update()
        {
            transform.rotation = (Quaternion.LookRotation(transform.position - World.Room.Instance.Camera.transform.position ));
               
        }

        public void Start()
        {
            transform.position += _positionOffset;
            transform.position += new Vector3(_randomOffsetX.Value, _randomOffsetY.Value);
        }

        public void OnTimeLimit()
        {
            Destroy(gameObject);
        }

        public StatPopup Create(BaseObject source, float delta)
        {
            var stat = Instantiate(this.gameObject, source.Transform).GetComponent<StatPopup>();
            stat._text.text = delta < 0 ? delta.ToString() : "+" + delta.ToString();
            return stat;
        }



    }
}