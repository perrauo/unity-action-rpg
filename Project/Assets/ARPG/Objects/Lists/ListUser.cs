using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.ARPG.Objects
{
    public class ListUser : MonoBehaviour
    {
        [SerializeField]
        private List<Object> _lists;
       
        public void Awake()
        {
            var obj = GetComponent<BaseObject>();
            var lists = _lists.Cast<IList<BaseObject>>();
            foreach (var list in lists)
            {
                list.Add(obj);
            }
        }

        ~ListUser()
        {
            var obj = GetComponent<BaseObject>();
            var lists = _lists.Cast<IList<BaseObject>>();
            foreach (var list in lists)
            {
                list.Remove(obj);
            }
        }

    }
}
