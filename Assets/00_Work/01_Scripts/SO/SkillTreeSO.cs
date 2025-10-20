using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Work.Scripts.UI;

namespace Work.Scripts.Skills
{
    [Serializable]
    public class SkillNode
    {
        public SkillNode next = null;

        public SkillSO data;

        public SkillNode(SkillSO data = null)
        {
            this.data = data;
        }
    }

    [Serializable]
    public class SkillLists
    {
        public SkillNode Lights = new SkillNode();
        public SkillNode Mediums = new SkillNode();
        public SkillNode Strongs = new SkillNode();
        public SkillNode Defenses = new SkillNode();

    }

    [CreateAssetMenu(menuName = "SO/SkillTree")]
    public class SkillTreeSO : ScriptableObject
    {
        public WeaponType weaponType;
        public Sprite weaponIcon;

        [SerializeField] private List<SkillSO> Lights;
        [SerializeField] private List<SkillSO> Mediums;
        [SerializeField] private List<SkillSO> Strongs;
        [SerializeField] private List<SkillSO> Defenses;

        [HideInInspector]
        public SkillLists skillLists;

        public int skillPoints = 0;
        public UnityEvent<WeaponType> OnLevelUp;
        private int WeaponLevel = 0;
        private int expRequirement = 50;
        private int exp;

        private void Awake() 
        {
            for(int i = 0; i < 4; i++)
            {
                skillLists = new SkillLists();
                List<SkillSO>[] temp = { Lights, Mediums, Strongs, Defenses };

                SkillNode[] skillNodes = { skillLists.Lights, skillLists.Mediums, skillLists.Strongs, skillLists.Defenses };

                int idx = 0;
                foreach (var skills in temp)
                {
                    SetSkillTree(skillNodes[i], skills, idx);
                }
            }
        }

        private void SetSkillTree(SkillNode skillNode, List<SkillSO> skillList, int idx)
        {
            if (idx >= skillList.Count) return;

            skillNode.data = skillList[idx];
            idx++;
            SetSkillTree(skillNode.next, skillList, idx);
        }

        public int EXP
        {
            get
            {
               
                return exp;
            }
            set
            {
                exp = value;
                if (exp >= expRequirement)
                {
                    exp -= expRequirement;
                    WeaponLevel++;
                    skillPoints++;
                    expRequirement = expRequirement * 2 - (10 * (-WeaponLevel + 3));
                    OnLevelUp?.Invoke(weaponType);
                }
            }
        }
    }
}