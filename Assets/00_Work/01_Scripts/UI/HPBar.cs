using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Work.Scripts.Entities;
using Work.Scripts.Etc;

namespace Work.Scripts.UI
{
    public class HPBar : MonoBehaviour, IBattle
    {
        [SerializeField] private EntityHealth entity;
        [SerializeField] private Image hpBar;
        [SerializeField] private TextMeshProUGUI hpText;

        public void Initialize()
        {
            if (!entity.isActiveAndEnabled) gameObject.SetActive(false);
            else gameObject.SetActive(true);
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
            entity = null;
        }
    }
}