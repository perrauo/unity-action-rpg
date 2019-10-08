using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.World.Objects.Items.Collectibles
{
    public class CollectiblePersistence : Persistence
    {
        private CollectibleResource _resource;
          

        public CollectiblePersistence(CollectibleResource resource) : base(resource)
        {
            _resource = resource;// _objectTemplate = objectTemplate;
        }

        public override void OnLoadRoomContent(Room room)
        {
            _resource.Create(room, this);
        }

    }
}
