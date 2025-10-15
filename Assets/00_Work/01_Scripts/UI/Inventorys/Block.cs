using UnityEngine;
using UnityEngine.UI;

namespace Work.Scripts.UI
{
    public class Block : MonoBehaviour
    {
        private Image image;
        private GameObject obj;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (obj != null)
            {
                collision.GetComponent<ItemUI>().isDropable = false;
                image.color = new Color(0.6f,0, 0);
                return;
            }
            collision.transform.SetParent(transform.parent.parent);
            image.color = new Color(0, 0.6f, 0);
            obj = collision.gameObject;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            image.color = new Color(1, 1, 1);
            if(collision.TryGetComponent(out ItemUI item))
            {
                item.isDropable = true;
                obj = null;
            }
        }
    }
}