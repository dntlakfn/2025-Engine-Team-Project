
using UnityEngine;
using Work.Scripts.Etc;

namespace Work.Scripts.Entities
{
    public class EntityHealth : MonoBehaviour
    {
        public int maxHealth;
        public bool isPlayer = false;
        public bool isBoss = false;
        [HideInInspector]
        public bool isDead = false;
        private Animator animator;
        private int health;
        private Collider _collider;


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
                    animator.SetBool("DEAD", true);
                    animator.SetBool("IDLE", false);
                    BattleManager.Instance.EntityDead(isPlayer, isBoss);
                    _collider.enabled = false;
                    isDead = true;
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
            _collider = GetComponent<BoxCollider>();

            ResetHp();
        }

        public void ResetHp()
        {
            health = maxHealth;
        }

        public void Rest()
        {
            health += maxHealth * (3 / 10);
        }
    }
}