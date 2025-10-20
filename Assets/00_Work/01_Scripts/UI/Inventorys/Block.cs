using UnityEngine;
using UnityEngine.UI;

namespace Work.Scripts.UI
{
    public class Block : MonoBehaviour
    {
        private Image image;
        private GameObject obj;
        private bool isDropable = true;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (obj != null)
            {
                if (collision.GetComponent<ItemUI>().isDropable == true)
                {
                    isDropable = false;

                    collision.GetComponent<ItemUI>().isDropable = false;
                }
                image.color = new Color(0.6f,0, 0);
                return;
            }
            collision.transform.SetParent(transform.parent.parent);
            image.color = new Color(0, 0.6f, 0);
            obj = collision.gameObject;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out ItemUI item))
            {
                if (obj != item.gameObject)
                {
                    image.color = new Color(0, 0.6f, 0);
                }
                else if(obj == item.gameObject)
                {
                    image.color = new Color(1, 1, 1);
                    obj = null;

                }
                if (isDropable == false)
                {

                    item.isDropable = true;
                    isDropable = true;
                    return;
                }
                
                
            }
        }
    }
}