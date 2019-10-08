using UnityEngine;
using System.Collections;
using Cirrus.ARPG.Conditions;

namespace Cirrus.ARPG.World.Objects.Conditions
{
    public delegate void OnListened(BaseObject target, params object[] args);

    public class ObjectListener// : BaseListener
    {
        public OnListened OnObjectListenedHandler;

        protected BaseObject _target;

        public ObjectListener(BaseObject target)
        {
            _target = target;
            _target.AddListener(this);
        }

        ~ObjectListener()
        {
            _target.RemoveListener(this);
        }

    }

}
