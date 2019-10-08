using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Cirrus.Collections
{

    //[System.Serializable]
    //public class GameObjectPoolWrapper
    //{
    //    public GameObject _template;

    //    private int _min = 10;

    //}


    public class GameObjectPool
    {
        private readonly ConcurrentBag<GameObject> _items;

        private int _counter = 0;

        // minimal pool size
        private int _min = 10;

        private GameObject _template;

        public GameObjectPool(GameObject template, int min=10)
        {
            _min = min;
            _template = template;
            _items = new ConcurrentBag<GameObject>();
        }

        public void Release(GameObject item)
        {
            item.SetActive(false);
            _items.Add(item);
            _counter++;       
        }

        public GameObject Get()
        {
            GameObject item;
            // Remove item from the bag
            if (_counter >= _min && _items.TryTake(out item))
            {
                _counter--;
                item.SetActive(true);
                return item;
            }
            else
            {
                item = GameObject.Instantiate(_template);
                return item;

            }
        }
    }
}