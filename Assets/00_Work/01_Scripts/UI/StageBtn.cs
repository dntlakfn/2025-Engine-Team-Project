using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Work.Scripts.Etc;
using Work.Scripts.SO;

namespace Work.Scripts.UI
{
    

    public class StageBtn : MonoBehaviour
    {
        private StageType stageType;
        private Button btn;
        private LineRenderer lineRenderer;

        private void Awake()
        {
            btn = GetComponent<Button>();
            lineRenderer = GetComponent<LineRenderer>();
            stageType = StageType.Battle;
            btn.onClick.AddListener(OnClick);
        }


        public void OnClick()
        {
            StageSettingManager.Instance.SetStage(stageType);
        }

        public void LineToNextBtn(Vector3 next)
        {
            if(lineRenderer == null)
            {
                lineRenderer = GetComponent<LineRenderer>();
            }
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, next - Vector3.forward);
            lineRenderer.SetPosition(1, transform.position - Vector3.forward);
        }

        public StageType GetStageType()
        {
            return stageType;
        }

        public void SetStage(StageType type)
        {
            stageType = type;
        }

        public void SetIcon(Sprite icon)
        {
            GetComponent<Image>().sprite = icon;
        }

        public void AddClickEvent(UnityAction action)
        {
            btn.onClick.AddListener(action);
        }

        public void RemoveClickEvent(UnityAction action) { btn.onClick.RemoveListener(action); }

        public void ActiveBtn(bool isActive)
        {
            btn.interactable = isActive;
        }
    }
}