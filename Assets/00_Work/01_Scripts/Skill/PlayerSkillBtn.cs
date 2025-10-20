using UnityEngine;
using UnityEngine.Events;
using Work.Scripts.Skills;

namespace Work.Scripts.UI
{

    public class PlayerSkillBtn : SkillNodeUI
    {
        public UnityEvent<SkillSO> OnClickSkillBtn;

        public void ClickSkillBtn()
        {
            OnClickSkillBtn?.Invoke(skillSO);
        }
    }
}