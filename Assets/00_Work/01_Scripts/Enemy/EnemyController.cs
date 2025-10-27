using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Rendering;
using Work.Scripts.Entities;
using Work.Scripts.Etc;
using Work.Scripts.Skills;
using Work.Scripts.UI;
using Random = UnityEngine.Random;



namespace Work.Scripts.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private SkillSO[] skills;

        public Action<Animator, GameObject, Volume> OnAttackProduction;

        public string enemyName;
        [SerializeField] private EnemyWeapon weapon;
        [SerializeField] private LayerMask whatIsPlayer;
        [SerializeField] private DamageText damageText;
        [SerializeField] private EnemySkillText enemySkillText;

        private Transform canvas;
        private Transform damageTextCanvas;
        private Volume volume;
        private EntityAnimator animator;

        SkillSO skillData;
        EntityHealth playerHealth;

        private void Awake()
        {
            animator = GetComponentInChildren<EntityAnimator>();

            animator.OnAttack += Attack;

        }

        private void OnDestroy()
        {
            animator.OnAttack -= Attack;
        }

        public void Initialize(EntityHealth player, Transform canvas, Transform damageTextCanvas, AttackCamera cam, Volume volume)
        {
            playerHealth = player;
            this.damageTextCanvas = damageTextCanvas;
            this.volume = volume;
            this.canvas = canvas;
            OnAttackProduction += cam.MoveAction;
        }

        public void StartAction()
        {
            SetSkill();
            var skillText = Instantiate(enemySkillText, canvas);
            skillText.Show(skillData.skillName);
            DOVirtual.DelayedCall(1f, () =>
            {
                animator.StartEnemySkillAnimtion(skillData.AnimationNum);

            });


        }

        public void SetSkill()
        {
            skillData = skills[Random.Range(0, skills.Length)];
        }

        public void Attack()
        {

            if (playerHealth == null) return;
            int damage = (int)(weapon.GetEnemyWeapon().Damage * (skillData.damagePercent / 100f));
            playerHealth.HP -= (damage);
            OnAttackProduction?.Invoke(animator.GetAnimator(), playerHealth.gameObject, volume);
            damageText.Show(damage, playerHealth.transform.position + (Vector3.up * 4) - (Vector3.forward * 4), damageTextCanvas);
        }
        





    }
}