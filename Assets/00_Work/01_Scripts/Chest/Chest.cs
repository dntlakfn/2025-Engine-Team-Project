using UnityEngine;
using UnityEngine.Events;

namespace Work.Scripts.Chests
{
    public class Chest : MonoBehaviour
    {
        public UnityEvent OnChestClick;

        private void OnMouseDown()
        {
            OnChestClick?.Invoke();
        }
    }
}