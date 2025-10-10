using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Work.Scripts.UI;

namespace Work.Scripts.UI
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemListSO weaponList;
        private ItemSO itemSO;
        private RectTransform rectTrm;
        private BoxCollider2D boxCollider;
        private Image image;

        private bool _isSelected = false;

        private void Awake()
        {
            itemSO = weaponList.GetRandomItem();
            boxCollider = GetComponent<BoxCollider2D>();
            rectTrm = GetComponent<RectTransform>();
            image = GetComponent<Image>();
            rectTrm.sizeDelta = new Vector2(100 * itemSO.sizeX, 100 * itemSO.sizeY);
            boxCollider.size = new Vector2(100 * itemSO.sizeX, 100 * itemSO.sizeY) - new Vector2(50,50);
            image.sprite = itemSO.sprite;
            transform.SetParent(transform.parent.parent);
        }

        private void Update()
        {
            if(_isSelected)
            {
                if ((Input.GetKeyDown(KeyCode.R)))
                {
                    transform.eulerAngles += new Vector3(0, 0, 90);
                }
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.x *= 96f;
                mousePos.y *= 90f;
                rectTrm.anchoredPosition = mousePos;
            }
        }

        private void OnMouseDown()
        {
            _isSelected = true;

        }

        private void OnMouseUp()
        {
            _isSelected = false;
            rectTrm.anchoredPosition = new Vector2((int)(rectTrm.anchoredPosition.x / 100) * 100, (int)(rectTrm.anchoredPosition.y / 100) * 100);
        }

        
    }
}