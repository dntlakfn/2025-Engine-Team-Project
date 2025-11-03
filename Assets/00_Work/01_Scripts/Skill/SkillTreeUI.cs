using System;
using System.Collections.Generic;
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



        public void InitializeUI()
        {
            PopulateSkillBranchUI(Lights, skillTreeSO.Lights);
            PopulateSkillBranchUI(Mediums, skillTreeSO.Mediums);
            PopulateSkillBranchUI(Strongs, skillTreeSO.Strongs);
        }

        private void PopulateSkillBranchUI(Transform skillBtns, List<SkillSO> skills)
        {
            SkillNodeUI[] skillNodeUI = skillBtns.GetComponentsInChildren<SkillNodeUI>(true);
            
            for(int i = 0; i < skillNodeUI.Length-1; i++)
            {
                if (skills[i] == null)
                {
                    skillNodeUI[i].gameObject.SetActive(false);
                    continue;
                }
                else
                {
                    skillNodeUI[i].gameObject.SetActive(true);
                }
                skillNodeUI[i].SetSkill(skills[i]);
                skillNodeUI[i].AddClickEvent(() => 
                {
                    skillNodeUI[i + 1].ActiveBtn(true);
                    skillNodeUI[i].RemoveClickEvent();
                });
            }
            if(skills[skillNodeUI.Length - 1] == null)
            {
                skillNodeUI[skillNodeUI.Length - 1].gameObject.SetActive(false);
            }
            else
            {
                skillNodeUI[skillNodeUI.Length - 1].gameObject.SetActive(true);

                skillNodeUI[skillNodeUI.Length - 1].SetSkill(skills[skillNodeUI.Length - 1]);

            }
        }
    }
}