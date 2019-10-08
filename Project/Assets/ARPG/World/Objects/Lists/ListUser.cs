using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.ARPG.World.Objects
{
    public class ListUser : MonoBehaviour
    {
        [SerializeField]
        private List<Object> _lists;
       
        public void Awake()
        {
            var obj = GetComponent<BaseObject>();
            


            //var lists = _lists.Cast<IList<BaseObject>>();
            foreach (var list in _lists)
            {
                if (list == null)
                    continue;

                var l = list as IList<BaseObject>;

                l.Add(obj);
            }
        }

        ~ListUser()
        {
            var obj = GetComponent<BaseObject>();
            foreach (var list in _lists)
            {
                //list.Remove(obj);
                if (list == null)
                    continue;

                var l = list as IList<BaseObject>;

                l.Remove(obj);
            }
        }

    }
}
