using UnityEngine;
using System.Collections;
using Cirrus.Tags;
using System.Collections.Generic;
using System;

namespace Cirrus.ARPG.World.Objects
{
    public abstract class Persistence
    {
        //private Resource _resource;

        [SerializeField]
        [Editor.ReadOnly]
        public Vector3 _position;

        public abstract void OnLoadRoomContent(Room room);

        public Persistence(Resource resource)
        {
            //_resource = resource;
        }

        public void Awake()
        {
            //DontDestroyOnLoad(gameObject);
        }
    }
}