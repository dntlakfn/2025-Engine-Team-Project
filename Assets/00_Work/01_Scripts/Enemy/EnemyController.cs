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
    public class EnemyController : MonoBehaviour, IBattle
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
        [SerializeField] private EntityAnimator animator;
        private AttackCamera attackCamera;
        public SkillSO skillData;
        public EntityHealth _myHealth;
        

        private EntityHealth _playerHealth;
        private void Awake()
        {
            _myHealth = GetComponent<EntityHealth>();
        }

        private void OnDestroy()
        {
            animator.OnAttack -= Attack;
        }

        public void Initialize(Transform canvas, Transform damageTextCanvas, Volume volume)
        {
            animator = GetComponentInChildren<EntityAnimator>();

            animator.OnAttack += Attack;
            _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityHealth>();
            
            this.damageTextCanvas = damageTextCanvas;
            this.volume = volume;
            this.canvas = canvas;
            attackCamera = BattleManager.Instance.GetAttackCamera();
            animator.SetBoneLayer(gameObject.layer);
            weapon.gameObject.layer = gameObject.layer;
            
        }

        public void StartAction()
        {
            if(_myHealth.isDead) return;

            Debug.Log(animator.GetAnimator().runtimeAnimatorController);
            skillData = skills[Random.Range(0, skills.Length)];
            var skillText = Instantiate(enemySkillText, canvas); 
            skillText.Show(skillData.skillName);
            //animator.StartEnemySkillAnimtion(skillData.AnimationNum);
            DOVirtual.DelayedCall(1f, () =>
            {
                animator.StartEnemySkillAnimtion(skillData.AnimationNum);

            });


        }

        public void Attack()
        {

            if (_playerHealth == null) return;
            int damage = (int)(weapon.GetEnemyWeapon().Damage * (skillData.damagePercent / 100f));
            _playerHealth.HP -= (damage);
            attackCamera.MoveAction(animator.GetAnimator(), _playerHealth.gameObject, volume);
            damageText.Show(damage, _playerHealth.transform.position + (Vector3.up * 4) - (Vector3.forward * 4), damageTextCanvas);
        }

        public void BattleStart()
        {
            
        }

        public void BattleEnd()
        {
            Destroy(gameObject);
        }
    }
}