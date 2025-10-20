using UnityEngine;

namespace Work.Scripts.Entities
{
    public class EntityHealth : MonoBehaviour
    {
        public int maxHealth;
        private Animator animator;

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
                    animator.Play("Dead", 0);
                }
                else
                {
                    animator.Play("Hit", 0);
                }
            }
        }

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            ResetHp();
        }
        public void ResetHp()
        {
            health = maxHealth;
        }

        
    }
}