using DG.Tweening;
using UnityEngine;

namespace Work.Scripts.UI
{
    public class SkillUI : MonoBehaviour
    {
        [SerializeField] private float showXPos;
        [SerializeField] private float moveDuration;
        private bool _isShow;

        public void TogglePanel()
        {
            if(_isShow)
            {
                transform.DOMoveX(-showXPos-9, moveDuration);
                _isShow = false;
            }
            else
            {
                transform.DOMoveX(showXPos-9, moveDuration);
                _isShow = true;
            }
        }



    }
}