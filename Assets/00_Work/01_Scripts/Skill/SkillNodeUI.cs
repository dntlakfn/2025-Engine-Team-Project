using TMPro;
using UnityEngine;
using Work.Scripts.Skills;

namespace Work.Scripts.UI
{

    public class SkillNodeUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI skillName;
        [SerializeField] private TextMeshProUGUI skillDamageCoefficient;
        [SerializeField] private TextMeshProUGUI skillConsumptionDurability;

        protected SkillSO skillSO;


        public void SetSkill(SkillSO skillSO)
        {
            this.skillSO = skillSO;
            skillName.text = skillSO.skillName;
            skillDamageCoefficient.text = $"{skillSO.damagePercent}% x {skillSO.damageCount}";
            skillConsumptionDurability.text = $"³»±¸µµ -{skillSO.consumptionDurability}";
        }
    }
}
