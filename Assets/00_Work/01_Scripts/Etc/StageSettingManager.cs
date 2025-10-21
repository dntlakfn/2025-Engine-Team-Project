using UnityEngine;
using Work.Scripts.SO;

public class StageSettingManager : MonoBehaviour
{
    public static StageSettingManager Instance;

    [SerializeField] private StageDataSO stageData;
    [SerializeField] private GameObject stageUI;
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
            var enemy = Instantiate(enemyFooting.enemies[i], enemySpawnPoint[i].position, Quaternion.Euler(new Vector3(0,-90,0)), enemySpawnPoint[i]);
        }
    }

    private void ShowChestMap()
    {
        Instantiate(stageData.chestMap, stageUI.transform.parent);
    }

    private void ShowRestUI()
    {
        Instantiate(stageData.restUI, stageUI.transform.parent);
    }

    private void SpawnBoss()
    {
        Instantiate(stageData.bossEnemy, enemySpawnPoint[1].position, Quaternion.Euler(new Vector3(0,-90,0)), enemySpawnPoint[1]);
    }
}
