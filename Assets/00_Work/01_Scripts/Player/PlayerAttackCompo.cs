
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using Work.Scripts.Enemies;
using Work.Scripts.Entities;
using Work.Scripts.Etc;
using Work.Scripts.Skills;
using Work.Scripts.UI;

namespace Work.Scripts.Players
{
    public class PlayerAttackCompo : MonoBehaviour
    {
        public UnityEvent<Animator, GameObject, Volume> OnAttackProduction;

        [SerializeField] private PlayerWeapon weapon;
        [SerializeField] private EntityAnimator animator;
        [SerializeField] private Transform[] enemyPoint;
        [SerializeField] private LayerMask whatIsEnemy;
        [SerializeField] private DamageText damageText;
        [SerializeField] private GameObject useSkillText;
        [SerializeField] private Transform canvas;
        [SerializeField] private Volume volume;
        [SerializeField] private ThrowWeapon throwPrefab;
        bool isSelecting = false;
        SpriteRenderer selectImage = null;

        

        int skillPercent;
        int skillCount;
        int skillNum;
        int durabilityConsumption;
        EntityHealth enemyHealth;

        private void Awake()
        {
            animator.OnAttack += Attack;
        }

        private void OnDestroy()
        {
            animator.OnAttack -= Attack;
        }

        public void UseSkill(SkillSO skill)
        {
            isSelecting = true;

            skillNum = skill.AnimationNum;
            skillCount = skill.damageCount;
            skillPercent = skill.damagePercent;
            durabilityConsumption = skill.consumptionDurability;
            useSkillText.SetActive(true);
        }

        public void Attack()
        {
            
            if (enemyHealth == null) return;
            int damage = (int)(weapon.GetWeaponData().weaponSO.Damage * (skillPercent / 100f));
            enemyHealth.HP -= (damage);
            OnAttackProduction?.Invoke(animator.GetAnimator(), enemyHealth.gameObject, volume);
            damageText.Show(damage, enemyHealth.transform.position + (Vector3.up * 4) - (Vector3.forward * 4), canvas);
        }

        public void ConsumeDurability()
        {
            weapon.Durability -= durabilityConsumption;
        }

        private bool SelectTarget()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit hit;
            var hita = Physics.Raycast(mousePos, Vector3.forward, out hit, Camera.main.farClipPlane, whatIsEnemy);
            Debug.Log(hit.collider);
            if (hita)
            {
                var temp = hit.transform.parent.GetChild(0).GetComponent<SpriteRenderer>(); 
                if (selectImage == temp)
                {
                    selectImage.color = new Color(1, 0, 0, 1f);
                    return true;
                }
                else if(selectImage != null)
                {
                    selectImage.color = new Color(1, 0, 0, 0f);
                    selectImage = temp;
                    selectImage.color = new Color(1, 0, 0, 1f);
                }
                else
                {
                    selectImage = temp;
                    selectImage.color = new Color(1, 0, 0, 1f);

                }
                EntityHealth enemy = hit.transform.GetComponent<EntityHealth>();
                enemyHealth = enemy;

                return true;
            }
            if(selectImage != null)
                selectImage.color = new Color(1, 0, 0, 0f);
            return false;
        }

        private void Update()
        {
            if (isSelecting)
            {
                
                if(SelectTarget() && Input.GetMouseButtonDown(0))
                {
                    useSkillText.SetActive(false);
                    selectImage.color = new Color(1, 0, 0, 0f);
                    animator.StartPlayerSkillAnimation(weapon.GetWeaponData().weaponSO.weaponType, skillNum);
                    isSelecting = false;
                    ConsumeDurability();
                    weapon.GetSkillTree().EXP += 20 + (Random.Range(0, 10));
                    BattleManager.Instance.TurnManager.StartEnemyTurn();
                }
                else if(Input.GetMouseButtonDown(1))
                {
                    useSkillText.SetActive(false);

                    isSelecting = false;
                    if(selectImage != null)
                        selectImage.color = new Color(1, 0, 0, 0f);
                }
            }
        }


        public void Throw(WeaponData weapon)
        {
            var temp = Instantiate(throwPrefab, transform.position + new Vector3(1, 2f, 0), Quaternion.Euler(new Vector3(0, 0, -90)));
            temp.canvas = canvas;
            temp.Throw(weapon);
        }

    }
}