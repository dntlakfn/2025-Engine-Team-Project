using UnityEngine;

namespace Work.Scripts.Skills
{
    [CreateAssetMenu(fileName = "Skill", menuName = "SO/Skill")]
    public class SkillSO : ScriptableObject
    {
        [Header("Skill Status")]
        public string skillName;
        public int needSkillPoint;
        public int consumptionDurability;
        public int damagePercent;
        public int damageCount;

        [Header("Animation")]
        public int AnimationNum;
    }
}