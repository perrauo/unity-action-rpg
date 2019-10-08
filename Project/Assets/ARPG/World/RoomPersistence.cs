using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.World.Objects;
using UnityEngine;

namespace Cirrus.ARPG.World
{
    // TODO make regular class

    public class RoomPersistence
    {
        private List<Persistence> _objects;

        private OnRoomEvent OnLoadRoomContent;

        private Tags.Tag _tag;

        public int Id
        {
            get
            {
                return _tag.GetInstanceID();
            }
        }

        public RoomPersistence(Tags.Tag tag)
        {
            _tag = tag;
            _objects = new List<Persistence>();
        }

        public void Add(Persistence obj)
        {
            OnLoadRoomContent += obj.OnLoadRoomContent;
            _objects.Add(obj);
        }

        public void Remove(Persistence obj)
        {
            OnLoadRoomContent -= obj.OnLoadRoomContent;
            _objects.Remove(obj);
        }

        public void LoadContent(Room room)
        {
            OnLoadRoomContent?.Invoke(room);
        }        
    }
}