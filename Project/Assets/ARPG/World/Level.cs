using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


namespace Cirrus.ARPG.World
{
    public class Level : MonoBehaviour
    {
        public static Level Instance;

        public static Tags.Tag Destination { get; private set; }

        public Dictionary<int, RoomPersistence> _rooms;

        public void Awake()
        {
            _rooms = new Dictionary<int, RoomPersistence>();
            // Dont destroy on load must be at the root 
            Instance = this;            
            DontDestroyOnLoad(gameObject);            
        }

        public bool TryGetPersistence(Room room, out RoomPersistence persistence)
        {
            return _rooms.TryGetValue(
                room.Tag.GetInstanceID(), 
                out persistence);
        }

        public void Add(RoomPersistence room)
        {
            _rooms.Add(room.Id, room);
        }
        
        public void LoadRoom(string scenePath, Tags.Tag destinationTag)
        {
            Destination = destinationTag;
            SceneManager.LoadScene(scenePath);            
        }
    }

}