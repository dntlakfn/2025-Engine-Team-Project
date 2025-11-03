using UnityEngine;
using Work.Scripts.UI;
using Work.Scripts.SO;
using Work.Scripts.Entities;
using TMPro;
using Work.Scripts.Enemies;
using UnityEngine.Rendering;
using System.Linq;

namespace Work.Scripts.Etc
{
    public class StageSettingManager : MonoBehaviour
    {
        public static StageSettingManager Instance;

        [SerializeField] private BattleStageDataSO stageData;
        [SerializeField] private GameObject stageUI;
        [SerializeField] private ChestUI chestUI;
        [SerializeField] private GameObject restUI;

        [Header("Enemy Setting")]
        [SerializeField] private Transform[] enemySpawnPoint;
        [SerializeField] private HPBar[] enemyHpBars;
        [SerializeField] private Transform canvas;
        [SerializeField] private Transform damageTextCanvas;
        [SerializeField] private Volume volume;


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
            EnemyController[] spawnedEnemies = new EnemyController[enemyFooting.enemies.Length];

            for (int i = 0; i < enemyFooting.enemies.Length; i++)
            {
                EnemyController enemy = Instantiate(enemyFooting.enemies[i], enemySpawnPoint[i].position, Quaternion.Euler(new Vector3(0, -90, 0)), enemySpawnPoint[i]).GetComponent<EnemyController>();
                Debug.Log(enemy.gameObject);
                enemy.gameObject.layer = LayerMask.NameToLayer($"Enemy_{i+1}");
                enemy.Initialize(canvas, damageTextCanvas, volume);
                enemyHpBars[i].SetEntity(enemy.GetComponent<EntityHealth>());
                enemyHpBars[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = enemy.enemyName;
                enemyHpBars[i].gameObject.SetActive(true);
                spawnedEnemies[i] = enemy;
            }
            BattleManager.Instance.enemies = spawnedEnemies;


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