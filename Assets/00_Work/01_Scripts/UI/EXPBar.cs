using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Work.Scripts.Entities;

namespace Work.Scripts.UI
{
    public class EXPBar : MonoBehaviour
    {
        [SerializeField] private Image EXPbar;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI value;
        [SerializeField] private PlayerWeapon weapon;


        private void Update()
        {
            SetBar();
        }

        public void SetBar()
        {
            EXPbar.fillAmount = weapon.GetSkillTree().EXP / weapon.GetSkillTree().GetExpRequirement();
            title.text = $"{weapon.GetSkillTree().weaponType} EXP";
            value.text = $"{weapon.GetSkillTree().EXP}/{weapon.GetSkillTree().GetExpRequirement()}";
        }

    }
}