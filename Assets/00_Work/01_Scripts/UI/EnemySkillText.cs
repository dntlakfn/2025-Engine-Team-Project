using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Work.Scripts.UI
{
    public class EnemySkillText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI enemyUsingSkillText;
        [SerializeField] private Image background;


        public void Show(string skillName)
        {
            
            enemyUsingSkillText.text = skillName;
            background.color = Color.black;
            enemyUsingSkillText.color = Color.black;
            background.DOColor(Color.white, 0.5f);
            enemyUsingSkillText.DOColor(Color.white, 0.5f);
            Destroy(gameObject, 1f);
        }
    }
}