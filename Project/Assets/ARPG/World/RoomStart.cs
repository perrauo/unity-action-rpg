using Cirrus.ARPG.World.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cirrus.ARPG.World
{
    public class RoomStart : MonoBehaviour
    {
        //public static OnCharacterStart OnCharacterStartHandler;

        // TODO: Character are shared party information via scriptable objects (Edit time)
        // TODO: Check if characters already exist
        [SerializeField]
        private Room _room;

        public void OnValidate()
        {
            if(_room == null)
                _room = FindObjectOfType<Room>();
        }

        [SerializeField]
        private Objects.Characters.Character[] _characters;

        [SerializeField]
        private float _multipleOffsetSize = 4f;

        private float _multipleAngleBetween = 30f;


        // Start is called before the first frame update
        public void Start()
        {
            float angle = 0;

            float offset = _characters.Length == 1 ? 0 : _multipleOffsetSize;

            foreach (Objects.Characters.Character character in _characters)
            {
                Vector2 positionXY = new Vector2(
                    Mathf.Sin(angle * Mathf.Deg2Rad), 
                    Mathf.Cos(angle * Mathf.Deg2Rad));

                Vector3 positionxyz = new Vector3(
                    transform.position.x + positionXY.x * offset, 
                    transform.position.y,
                    transform.position.z + positionXY.y * offset);

                Objects.Characters.Character instance = Instantiate(
                    character.gameObject, 
                    transform.position, 
                    Quaternion.identity, 
                    _room.transform).GetComponent<Objects.Characters.Character>();

                Room.OnCharacterStartStaticHandler?.Invoke(instance);

                angle += _multipleAngleBetween;            
            }

            Destroy(gameObject);
        }
    }
}
