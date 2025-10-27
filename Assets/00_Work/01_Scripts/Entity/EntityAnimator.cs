using System;
using UnityEngine;
using Work.Scripts.UI;

namespace Work.Scripts.Entities
{
    public class EntityAnimator : MonoBehaviour
    {
        private Animator _animator;
        private string _paramName;
        public Action OnAttack;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartPlayerSkillAnimation(WeaponType weaponType, int v)
        {
            SetBool("IDLE", false);
            SetBool(weaponType.ToString().ToUpper(), true);
            SetSkillNum(v);
        }

        public void StartEnemySkillAnimtion(int v)
        {
            SetBool("IDLE", false);
            SetSkillNum(v);
        }

        public void SetBool(string name, bool v)
        {
            _paramName = name;
            _animator.SetBool(name, v);
        }
        public void SetSkillNum(int v) => _animator.SetInteger("SKILLNUM", v);


        public void EndSkillAnimation()
        {
            Debug.Log("EndSkillAnimation");
            _animator.SetBool("IDLE", true);
            SetBool(_paramName, false);
            _paramName = "";
            SetSkillNum(-1);
        }

        public void Attack()
        {
            OnAttack?.Invoke();
        }

        public Animator GetAnimator() => _animator;
    }
}