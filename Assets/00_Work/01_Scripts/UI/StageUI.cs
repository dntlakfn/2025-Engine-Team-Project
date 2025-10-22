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

    public class StageUI : MonoBehaviour, IBattle
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
        

        [ContextMenu("StageNode Connect")]
        public void Initialize()
        {
            for (int i = 0; i < content.childCount; i++)
            {
                stageBtns[i] = content.GetChild(i).GetComponentsInChildren<StageBtn>();
                foreach (StageBtn btn in stageBtns[i])
                {
                    btn.SetIcon(stageIcons[(int)btn.GetStageType()]);
                }
            }

            // minNonBattleRoomAppearFloor를 11 이상으로 하면 오류난다
            for (int i = 0; i < (maxChestStageCount + maxRestStageCount); i++)
            {
                int a = Random.Range(minNonBattleRoomAppearFloor - 1, stageBtns.Length-1);
                int b = Random.Range(0, 4);
                while(stageBtns[a][b].GetStageType() != StageType.Battle)
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

            var t = stageBtns[stageBtns.Length - 1].Last();
            t.SetStage(StageType.Boss);
            t.SetIcon(stageIcons[(int)t.GetStageType()]);

            ConnectStageBtns();
            UpdateLine();
        }

        
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