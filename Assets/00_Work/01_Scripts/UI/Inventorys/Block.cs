using UnityEngine;
using UnityEngine.UI;

namespace Work.Scripts.UI
{
    public class Block : MonoBehaviour
    {
        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            image.color = new Color(0, 0.6f, 0);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            image.color = new Color(1, 1, 1);

        }
    }
}