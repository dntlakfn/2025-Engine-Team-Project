using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Work.Scripts.SO;

namespace Work.Scripts.UI
{
    

    public class StageBtn : MonoBehaviour
    {
        [SerializeField] private StageDataSO stageData;
        private StageType stageType;

        private void Awake()
        {
            stageType = (StageType)Random.Range(0, 4);
            GetComponent<Button>().onClick.AddListener(OnClick);
        }


        public void OnClick()
        {
            StageSettingManager.Instance.SetStage(stageType);
        }

        

        
    }
}