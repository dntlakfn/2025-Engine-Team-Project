using UnityEngine;
using Work.Scripts.UI;
using Work.Scripts.SO;

namespace Work.Scripts.Etc
{
    public class StageSettingManager : MonoBehaviour
    {
        public static StageSettingManager Instance;

        [SerializeField] private BattleStageDataSO stageData;
        [SerializeField] private GameObject stageUI;
        [SerializeField] private ChestUI chestUI;
        [SerializeField] private GameObject restUI;
        [SerializeField] private Transform[] enemySpawnPoint;
        

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }


        #region Stage Setting
        public void SetStage(StageType stageType)
        {
            switch (stageType)
            {
                case StageType.Battle:
                    SpawnEnemies();
                    break;
                case StageType.Chest:
                    ShowChestMap();
                    break;
                case StageType.Rest:
                    ShowRestUI();
                    break;
                case StageType.Boss:
                    SpawnBoss();
                    break;
            }
            stageUI.SetActive(false);
        }

        private void SpawnEnemies()
        {
            EnemyFooting enemyFooting = stageData.enemies[Random.Range(0, stageData.enemies.Count)];
            for (int i = 0; i < enemyFooting.enemies.Length; i++)
            {
                var enemy = Instantiate(enemyFooting.enemies[i], enemySpawnPoint[i].position, Quaternion.Euler(new Vector3(0, -90, 0)), enemySpawnPoint[i]);
            }
        }

        private void ShowChestMap()
        {
            // chestUI.SetChest();
        }

        private void ShowRestUI()
        {
            // restUI.Show();
        }

        private void SpawnBoss()
        {
            Instantiate(stageData.bossEnemy, enemySpawnPoint[1].position, Quaternion.Euler(new Vector3(0, -90, 0)), enemySpawnPoint[1]);
        }
        #endregion
    }
}