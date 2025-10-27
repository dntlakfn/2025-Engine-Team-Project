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
        [SerializeField] private Transform enemyPoint;
        [SerializeField] private Image hpBar;
        [SerializeField] private TextMeshProUGUI hpText;
       
        private EntityHealth entity = null;

        public void BattleStart()
        {

        }

        private void Update()
        {

            if(entity == null) return;
            hpBar.fillAmount = ((float)entity.HP / (float)entity.maxHealth);
            hpText.text = $"{entity.HP}/{entity.maxHealth}";
        }

        public void SetEntity(EntityHealth entityHealth)
        {
            entity = entityHealth;
            entity.OnDeath += ClearEntity;
        }
        public void ClearEntity()
        {
            entity.OnDeath -= ClearEntity;
            entity = null;
        }

        public void BattleEnd()
        {
            gameObject.SetActive(false);

        }
    }
}