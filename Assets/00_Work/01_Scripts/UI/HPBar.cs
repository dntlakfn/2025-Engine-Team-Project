using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Work.Scripts.Entities;

namespace Work.Scripts.UI
{
    public class HPBar : MonoBehaviour
    {
        [SerializeField] private EntityHealth entity;
        [SerializeField] private Image hpBar;
        [SerializeField] private TextMeshProUGUI hpText;


        private void Update()
        {
            hpBar.fillAmount = entity.HP / entity.maxHealth;
            hpText.text = $"{entity.maxHealth}/{entity.HP}";
        }
    }
}