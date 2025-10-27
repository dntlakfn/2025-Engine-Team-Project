using System.Collections;
using TMPro;
using UnityEngine;
using Work.Scripts.Entities;

namespace Work.Scripts.UI
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private TextMeshProUGUI damageText;
        

        private void Awake()
        {
            
        }


        public void Show(int damage, Vector3 point, Transform canvas)
        {
            DamageText a = Instantiate(this, point, Quaternion.identity, canvas);
            a.damageText.text = damage.ToString();
            a.damageText.fontSize = 36 + damage;
            a.animator.Play("ShowText");
            a.StartCoroutine(FadeOut(a.gameObject));
        }


        private IEnumerator FadeOut(GameObject a)
        {
            float duration = 0f;
            while (duration <= 2f)
            {
                duration += Time.deltaTime;
                Color.Lerp(damageText.color, new Color(damageText.color.r, damageText.color.g, damageText.color.b, 0f), duration);
                yield return null;
            }
            Destroy(a);

        }
    }
}
