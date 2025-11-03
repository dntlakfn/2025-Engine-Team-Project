using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Work.Scripts.Skills;

namespace Work.Scripts.UI
{

    public class SkillNodeUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI skillName;
        [SerializeField] private TextMeshProUGUI skillDamageCoefficient;
        [SerializeField] private TextMeshProUGUI skillConsumptionDurability;

        protected SkillSO skillSO;
       
        private Button skillButton;

        public void SetSkill(SkillSO skillSO)
        {
            skillButton = GetComponent<Button>();
            this.skillSO = skillSO;

            skillName.text = skillSO.skillName;
            skillDamageCoefficient.text = $"{skillSO.damagePercent}% x {skillSO.damageCount}";
            skillConsumptionDurability.text = $"³»±¸µµ -{skillSO.consumptionDurability}";
            
        }

        public void AddClickEvent(UnityAction action)
        {
            skillButton.onClick.AddListener(action);
        }

        public void ActiveBtn(bool isActive)
        {
            GetComponent<Button>().interactable = isActive;
        }

        public void RemoveClickEvent()
        {
            skillButton.onClick.RemoveAllListeners();
        }
    }
}
