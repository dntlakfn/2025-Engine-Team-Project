using System;
using UnityEngine;
using Work.Scripts.UI;

namespace Work.Scripts.Entities
{
    public class EntityAnimator : MonoBehaviour
    {
        private Animator _animator;
        private string _paramName;
        public Action OnAttackEnemy;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartSkillAnimation(WeaponType weaponType, int v)
        {
            SetBool("IDLE", false);
            SetBool(weaponType.ToString().ToUpper(), true);
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
            SetSkillNum(0);
        }

        public void Attack()
        {
            OnAttackEnemy?.Invoke();
        }
    }
}