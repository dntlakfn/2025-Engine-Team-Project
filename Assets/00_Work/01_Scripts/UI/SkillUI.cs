using DG.Tweening;
using UnityEngine;
using Work.Scripts.Etc;
using Work.Scripts.SO;

namespace Work.Scripts.UI
{
    public class SkillUI : MonoBehaviour, IBattle
    {
        [Header("Panel Move Settings")]
        [SerializeField] private float showXPos;
        [SerializeField] private float moveDuration;
        private bool _isShow;

        [Header("SkillBtn Setting")]
        [SerializeField] private PlayerSkillListSO playerSkillList;
        [SerializeField] private Transform skillBtnsParent;

        public void BattleStart()
        {
            SetSkillBtn();
        }

        public void TogglePanel()
        {
            if(_isShow)
            {
                transform.DOMoveX(-showXPos-9, moveDuration);
                _isShow = false;
            }
            else
            {
                transform.DOMoveX(showXPos-9, moveDuration);
                _isShow = true;
            }
        }

        public void ShowPannel()
        {
            transform.DOMoveX(showXPos - 9, moveDuration);
        }

        public void ClosePannel()
        {
            transform.DOMoveX(-showXPos - 9, moveDuration);
        }

        public void SetSkillBtn()
        {
            var skillBtnPrefabs = skillBtnsParent.GetComponentsInChildren<SkillNodeUI>(true);
            for (int i = 0; i < skillBtnPrefabs.Length; i++)
            {
                if(playerSkillList.playerSkills.Count > i)
                {
                    skillBtnPrefabs[i].gameObject.SetActive(true);

                    skillBtnPrefabs[i].SetSkill(playerSkillList.playerSkills[i]);
                }
                else
                {
                    skillBtnPrefabs[i].gameObject.SetActive(false);
                }
            }
        }

        public void BattleEnd()
        {
            

        }
    }
}