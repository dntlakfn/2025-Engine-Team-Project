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
                rectTrm.transform.position = mousePos;
            }
        }

        private void OnMouseDown()
        {
            _isSelected = true;

        }

        private void OnMouseUp()
        {
            _isSelected = false;
            RectTransform parent = transform.parent.GetComponent<RectTransform>();
            int minX = (int)(-250 + Mathf.Round(itemSO.sizeX * 100)/2);
            int maxX = (int)(250 - Mathf.Round(itemSO.sizeX * 100) / 2);
            int minY = (int)(-250 + Mathf.Round(itemSO.sizeY * 100) / 2);
            int maxY = (int)(250 - Mathf.Round(itemSO.sizeY * 100) / 2);
            
            int X = Mathf.Clamp(((int)(rectTrm.anchoredPosition.x / 100)) * 100, ((transform.eulerAngles.z / 90) % 2) == 0 ? minX : minY, ((transform.eulerAngles.z / 90) % 2) == 0 ? maxX : maxY);
            int Y = Mathf.Clamp(((int)(rectTrm.anchoredPosition.y / 100)) * 100, ((transform.eulerAngles.z / 90) % 2) == 0 ? minY : minX, ((transform.eulerAngles.z / 90) % 2) == 0 ? maxY : maxX);
            rectTrm.anchoredPosition = new Vector2(X + ((transform.eulerAngles.z / 90) % 2) != 0 ? -50 : 0, Y - 5 + ((transform.eulerAngles.z / 90) % 2) == 0 ? -50 : 0); 

        }

        
    }
}