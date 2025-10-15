using UnityEngine;

namespace Work.Scripts.Entities
{
    public class EntityHealth : MonoBehaviour
    {
        public int maxHealth;

        private int health;

        public int HP
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                if(health <= 0 )
                {

                }
            }
        }

        private void Awake()
        {
            ResetHp();
        }
        public void ResetHp()
        {
            health = maxHealth;
        }

        
    }
}