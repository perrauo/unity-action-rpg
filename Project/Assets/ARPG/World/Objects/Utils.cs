using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.ARPG.World.Objects
{
    public static class Utils
    {
        // TODO: do not duplicate
        // FLATTEN A LIST OF LISTS which may contain individual too
        public static IEnumerable<BaseObject> Flatten(IEnumerable<Object> objects)
        {
            List<BaseObject> all = new List<BaseObject>();

            foreach (Object obj in objects)
            {
                if (obj == null)
                    continue;

                if (obj is GameObject)
                {
                    BaseObject bobj = (obj as GameObject).GetComponent<BaseObject>();
                    if (bobj != null)
                    {
                        all.Add(bobj);
                    }
                }
                else if(obj is IEnumerable<BaseObject>)
                {
                    all.AddRange((obj as IEnumerable<BaseObject>).Where(x => x != null));                   
                }
            }

            return all;


        }


    }
}