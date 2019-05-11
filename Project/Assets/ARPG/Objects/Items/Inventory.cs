using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace Cirrus.ARPG.Objects.Items
{
    // TODO: Reinstate Sections (Tab menu, Hotbar etc..), we need it to handle divergin dimensions

    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        public Slot[] _slots;

        [SerializeField]
        public Vector2Int _dimension;

        // TODO optimise
        public IEnumerable<Slot> Slots
        {
            get
            {
                return _slots;
            }
        }

        private Slot _swapAnchorSlot;

        private Slot _currentSlot;

        private Vector2Int _cursorPosition;

        [SerializeField]
        private Cursor _cursor;

        private Cursor _swapAnchor;

        [SerializeField]
        private GameObject _swapAnchorPrefab;

        [SerializeField]
        public bool IsEnabled = false;

        [SerializeField]
        private GameObject _display;


        [SerializeField]
        private HotBar _hotBar;

        // TODO: Create counter object
        [SerializeField]
        private Cirrus.UI.Counter _gemCounter;

        private Characters.Character _character;


        public void Start()
        {
            Close();
        }

        private void PlaceSwapAnchor()
        {
            _swapAnchor = Instantiate(_swapAnchorPrefab, _currentSlot.transform).GetComponent<Cursor>();
            _swapAnchor.transform.localPosition = Vector3.zero;
            _swapAnchorSlot = _currentSlot;
        }

        private void CancelSwap()
        {
            Destroy(_swapAnchor.gameObject);
            _swapAnchor = null;
            _swapAnchorSlot = null;
        }

        private void DoSwap()
        {
            if (_currentSlot.TrySwap(_swapAnchorSlot))
            {
                _currentSlot.DoUpdate();
                _swapAnchorSlot.DoUpdate();
                CancelSwap();
            }
        }

        public void Map(int i)
        {          
            if (_currentSlot.Item != null)
            {
                _hotBar.Store(i, _currentSlot.Item);
            }
        }

        public void Swap()
        {
            if (_swapAnchorSlot == null)
            {
                PlaceSwapAnchor();
            }
            else if (_swapAnchorSlot == _currentSlot)
            {
                CancelSwap();
            }
            else
            {
                DoSwap();
            }
        }

        public IEnumerable<VirtualSlot> CreateVirtualSlots(InventoryUser user)
        {
            List<VirtualSlot> slots = new List<VirtualSlot>();
            foreach (var s in Slots)
            {
                if (s == null) continue;

                var vSlot = s.CreateVirtualSlot();
                vSlot.SetUser(user);
                vSlot.IncrementFreeCount();
 
                if (vSlot == null) continue;

                slots.Add(vSlot);
            }

            return slots;
        }
 
        public void Open(Characters.Character character)
        {
            _display.gameObject.SetActive(true);
            IsEnabled = true;

            if (character == null)
                return;

            if(_currentSlot == null)
                ResetCursor(0);

            _character = character;


            // Update slots in case new items came in
            foreach(var slot in _slots)
            {
                if(slot != null)
                slot.DoUpdate();
            }

            _character.Persistence.Attributes.Gems.OnCurrentChangedHandler += OnGemCountChanged;
            OnGemCountChanged(character.Persistence.Attributes.Gems);
        }

        public void OnGemCountChanged(Objects.Attributes.Stat.Product ratio)
        {
            _gemCounter.UpdateValue(ratio.Current);
        }


        public void Close()
        {
            _display.gameObject.SetActive(false);
            IsEnabled = false;

            if (_character != null)
            {
                _character.Persistence.Attributes.Gems.OnCurrentChangedHandler -= OnGemCountChanged;
                _character = null;
            }

        }

        public void Move(Vector2Int movement)
        {
            movement.y *= -1;
            _cursorPosition += movement;

            //calculate the according index i in 1D space
            int i = _cursorPosition.x + _dimension.x * _cursorPosition.y;
            i = Cirrus.Utils.Mathf.Wrap(i, 0, _slots.Length-1);
            ResetCursor(i);
        }

        public void ResetCursor(int idx)
        {
            _currentSlot = _slots[idx];
            _cursor.transform.SetParent(_currentSlot.transform);
            _cursor.transform.localPosition = Vector3.zero;
        }


        private void OnValidate()
        {
            if (IsEnabled)
            {
                Open(null);
            }
            else
            {
                Close();
            }
        }
    }
}
