using System;
using System.Collections.Generic;
using UnityEngine;
using Work.Scripts.UI;

namespace Work.Scripts.SO
{
    public enum StageType
    {
        Battle = 0,
        Chest = 1,
        Rest,
        Boss
    }

    [Serializable]
    public class EnemyFooting
    {
        public GameObject[] enemies;
    }

    [CreateAssetMenu(fileName = "StageDataSO", menuName = "SO/StageData", order = 1)]
    public class BattleStageDataSO : ScriptableObject
    {


        // Battle Stage
        public List<EnemyFooting> enemies;



        // Boss Stage
        public GameObject bossEnemy;
    }
}