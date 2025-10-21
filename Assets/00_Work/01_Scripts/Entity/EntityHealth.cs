using System;
using UnityEngine;

namespace Work.Scripts.Entities
{
    public class EntityHealth : MonoBehaviour
    {
        public int maxHealth;
        private Animator animator;
        public Action OnDeath;
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
                    OnDeath?.Invoke();
                    Destroy(gameObject, 1.0f);
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

        private void OnDestroy()
        {
            OnDeath = null;
        }

        public void ResetHp()
        {
            health = maxHealth;
        }

        
    }
}