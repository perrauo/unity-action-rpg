using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace Cirrus.ARPG.World.Objects
{
    [System.Serializable]
    public class ListListener : IEnumerable<BaseObject>
    {
        public OnObjectEvent OnAddedHandler;

        public OnObjectEvent OnRemovedHandler;

        [SerializeField]
        private List<BaseObject> _initialTargets;

        [SerializeField]
        private List<SceneList> _sceneTargets;

        [SerializeField]
        private List<SceneList> _sceneTargetsFilter;

        [SerializeField]
        private List<AssetList> _assetTargets;

        [SerializeField]
        private List<AssetList> _assetTargetsFilter;

        private List<BaseObject> _targetsFinal;

        private BaseObject _source;

        public ListListener()
        {
            _targetsFinal = new List<BaseObject>();
        }

        public void Init(BaseObject source)
        {
            _source = source;

            foreach (AssetList list in _assetTargets)
            {
                if (list == null)
                    continue;

                list.OnRemovedHandler += OnListRemoved;
                list.OnAddedHandler += OnListAdded;
                list.OnListClearHandler += OnListClear;

                foreach (BaseObject obj in list)
                {
                    if (obj == null)
                        continue;

                    if (obj == _source)
                        continue;

                    _targetsFinal.Add(obj);
                }
            }

            foreach (AssetList list in _assetTargetsFilter)
            {
                if (list == null)
                    continue;

                list.OnRemovedHandler += OnListRemovedFilter;
                list.OnAddedHandler += OnListAddedFilter;
                //list.OnListClearHandler += OnListTargetIgnoredAdded;

                foreach (BaseObject obj in list)
                {
                    if (obj == null)
                        continue;

                    if (obj == _source)
                        continue;

                    _targetsFinal.Remove(obj);
                }
            }

            foreach (SceneList list in _sceneTargets)
            {
                if (list == null)
                    continue;

                list.OnRemovedHandler += OnListRemoved;
                list.OnAddedHandler += OnListAdded;
                list.OnListClearHandler += OnListClear;

                foreach (BaseObject obj in list)
                {
                    if (obj == null)
                        continue;

                    if (obj == _source)
                        continue;

                    _targetsFinal.Add(obj);
                }
            }

            foreach (SceneList list in _sceneTargetsFilter)
            {
                if (list == null)
                    continue;

                list.OnRemovedHandler += OnListRemovedFilter;
                list.OnAddedHandler += OnListAddedFilter;
                //list.OnListClearHandler += OnListTargetIgnoredAdded;

                foreach (BaseObject obj in list)
                {
                    if (obj == null)
                        continue;

                    if (obj == _source)
                        continue;

                    _targetsFinal.Remove(obj);
                }
            }

            foreach (BaseObject t in _initialTargets)
            {
                _targetsFinal.Add(t);
            }
        }

        public void OnListAdded(IList<BaseObject> list, BaseObject obj)
        {
            if (!_targetsFinal.Contains(obj))
            {
                _targetsFinal.Add(obj);
                OnAddedHandler?.Invoke(obj);
            }
        }

        public void OnListRemoved(IList<BaseObject> list, BaseObject obj)
        {
            if (_targetsFinal.Remove(obj))
            {
                OnRemovedHandler?.Invoke(obj);
            }
        }

        public void OnListClear(IList<BaseObject> list)
        {
            foreach (BaseObject obj in list)
            {
                _targetsFinal.Remove(obj);
            }

            // TODO handler
        }

        public void OnListAddedFilter(IList<BaseObject> list, BaseObject obj)
        {
            if (_targetsFinal.Remove(obj))
            {
                OnRemovedHandler?.Invoke(obj);
            }
        }

        public void OnListRemovedFilter(IList<BaseObject> list, BaseObject obj)
        {
            foreach (AssetList l in _assetTargets)
            {
                if (l.Contains(obj))
                {
                    _targetsFinal.Add(obj);
                    OnAddedHandler?.Invoke(obj);
                    return;
                }
            }
        }

        public void OnListClearFilter(IList<BaseObject> list, BaseObject obj)
        {
            // TODO
        }

        public IEnumerator<BaseObject> GetEnumerator()
        {
            return ((IEnumerable<BaseObject>)_targetsFinal).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<BaseObject>)_targetsFinal).GetEnumerator();
        }
    }
}