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
        [SerializeField] private SkinnedMeshRenderer skinnedRenderer;
        [SerializeField] private RuntimeAnimatorController controller;
        int _skillnumHash;
        int _IdleHash;
        private void Awake() 
        {
            _animator = GetComponent<Animator>();
            //Debug.Log(_animator.runtimeAnimatorController);

            _skillnumHash = Animator.StringToHash("SKILLNUM");
            _IdleHash = Animator.StringToHash("IDLE");
            
        }

        bool EnsureAnimatorReady()
        {
            if (!_animator || !_animator.isActiveAndEnabled)
            {
                Debug.Log("animator 재설정됨");
                if (!_animator.gameObject.activeInHierarchy)
                {
                    Debug.Log(transform.parent.gameObject.name);
                    Debug.Log($"왜인진 모르겠지만 {_animator.transform.parent.gameObject.name}가 꺼짐;; ");
                    _animator.gameObject.SetActive(true);

                }

                if (!_animator.enabled)
                    _animator.enabled = true;


            }

            // 컨트롤러가 없으면, 직렬화한 controller를 붙여본다
            if (_animator.runtimeAnimatorController == null)
            {
                if (controller != null)
                {
                    _animator.runtimeAnimatorController = controller;
                    _animator.Rebind();
                    _animator.Update(0f);
                }
                else
                {
                    Debug.LogError($"{transform.parent}: AnimatorController가 없습니다. Inspector의 'controller' 필드에 베이스 컨트롤러를 할당하거나 프리팹에 컨트롤러를 연결하세요.", this);
                    return false;
                }
            }
            return true;
        }


        public void SetBoneLayer(int newLayer)
        {
            skinnedRenderer.gameObject.layer = newLayer;
            // 본에 레이어 씌우기
            foreach (Transform bone in skinnedRenderer.bones)
            {
                if (bone != null)
                    bone.gameObject.layer = newLayer;
            }

            // 루트 본도 바꾸기
            if (skinnedRenderer.rootBone != null)
                skinnedRenderer.rootBone.gameObject.layer = newLayer;
        }

        public void StartPlayerSkillAnimation(WeaponType weaponType, int v)
        {
            SetBool("IDLE", false);
            SetBool(weaponType.ToString().ToUpper(), true);
            SetSkillNum(v);
        }

        public void StartEnemySkillAnimtion(int v)
        {
            EnsureAnimatorReady();

            _animator.SetBool(_IdleHash, false);
            SetSkillNum(v);
        }

        public void SetBool(string name, bool v)
        {
            
            _paramName = name;
            _animator.SetBool(name, v);
        }
        public void SetSkillNum(int v) => _animator.SetInteger(_skillnumHash, v);


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