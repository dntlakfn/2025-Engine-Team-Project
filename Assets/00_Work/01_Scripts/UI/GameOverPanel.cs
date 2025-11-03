using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Work.Scripts.UI
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private Image childPanel;
        [SerializeField] private Image btn;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private TextMeshProUGUI btnText;


        public void Show()
        {
            gameObject.SetActive(true);
            Image panel = GetComponent<Image>();
            panel.DOColor(new Color(0.2981131f, 0, 0, 0.6f), 3);
            panel.DOColor(new Color(0, 0, 0, 1f), 2);
            DOVirtual.DelayedCall(3, () =>
            {
                childPanel.DOFade(225, 1);
                btn.DOFade(225, 1);
                text.DOFade(225, 1);
                btnText.DOFade(225, 1);
            });
            
        }

        public void GoTitle()
        {
            
            SceneManager.LoadScene("Title");
        }
    }
}