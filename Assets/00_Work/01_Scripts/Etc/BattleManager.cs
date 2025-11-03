
using UnityEngine;
using UnityEngine.SceneManagement;
using Work.Scripts.Enemies;

using Work.Scripts.UI;

namespace Work.Scripts.Etc
{

    public class BattleManager : MonoBehaviour
    {

        public static BattleManager Instance;
        public TurnManager TurnManager;
        [SerializeField] private AttackCamera attackCamera;

        public EnemyController[] enemies;
        public int deathCount = 0;
        [SerializeField] private GameOverPanel gameOverPanel;
        [SerializeField] private Reward rewardPanel;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            BattleStart();
        }

        public void BattleStart()
        {

            foreach (var a in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
            {
                if (a is IBattle component)
                {
                    Debug.Log(component);
                    component.BattleStart();
                }

            }
        }

        public void BattleEnd()
        {
            foreach (var a in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
            {
                if (a is IBattle component)
                {
                    Debug.Log(component);
                    component.BattleEnd();
                    
                }

            }
            deathCount = 0;
        }

        public void GameOver()
        {
            TurnManager.StopTurn();
            attackCamera.CamShutDown();
            gameOverPanel.Show();   
        }

        public void StageClear()
        {
            rewardPanel.ShowPanel();
        }

        public void EntityDead(bool isPlayer, bool isBoss)
        {
            deathCount++;
            if(isPlayer)
            {
                GameOver();
                return;
            }
            else if(isBoss)
            {
                EndingScene(); 
                return;
            }
            else if (deathCount >= enemies.Length)
            {
                StageClear();
                return;

            }

        }

        public void EndingScene()
        {
            SceneManager.LoadScene("End");
        }

        public AttackCamera GetAttackCamera()
        {
            return attackCamera;
        }


    }
}