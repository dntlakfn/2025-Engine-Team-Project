using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Work.Scripts.UI;

namespace Work.Scripts.Skills
{

    [CreateAssetMenu(menuName = "SO/SkillTree")]
    public class SkillTreeSO : ScriptableObject
    {
        public WeaponType weaponType;
        public Sprite weaponIcon;

        public List<SkillSO> Lights;
        public List<SkillSO> Mediums;
        public List<SkillSO> Strongs;


        public int skillPoints = 0;
        public UnityEvent<WeaponType> OnLevelUp;
        private int WeaponLevel = 0;
        private int expRequirement = 50;
        private int exp;


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

        public int GetExpRequirement()
        {
            return expRequirement;
        }
    }
}