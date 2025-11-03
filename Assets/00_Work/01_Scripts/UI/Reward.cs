using DG.Tweening;
using UnityEngine;
using Work.Scripts.Etc;

namespace Work.Scripts.UI
{
    public class Reward : MonoBehaviour, IBattle
    {
        [SerializeField] private float showYPos;
        [SerializeField] private float moveDuration;

        [Header("Items")]
        [SerializeField] private GameObject reward1;
        [SerializeField] private GameObject reward2;
        [SerializeField] private Transform point1;
        [SerializeField] private Transform point2;
        [SerializeField] private Transform inventory;


        private void Start()
        {
            
        }

        public void ShowPanel()
        {
            Instantiate(reward1, point1.position, Quaternion.identity, inventory);
            Instantiate(reward2, point2.position, Quaternion.Euler(new Vector3(0,0,90)), inventory);
            transform.DOMoveY(showYPos, moveDuration);
        }

        public void HidePanel()
        {
            transform.DOMoveY(10, moveDuration);
        }

        public void BattleStart()
        {
            
        }

        public void BattleEnd()
        {
            HidePanel();
        }
    }
}