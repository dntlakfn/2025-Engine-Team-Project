using UnityEngine;

namespace Work.Scripts.Entities
{
    public class EntityHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth;

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


        
    }
}