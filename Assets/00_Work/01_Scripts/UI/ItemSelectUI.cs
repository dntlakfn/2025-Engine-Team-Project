using UnityEngine;
using UnityEngine.Events;

using Work.Scripts.Entities;


namespace Work.Scripts.UI
{
    public class ItemSelectUI : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private LayerMask whatIsItem;
        private ItemUI item;
        private RectTransform rectTrm;
        public UnityEvent<ItemUI> OnEquiped;
        public UnityEvent<WeaponData> OnThrew;
        private void Awake()
        {
            rectTrm = GetComponent<RectTransform>();
        }
        private void Update()
        {
            if(Input.GetMouseButtonDown(1))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray2D ray = new Ray2D(new Vector3(mousePos.x, mousePos.y, -9), Vector3.forward);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward, Camera.main.farClipPlane, whatIsItem);
                if (hit)
                {
                    Vector3 pos = hit.point + new Vector2(2, 0);
                    pos.z = -7;
                    rectTrm.transform.position = pos;
                    panel.SetActive(true);
                    item = hit.transform.GetComponent<ItemUI>();
                }
                else
                {
                    panel.SetActive(false);
                    item = null;
                }
            }
            
        }
        
        public void Equip()
        {
            OnEquiped?.Invoke(item);
        }
        public void Throw()
        {
            OnThrew?.Invoke(item.GetItem());
            Destroy(item.gameObject);
        }
        public void Discard()
        {
            Destroy(item.gameObject);
            panel.SetActive(false);
        }
    }
}