using System;
using UnityEngine;
using Work.Scripts.UI;

namespace Work.Scripts.Skills
{
    public class SkillTreeUI : MonoBehaviour
    {
        [SerializeField] private SkillTreeSO skillTreeSO;

        [SerializeField] private Transform Lights;
        [SerializeField] private Transform Mediums;
        [SerializeField] private Transform Strongs;
        [SerializeField] private Transform Defenses;


        public void InitializeUI()
        {
            PopulateSkillBranchUI(Lights, skillTreeSO.skillLists.Lights);
            PopulateSkillBranchUI(Mediums, skillTreeSO.skillLists.Mediums);
            PopulateSkillBranchUI(Strongs, skillTreeSO.skillLists.Strongs);
            PopulateSkillBranchUI(Defenses, skillTreeSO.skillLists.Defenses);
        }

        private void PopulateSkillBranchUI(Transform skillBtns, SkillNode skills)
        {
            SkillNode currentSkillNode = skills;
            SkillNodeUI[] skillNodeUI = skillBtns.GetComponentsInChildren<SkillNodeUI>();
            for(int i = 0; i < skillNodeUI.Length; i++)
            {
                
                skillNodeUI[i].SetSkill(currentSkillNode.data);
                currentSkillNode = currentSkillNode.next;
            }
        }
    }
}