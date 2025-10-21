using UnityEngine;
using UnityEngine.Events;
using Work.Scripts.Entities;

namespace Work.Scripts.Etc
{
    public class ItemActionManager : MonoBehaviour
    {
        public static ItemActionManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        

    }
}
