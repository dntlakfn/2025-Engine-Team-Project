using DG.Tweening;
using UnityEngine;

namespace Work.Scripts.UI
{
    public class Reward : MonoBehaviour
    {
        [SerializeField] private float showYPos;
        [SerializeField] private float moveDuration;

        [Header("Items")]
        [SerializeField] private GameObject reward1;
        [SerializeField] private GameObject reward2;
        
        public void ShowPanel()
        {
            transform.DOMoveY(showYPos, moveDuration);
        }

        public void HidePanel()
        {
            transform.DOMoveY(-showYPos, moveDuration);
        }

        
    }
}