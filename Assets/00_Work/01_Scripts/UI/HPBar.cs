using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Work.Scripts.Enemies;
using Work.Scripts.Entities;
using Work.Scripts.Etc;

namespace Work.Scripts.UI
{
    public class HPBar : MonoBehaviour, IBattle
    {
        [Header("Only Player")]
        [SerializeField] private EntityHealth entity = null;

        [Header("All")]
        [SerializeField] private Image hpBar;
        [SerializeField] private TextMeshProUGUI hpText;
       
        


        private void Update()
        {

            if(entity == null) return;
            hpBar.fillAmount = ((float)entity.HP / (float)entity.maxHealth);
            hpText.text = $"{entity.HP}/{entity.maxHealth}";
        }

        public void SetEntity(EntityHealth entityHealth)
        {
            entity = entityHealth;
        }
        public void ClearEntity()
        {
            entity = null;
        }

        public void BattleEnd()
        {
            if(!entity.isPlayer)
            {
                gameObject.SetActive(false);
                ClearEntity();
            }
        }

        public void BattleStart()
        {
            
        }
    }
}