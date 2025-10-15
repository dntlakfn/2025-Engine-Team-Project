using UnityEngine;

namespace Work.Scripts.Entities
{
    public class EntityAnimator : MonoBehaviour
    {
        private Animator _animator;
        private string _paramName;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetBool(string name, bool v)
        {
            _paramName = name;
            _animator.SetBool(name, v);
        }
        public void SetSkillNum(int v) => _animator.SetInteger("SKILLNUM", v);
        public void EndAnimation()
        {
            _animator.SetBool(_paramName, false);
            _paramName = "";
            _animator.SetInteger("SKILLNUM", 0);
        }
    }
}