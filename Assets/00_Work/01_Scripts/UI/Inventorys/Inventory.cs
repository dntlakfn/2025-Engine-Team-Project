using UnityEngine;

namespace Work.Scripts.UI
{
    public class Inventory : MonoBehaviour
    {

        public void ToggleInventory()
        {
            if (!gameObject.activeSelf)
            {
                ShowInventory();
            }
            else
            {
                HideInventory();
            }
        }

        public void ShowInventory()
        {
            gameObject.SetActive(true);
        }

        public void HideInventory()
        {
            gameObject.SetActive(false);
        }

    }
}