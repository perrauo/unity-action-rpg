using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.UI
{
    public class DragPreview : MonoBehaviour
    {
        [SerializeField]
        private UnityEngine.UI.Image _image;

        public DragPreview Create(Transform parent, InventoryObject obj)//, Vector3 position)
        {
            DragPreview dp = Instantiate(gameObject, parent).GetComponent<DragPreview>();
            dp._image.sprite = obj.Icon;
            //dp._image.SetNativeSize();
            return dp;
        }






    }
}