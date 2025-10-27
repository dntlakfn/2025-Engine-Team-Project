using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Work.Scripts.Etc;
using Work.Scripts.SO;


namespace Work.Scripts.UI
{
    public class StageNode
    {
        public StageNode next;

        public StageBtn data;
    }

    public class StageUI : MonoBehaviour
    {
        [SerializeField] private RectTransform content;
        [SerializeField] private Sprite[] stageIcons;

        [Header("StageNode Setting")]
        [SerializeField] private int minNonBattleRoomAppearFloor = 0;
        [SerializeField] private int maxChestStageCount;
        [SerializeField] private int maxRestStageCount;
        private int chestStageCount = 0;
        private int restStageCount = 0;
        private StageBtn[][] stageBtns = new StageBtn[12][];
        private StageNode[][] stageNodes = new StageNode[11][];
        


        public void Start()
        {
            // 버튼 받아오기
            for (int i = 0; i < content.childCount; i++)
            {
                stageBtns[i] = content.GetChild(i).GetComponentsInChildren<StageBtn>();
                foreach (StageBtn btn in stageBtns[i])
                {
                    btn.SetIcon(stageIcons[(int)btn.GetStageType()]);
                }
            }



            SettingChestAndRestStage();
            ConnectStageBtns();
            UpdateLine();
        }

        /// <summary>
        /// 상자 방과 휴식방 최대갯수(maxChestStageCount, maxRestStageCount)와 최초 등장가능 층 수(minNonBattleRoomAppearFloor)에 따라 랜덤으로 상자 방과 휴식 방 생성
        /// </summary>
        public void SettingChestAndRestStage()
        {
            // 스테이지 타입 설정
            // minNonBattleRoomAppearFloor를 11 이상으로 하면 오류난다
            for (int i = 0; i < (maxChestStageCount + maxRestStageCount); i++)
            {
                int a = Random.Range(minNonBattleRoomAppearFloor - 1, stageBtns.Length - 1);
                int b = Random.Range(0, 4);
                while (stageBtns[a][b].GetStageType() != StageType.Battle)
                {
                    a = Random.Range(minNonBattleRoomAppearFloor - 1, stageBtns.Length - 1);
                    b = Random.Range(0, 4);
                }

                if (chestStageCount < maxChestStageCount)
                {
                    stageBtns[a][b].SetStage(StageType.Chest);
                    stageBtns[a][b].SetIcon(stageIcons[(int)StageType.Chest]);
                    chestStageCount++;
                    continue;
                }
                if (restStageCount < maxRestStageCount)
                {
                    stageBtns[a][b].SetStage(StageType.Rest);
                    stageBtns[a][b].SetIcon(stageIcons[(int)StageType.Rest]);
                    restStageCount++;
                    continue;
                }
            }


            // 마지막은 보스방
            var t = stageBtns[stageBtns.Length - 1].Last();
            t.SetStage(StageType.Boss);
            t.SetIcon(stageIcons[(int)t.GetStageType()]);
        }

        /// <summary>
        /// 스테이지 노드들 서로 랜덤으로 연결
        /// </summary>
        public void ConnectStageBtns()
        {
            for (int i = 0; i < stageBtns.Length - 1; i++)
            {
                stageNodes[i] = new StageNode[stageBtns[i].Length];
                StageBtn[] nexts = stageBtns[i + 1];
                StageBtn[] currents = stageBtns[i];

                for (int j = 0; j < stageNodes[i].Length; j++)
                {
                    stageNodes[i][j] = new StageNode();
                    stageNodes[i][j].data = currents[j];
                    StageNode nextNode = new StageNode();
                    int rand = Random.Range(0, nexts.Length);
                    nextNode.data = nexts[rand];
                    stageNodes[i][j].next = nextNode;


                    //선 연결
                    stageNodes[i][j].data.LineToNextBtn(stageNodes[i][j].next.data.transform.position);


                    if (nexts.Length > 1)
                    {
                        var t = nexts.ToList();
                        t.RemoveAt(rand);
                        nexts = t.ToArray();
                    }
                }
            }
        }


        /// <summary>
        /// 스테이지 끼리 선 연결
        /// </summary>
        public void UpdateLine()
        {
            for(int i = 0; i < stageNodes.Length; i++)
            {
                for(int j = 0; j < stageNodes[i].Length; j++)
                {
                    stageNodes[i][j].data.LineToNextBtn(stageNodes[i][j].next.data.transform.position);
                }
            }
        }

    }
}