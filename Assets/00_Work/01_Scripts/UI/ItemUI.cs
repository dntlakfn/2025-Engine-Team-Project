using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Work.Scripts.Entities;
using Work.Scripts.UI;

namespace Work.Scripts.UI
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] private ItemListSO weaponList;
        private WeaponData weaponData;
        private RectTransform rectTrm;
        private BoxCollider2D boxCollider;
        private Image image;
        private Vector2 prevPos;
        private Transform prevParent;
        private int sizeX;
        private int sizeY;

        private bool _isDrag = false;
       public bool isDropable = true;

        private void Awake()
        {
            ItemSO itemSO = weaponList.GetRandomItem();
            boxCollider = GetComponent<BoxCollider2D>();
            rectTrm = GetComponent<RectTransform>();
            image = GetComponent<Image>();
            
            ResetItemUI(itemSO);
        }

        private void ResetItemUI(ItemSO weapon)
        {
            weaponData = new WeaponData();
            weaponData.weaponSO = weapon;
            weaponData.durability = weapon.maxDurability;
            sizeX = weapon.sizeX;
            sizeY = weapon.sizeY;
            rectTrm.sizeDelta = new Vector2(100 * sizeX, 100 * sizeY);
            boxCollider.size = new Vector2(100 * sizeX, 100 * sizeY) - new Vector2(50, 50);
            image.sprite = weapon.sprite;
        }

        public void SetItemUI(WeaponData newWeapon)
        {
            if(newWeapon.weaponSO.weaponType == WeaponType.None)
            {
                Destroy(gameObject);
                return;
            }
            
            int prevSizeY = weaponData.weaponSO.sizeY;
            weaponData = newWeapon;
            sizeX = weaponData.weaponSO.sizeX;
            sizeY = weaponData.weaponSO.sizeY;
            rectTrm.sizeDelta = new Vector2(100 * sizeX, 100 * sizeY);
            boxCollider.size = new Vector2(100 * sizeX, 100 * sizeY) - new Vector2(50, 50);
            if(prevSizeY != sizeY)
            {
                rectTrm.anchoredPosition = new Vector2(rectTrm.anchoredPosition.x, rectTrm.anchoredPosition.y + (prevSizeY - sizeY) * 50);
            }
            image.sprite = weaponData.weaponSO.sprite;
        }

        public WeaponData GetItem()
        {
            return weaponData;
        }
        private void Update()
        {
            if(_isDrag)
            {
                if ((Input.GetKeyDown(KeyCode.R)))
                {
                    transform.eulerAngles += new Vector3(0, 0, 90);
                }
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rectTrm.transform.position = mousePos;
                rectTrm.anchoredPosition3D = new Vector3(rectTrm.anchoredPosition3D.x, rectTrm.anchoredPosition3D.y, 0);
            }
        }

        private void OnMouseDown()
        {
            
            _isDrag = true;
            prevPos = rectTrm.anchoredPosition;
            prevParent = transform.parent;
        }



        private void OnMouseUp()
        {
            _isDrag = false;
            if(isDropable == false)
            {
                rectTrm.anchoredPosition = prevPos;
                return;
            }
            RectTransform parent = transform.parent.GetComponent<RectTransform>();
            int minX = (int)(-250 + sizeX*100 /2);
            int maxX = (int)(250 - sizeX*100 / 2);
            int minY = (int)(-250 + sizeY*100 / 2);
            int maxY = (int)(250 - sizeY * 100 / 2);

            int offsetY = (transform.eulerAngles.z / 90) % 2 == 0 ? (sizeY - 3) * 50 : 0;
            int offsetX = (transform.eulerAngles.z / 90) % 2 != 0 ? (sizeY - 3) * 50 : 0;

            int X = Mathf.Clamp((((int)(rectTrm.anchoredPosition.x / 100)) * 100) - offsetX, ((transform.eulerAngles.z / 90) % 2) == 0 ? minX : minY, ((transform.eulerAngles.z / 90) % 2) == 0 ? maxX : maxY);
            int Y = Mathf.Clamp((((int)(rectTrm.anchoredPosition.y / 100)) * 100) - offsetY, ((transform.eulerAngles.z / 90) % 2) == 0 ? minY : minX, ((transform.eulerAngles.z / 90) % 2) == 0 ? maxY : maxX);
            rectTrm.anchoredPosition = new Vector2(X, Y - 5); 


        }

        
    }
}