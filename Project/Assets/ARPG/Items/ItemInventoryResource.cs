using UnityEngine;
using System.Collections;
using Cirrus.Extensions;
using System.Collections.Generic;
using System;

namespace Cirrus.ARPG.Items
{
    [System.Serializable]
    public class ItemInventoryPersistence
    {
        [SerializeField]
        public ItemInventoryResource _resource;

        [SerializeField]
        private ItemPersistence[] _items;

        public ItemPersistence[] Items
        {
            get
            {
                return _items;
            }
        }

        public ItemInventoryPersistence(ItemInventoryResource resource)//, Vector2Int dimensions)
        {
            _resource = resource;
            _items = new ItemPersistence[resource._items.Count];//._dimensions.x*resource._dimensions.y];
            for (int i = 0; i < resource._items.Count; i++)
            {
                if (_resource._items[i] == null)
                {
                    return;
                }

                _items[i] = _resource._items[i].Create();
            }

            Debug.Log(_items.Length);
        }



        // TODO: best fit

        // TODO : cache where we last placed to accelarate finding a new place
        // TODO : Concurrent access??
        private bool TryFirstFit(ItemPersistence item, out int slot)
        {
            for(slot = 0; slot < _items.Length; slot++)
            {
                if (_items[slot] == null)
                {                    
                    return true;
                }
            }

            slot = -1;
            return false;
        }


        public bool TryStore(ItemPersistence item)
        {
            // TODO: why are we putting hearts in our inventory?
            if (item == null)
                return false;

            else if (TryFirstFit(item, out int slot))
            {
                _items[slot] = item;
                return true;
            }

            return false;
        }

        public void Store(int index, ItemPersistence item)
        {            
            _items[index] = item;
            _items[index]._isEmpty = false;
        }

        public void Clear(int index)
        {
            _items[index]._isEmpty = true;
            //_items[index] = null;
        }
    }

    [CreateAssetMenu(menuName = "Cirrus/Objects/Items/Item Inventory")]
    public class ItemInventoryResource : ScriptableObject
    {

        // e.g two chests sharing the same item is false..
        // e.g two party member sharing the same item is true
        [SerializeField]
        protected bool _isShared = false;
                
        private bool _exists = false;

        public void OnEnable()
        {
            _exists = false;
        }

        [SerializeField]
        public List<ItemResource> _items;

        private ItemInventoryPersistence _persistence;

        public ItemInventoryPersistence Persistence
        {
            get
            {
                //Debug.Log(name+ _exists);

                if (_isShared && _exists)
                {
                    return _persistence;
                }
                
                _persistence = new ItemInventoryPersistence(this);
                _exists = true;
                return _persistence;
            }
        }

        //public void On

    }
}
