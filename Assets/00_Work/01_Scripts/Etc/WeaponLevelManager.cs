using UnityEngine;
using UnityEngine.Events;
using Work.Scripts.UI;

namespace Work.Scripts.Etc
{ 
    public class WeaponLevelManager : MonoBehaviour
    {
        public static WeaponLevelManager Instance;
        

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

       
    }
}