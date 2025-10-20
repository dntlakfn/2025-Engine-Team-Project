using System.Collections.Generic;
using UnityEngine;
using Work.Scripts.Skills;

namespace Work.Scripts.SO
{
    [CreateAssetMenu(fileName = "PlayerSkillListSO", menuName = "SO/PlayerSkillList")]
    public class PlayerSkillListSO : ScriptableObject
    {
        public List<SkillSO> playerSkills = new List<SkillSO>();
    }
}